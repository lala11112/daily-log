using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yone
{
    public class Skill: SkillData
    { 
        public Skill() {

            // 요네의 Q스킬 데이터 삽입
            skillData[0].Key = SkillKey.Q;
            skillData[0].name = "필멸의 검";
            skillData[0].toolTip = "전방으로 검을 내질러 물리 피해를 입힙니다.";
            skillData[0].skillDir = 4;
            skillData[0].damage = 20;
            skillData[0].coolTime = 2;
            skillData[0].delay = 1f;

            // 요네의 W스킬 데이터 삽입
            skillData[1].Key = SkillKey.W;
            skillData[1].name = "영혼 가르기";
            skillData[1].toolTip = "요네가 전방을 가르며 최대 체력에 비례한 물리 피해 및 마법 피해를 입힙니다.";
            skillData[1].skillDir = 6;
            skillData[1].damage = 8;
            skillData[1].coolTime = 9;
            skillData[1].delay = 1.2f;

            // 요네의 E스킬 데이터 삽입
            skillData[2].Key = SkillKey.E;
            skillData[2].name = "영혼 해방";
            skillData[2].toolTip = "요네가 5초 동안 영혼 상태가 되어 육신을 떠나고 다시 되돌아 옵니다.";
            skillData[2].skillDir = 0;
            skillData[2].damage = 0;
            skillData[2].coolTime = 16;
            skillData[2].delay = 0.1f;

            // 요네의 R스킬 데이터 삽입
            skillData[3].Key = SkillKey.R;
            skillData[3].name = "운명 봉인";
            skillData[3].toolTip = "요네가 경로에 있는 모든 적을 공격해 물리 피해와 마법 피해를 입히고 경로에 있는 마지막 챔피언 뒤로 순간이동해 적중한 모든적을 끌어 당깁니다.";
            skillData[3].skillDir = 25;
            skillData[3].damage = 50;
            skillData[3].coolTime = 65;
            skillData[3].delay = 2f;
        }

        static int Qstack = 0; // Q 스킬의 스택
        static int QstackSkillDir = 10; // Q 풀스택 스킬의 거리
        public override void QSkill()
        {
            skillKey = "Q";
            SkillDataUpDate(); // Q 스킬 데이터 넣기

            // 스킬을 쓴 플레이어의 위치에 파란색 P 출력
            Console.SetCursorPosition(px, py);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("P");
            Console.ResetColor();
            if (lastKey == "Left") // 왼쪽으로 움직이고 있었을때
            {
                if (Qstack >= 2) // Q 2스택을 쌓았다면
                {
                    for(int i = 0; i < QstackSkillDir;i++)
                    {
                        Console.SetCursorPosition(px - i, py + 1);
                        Console.Write("+");
                        Console.SetCursorPosition(px - i, py - 1);
                        Console.Write("+");
                        Thread.Sleep(50);

                        Console.SetCursorPosition(px - i, py);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("P");
                        Console.ResetColor();
                        Console.SetCursorPosition(px - i + 1, py);
                        Console.Write(" ");
                        
                    }
                    Console.SetCursorPosition(px - QstackSkillDir - 1, py);
                    Console.Write("+");

                    Thread.Sleep((int)delay * 1000);
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px - i, py + 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(px - i, py - 1);
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(px - QstackSkillDir - 1, py);
                    Console.Write(" ");
                    Qstack = 0;

                    px = px - QstackSkillDir + 1;
                }
                else // Q 스택이 2스택 이하일때
                {
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px - i, py);
                        Console.Write("+");
                        Thread.Sleep(20);
                    }
                    Thread.Sleep((int)delay * 1000);
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px - i, py);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Qstack++;
                }
            }
            if (lastKey == "Right") // 오른쪽으로 움직이고 있었을때
            {
                if (Qstack >= 2) // Q 2스택을 쌓았다면
                {
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px + i, py + 1);
                        Console.Write("+");
                        Console.SetCursorPosition(px + i, py - 1);
                        Console.Write("+");
                        Thread.Sleep(50);

                        Console.SetCursorPosition(px + i, py);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("P");
                        Console.ResetColor();
                        Console.SetCursorPosition(px + i - 1, py);
                        Console.Write(" ");

                    }
                    Console.SetCursorPosition(px + QstackSkillDir + 1, py);
                    Console.Write("+");

                    Thread.Sleep((int)delay * 1000);
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px + i, py + 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(px + i, py - 1);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Console.SetCursorPosition(px + QstackSkillDir - 1, py);
                    Console.Write(" ");
                    Qstack = 0;

                    px = px + QstackSkillDir + 1;
                }
                else // Q 스택이 2스택 이하일때
                {
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px + i, py);
                        Console.Write("+");
                        Thread.Sleep(20);
                    }
                    Thread.Sleep((int)delay * 1000);
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px + i, py);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Qstack++;
                }
            }
            if (lastKey == "Up") // 윗쪽으로 움직이고 있었을때
            {
                if (Qstack >= 2) // Q 2스택을 쌓았다면
                {
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px - 1, py - i);
                        Console.Write("+");
                        Console.SetCursorPosition(px + 1, py - i);
                        Console.Write("+");
                        Thread.Sleep(50);

                        Console.SetCursorPosition(px, py - i);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("P");
                        Console.ResetColor();
                        Console.SetCursorPosition(px, py - i + 1);
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(px , py - QstackSkillDir - 1);
                    Console.Write("+");

                    Thread.Sleep((int)delay * 1000);
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px - 1, py - i);
                        Console.Write(" ");
                        Console.SetCursorPosition(px + 1, py - i);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Console.SetCursorPosition(px, py - QstackSkillDir - 1);
                    Console.Write(" ");
                    Qstack = 0;

                    py = py - QstackSkillDir + 1;
                }
                else // Q 스택이 2스택 이하일때
                {
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px, py - i);
                        Console.Write("+");
                        Thread.Sleep(20);
                    }
                    Thread.Sleep((int)delay * 1000);
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px, py - i);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Qstack++;
                }
            }
            if (lastKey == "Down") // 아랫쪽으로 움직이고 있었을때
            {
                if (Qstack >= 2) // Q 2스택을 쌓았다면
                {
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px - 1, py + i);
                        Console.Write("+");
                        Console.SetCursorPosition(px + 1, py + i);
                        Console.Write("+");
                        Thread.Sleep(50);

                        Console.SetCursorPosition(px, py + i);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("P");
                        Console.ResetColor();
                        Console.SetCursorPosition(px, py + i - 1);
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(px, py + QstackSkillDir + 1);
                    Console.Write("+");

                    Thread.Sleep((int)delay * 1000);
                    for (int i = 0; i < QstackSkillDir; i++)
                    {
                        Console.SetCursorPosition(px - 1, py + i);
                        Console.Write(" ");
                        Console.SetCursorPosition(px + 1, py + i);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Console.SetCursorPosition(px, py + QstackSkillDir + 1);
                    Console.Write(" ");
                    Qstack = 0;

                    py = py + QstackSkillDir - 1;
                }
                else // Q 스택이 2스택 이하일때
                {
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px, py + i);
                        Console.Write("+");
                        Thread.Sleep(20);
                    }
                    Thread.Sleep((int)delay * 1000);
                    for (int i = 1; i < skillDir + 1; i++)
                    {
                        Console.SetCursorPosition(px, py + i);
                        Console.Write(" ");
                        Thread.Sleep(20);
                    }
                    Qstack++;
                }
            }

            base.isDalay =false;
        }

        public override void WSkill()
        {
            skillKey = "W";
            SkillDataUpDate(); // W 스킬 데이터 넣기

            // 스킬을 쓴 플레이어의 위치에 파란색 P 출력
            Console.SetCursorPosition(px, py);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("P");
            Console.ResetColor();

            if (lastKey == "Left") // 왼쪽으로 이동하고 있었을 때
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px - i, py - j);
                        Console.Write("(");
                        Console.SetCursorPosition(px - i, py + j);
                        Console.Write("(");
                        Thread.Sleep(10);
                    }
                }
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px - i, py - j);
                        Console.Write(" ");
                        Console.SetCursorPosition(px - i, py + j);
                        Console.Write(" ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (lastKey == "Right") // 오른쪽으로 이동하고 있었을 때
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px + i, py - j);
                        Console.Write(")");
                        Console.SetCursorPosition(px + i, py + j);
                        Console.Write(")");
                        Thread.Sleep(10);
                    }
                }
                Console.ResetColor();
                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px + i, py - j);
                        Console.Write(" ");
                        Console.SetCursorPosition(px + i, py + j);
                        Console.Write(" ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (lastKey == "Up") // 윗쪽으로 이동하고 있었을 때
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px - j, py - i);
                        Console.Write(")");
                        Console.SetCursorPosition(px + j, py - i);
                        Console.Write(")");
                        Thread.Sleep(10);
                    }
                }
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px - j, py - i);
                        Console.Write(" ");
                        Console.SetCursorPosition(px + j, py - i);
                        Console.Write(" ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (lastKey == "Down") // 아랫쪽으로 이동하고 있었을 때
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
               for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px + j, py + i);
                        Console.Write("(");
                        Console.SetCursorPosition(px - j, py + i);
                        Console.Write("(");
                        Thread.Sleep(10);
                    }
                }
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 1; i < skillDir + 1; i++)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.SetCursorPosition(px + j, py + i);
                        Console.Write(" ");
                        Console.SetCursorPosition(px - j, py + i);
                        Console.Write(" ");
                        Thread.Sleep(10);
                    }
                }
            }
        }

        static bool isEState = false;
        static int Epx, Epy;
        public override void ESkill()
        {
            skillKey = "E";
            SkillDataUpDate(); // E 스킬 데이터 넣기

            if (!isEState)
            {
                if (lastKey == "Left")
                {
                    // 스킬을 쓴 플레이어의 오른쪽 위치에 파란색 P 출력
                    Console.SetCursorPosition(px + 1, py);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("P");
                    Console.ResetColor();
                    Epx = px + 1;
                    Epy = py;
                }
                else if (lastKey == "Right")
                {
                    // 스킬을 쓴 플레이어의 왼쪽 위치에 파란색 P 출력
                    Console.SetCursorPosition(px - 1, py);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("P");
                    Console.ResetColor();
                    Epx = px - 1;
                    Epy = py;
                }
                else if (lastKey == "Up")
                {
                    // 스킬을 쓴 플레이어의 왼쪽 위치에 파란색 P 출력
                    Console.SetCursorPosition(px, py + 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("P");
                    Console.ResetColor();

                    Epx = px;
                    Epy = py + 1;
                }
                else if (lastKey == "Down")
                {
                    // 스킬을 쓴 플레이어의 왼쪽 위치에 파란색 P 출력
                    Console.SetCursorPosition(px, py - 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("P");
                    Console.ResetColor();

                    Epx = px;
                    Epy = py- 1;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                isEState = true;
            }
            else
            {
                Console.ResetColor();
                px = Epx;
                py = Epy;
                isEState = false;
            }
        }

        static int RWhidthDir = 6;
        public override void RSkill()
        {
            skillKey = "R";
            SkillDataUpDate(); // R 스킬 데이터 넣기
            // 스킬을 쓴 플레이어의 위치에 파란색 P 출력
            Console.SetCursorPosition(px, py);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("P");
            Console.ResetColor();
            if (lastKey == "Left")
            {
                for(int i = 0; i < RWhidthDir; i++)
                {
                    for(int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - j, py - i + (RWhidthDir / 2));
                        Console.WriteLine("O");
                    }
                }
                Thread.Sleep(1000);
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(px - j, py - i + (RWhidthDir / 2));
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(px - skillDir, py);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("P");
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - j, py - i + (RWhidthDir / 2));
                        Console.WriteLine(" ");
                    }
                }
                px = px - skillDir;
            }
            else if (lastKey == "Right")
            {
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px + j, py - i + (RWhidthDir / 2));
                        Console.WriteLine("O");
                    }
                }
                Thread.Sleep(1000);
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(px + j, py - i + (RWhidthDir / 2));
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(px + skillDir, py);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("P");
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px + j, py - i + (RWhidthDir / 2));
                        Console.WriteLine(" ");
                    }
                }
                px = px + skillDir;
            }
            else if (lastKey == "Up")
            {
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py - j);
                        Console.WriteLine("O");
                    }
                }
                Thread.Sleep(1000);
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py - j);
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(px , py - skillDir);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("P");
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py - j);
                        Console.WriteLine(" ");
                    }
                }
                py = py - skillDir;
            }
            else if (lastKey == "Down")
            {
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py + j);
                        Console.WriteLine("O");
                    }
                }
                Thread.Sleep(1000);
                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py + j);
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(px, py + skillDir);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("P");
                Console.ResetColor();

                Thread.Sleep((int)delay * 1000); // 딜레이만큼 기다리기

                for (int i = 0; i < RWhidthDir; i++)
                {
                    for (int j = 0; j < skillDir; j++)
                    {
                        Console.SetCursorPosition(px - i + (RWhidthDir / 2), py + j);
                        Console.WriteLine(" ");
                    }
                }
                py = py + skillDir;
            }
        }

        public override void SkillDataUpDate()
        {
            int keySet = 0;
            switch(skillKey)
            {
                case "Q":
                    keySet = 0;
                    break;
                case "W":
                    keySet = 1;
                    break;
                case "E":
                    keySet = 2;
                    break;
                case "R":
                    keySet = 3;
                    break;
            }

            coolTime = skillData[keySet].coolTime;
            delay = skillData[keySet].delay;
            name = skillData[keySet].name;
            toolTip = skillData[keySet].toolTip;
            skillDir = skillData[keySet].skillDir;
            damage = skillData[keySet].damage;
        }

    }
}
