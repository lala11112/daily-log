using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEatGame
{
    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        enum Mark { empty, player, item }
        static int screenX = 50, screenY = 25;
        static Mark[,] screen = new Mark[screenX, screenY];
        static List<Point> itemList = new List<Point>();
        static int px = 25, py = 12;
        static bool isGameOn = true;
        static void Main(string[] args)
        {
            ClearScreen(); // screen을 empty로 채움
            MakeItem(); // 아이템 위치 생성 후 리스트 및 스크린에 보관
            DrawScreen(); // 스크린 그리기
            while (isGameOn == true)
            {
                MovePlayer();
                CheckState();
            }
            ExitGame();
        }
        static void ClearScreen()
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = Mark.empty;
                }
            }
        }
        static void MakeItem()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(1, screenX - 1);
                int y = random.Next(1, screenY - 1);
                Point point = new Point(x, y);
                itemList.Add(point);
                screen[x, y] = Mark.item;
            }
        }
        static void DrawScreen()
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    if (screen[i, j] == Mark.item)
                    {
                        Console.SetCursorPosition(i, j); // 그 좌표에 콘솔 커서 놓기
                        Console.Write("$"); // 아이템 좌표에 $ 출력하기
                    }

                }
            }
            ShowCursorPosition();
        }
        private static void ShowCursorPosition()
        {
            Console.SetCursorPosition(15, 30);
            Console.Write("============ X좌표: " + px + " Y좌표: " + py + " 남은 아이템 갯수: " + itemList.Count + " ============"); // 플레이어의 X좌표, Y좌표, 남은 아이템 갯수를 출력

        }
        static void MovePlayer()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.SetCursorPosition(px, py);
            Console.WriteLine(" ");

            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    px--;
                    break;
                case ConsoleKey.RightArrow:
                    px++;
                    break;
                case ConsoleKey.UpArrow:
                    py--;
                    break;
                case ConsoleKey.DownArrow:
                    py++;
                    break;
            }
            if (px >= screenX) px = 1;
            if (py >= screenY) py = 1;
            if (px <= 0) px = screenX - 1;
            if (py <= 0) py = screenY - 1;
            Console.SetCursorPosition(px, py);
            Console.Write("P");
            ShowCursorPosition();
        }
        static void CheckState()
        {
            if (screen[px, py] == Mark.item)
            {
                for (int i = itemList.Count - 1; i >= 0; i--)
                {
                    if (itemList[i].x == px && itemList[i].y == py)
                    {
                        itemList.Remove(itemList[i]);
                        if (itemList.Count == 0)
                        {
                            isGameOn = false;
                        }
                    }
                }

                screen[px, py] = Mark.empty;
            }
        }
        static void ExitGame()
        {
            Console.Write("게임 끝");
        }
    }
}
