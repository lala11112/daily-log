using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yone
{
    
    class Program
    {
        static int screenX = 50, screenY = 30;
        static int px = 25, py = 12;
        static bool isGameOn = true;
        static Skill skill = new Skill();
        static void Main(string[] args)
        {
            while (isGameOn == true)
            {
                MovePlayer();
            }
            ExitGame();
        }
        static void MovePlayer()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.SetCursorPosition(px, py);
            Console.WriteLine(" ");
            if (skill.isDalay == false) // skill의 딜레이중이 false 라면 이동 가능
            {
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        skill.lastKey = "Left";
                        px--;
                        break;
                    case ConsoleKey.RightArrow:
                        skill.lastKey = "Right";
                        px++;
                        break;
                    case ConsoleKey.UpArrow:
                        skill.lastKey = "Up";
                        py--;
                        break;
                    case ConsoleKey.DownArrow:
                        skill.lastKey = "Down";
                        py++;
                        break;

                }
                switch (cki.Key)
                {
                    case ConsoleKey.Q:
                        skill.px = px;
                        skill.py = py;
                        skill.QSkill();
                        px = skill.px;
                        py = skill.py;
                        break;
                    case ConsoleKey.W:
                        skill.px = px;
                        skill.py = py;
                        skill.WSkill();
                        px = skill.px;
                        py = skill.py;
                        break;
                    case ConsoleKey.E:
                        
                        skill.px = px;
                        skill.py = py;
                        skill.ESkill();
                        px = skill.px;
                        py = skill.py;
                        break;
                    case ConsoleKey.R:

                        skill.px = px;
                        skill.py = py;
                        skill.RSkill();
                        px = skill.px;
                        py = skill.py;
                        break;
                }
            }

            if (px >= screenX) px = 1;
            if (py >= screenY) py = 1;
            if (px <= 0) px = screenX - 1;
            if (py <= 0) py = screenY - 1;
            Console.SetCursorPosition(px, py);
            Console.Write("P");
        }
        static void ExitGame()
        {
            Console.Write("게임 끝");
        }
    }
}