namespace ItemEatGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); // 랜덤 클래스 불러오기
            ConsoleKeyInfo keys; // 키보드 입력 불러오기

            int[,] map = new int[51, 21]; // 50 * 20 크기의 맵 생성

            // 모든 배열 값을 돌아다니는 for문
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    map[i, j] = 0; // 모든 배열의 값을 0으로 바꿈
            }

            for (int i = 0; i < 10; i++) // 열번 반복
            {
                int itemX = random.Next(51); // 0부터 50중 랜덤 숫자를 아이템에 X좌표로 정하기
                int itemY = random.Next(21); // 0부터 20중 랜덤 숫자를 아이템에 Y좌표로 정하기
                map[itemX, itemY] = 1; // X, Y 좌표를 맵에 저장하기
            }

            int x = 25, y = 10; // 플레이어의 X, Y좌표
            int lostItem = 10; // 남은 아이템 수
            while (true) // 무한 반복
            {
                if (lostItem == 0) // 남은 아ㅣ템 수가 0이라면
                {
                    Console.WriteLine("축하합니다! 아이템을 전부 모았습니다!"); // 축하 메세지
                    break; // 무한반복 멈추기
                }

                Console.Clear(); // 콘솔 초기화

                Console.SetCursorPosition(1, 25); // 1, 25 좌표에 콘솔 커서 놓기
                Console.Write("============ X좌표: " + x + " Y좌표: " + y + " 남은 아이템 갯수: " + lostItem + " ============"); // 플레이어의 X좌표, Y좌표, 남은 아이템 갯수를 출력

                // 맵의 크기 만큼 반복
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == 1) // 만약 아이템이 있는 좌표라면
                        {
                            Console.SetCursorPosition(i, j); // 그 좌표에 콘솔 커서 놓기
                            Console.Write("$"); // 아이템 좌표에 $ 출력하기
                        }
                    }
                }
                Console.SetCursorPosition(x, y); // 플레이어의 x, y좌표에 콘솔 커서 놓기
                Console.Write("P"); // 플레이어 좌표에 P 출력

                keys = Console.ReadKey(true); // 키를 누르고 있다면

                switch (keys.Key)
                {
                    case ConsoleKey.LeftArrow: // 왼쪽 방향키를 눌렀다면
                        if (x <= 0) x = 50; // x좌표가 0 이하면 x 좌표 50으로 바꾸기
                        else x--; // 아니면 x좌표 -1
                        break;
                    case ConsoleKey.RightArrow:
                        if (x >= 50) x = 0; // x좌표가 50 이상이면 x 좌표 0으로 바꾸기
                        else x++; // 아니면 x좌표 +1
                        break;
                    case ConsoleKey.UpArrow:
                        if (y <= 0) y = 20; // y좌표가 0 이하면 y 좌표 20으로 바꾸기
                        else y--; // 아니면 y좌표 -1
                        break;
                    case ConsoleKey.DownArrow:
                        if (y >= 20) y = 0; // y좌표가 20 이상이면 y 좌표 0으로 바꾸기
                        else y++; // 아니면 y좌표 +1
                        break;
                }
                if (map[x, y] == 1) // 만약 플레이어 좌표가 아이템 위치에 있다면
                {
                    map[x, y] = 0; // 그 위치의 아이템 삭제
                    lostItem--; // 남은 아이템 갯수 -1
                }
            }
        }
    }
}
