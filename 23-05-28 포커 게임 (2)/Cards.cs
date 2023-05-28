using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Cards
    {
        public static Card[] card = new Card[52]; // Card 52장 생성

        public Cards() { // Cards의 생성자 함수
            int checkNum = 0;
            int checkSuit = 0;
            for(int i = 0; i < card.Length; i++)
            {
                if(i % 13 == 0 && i != 0)
                {
                    checkNum = 0;
                    checkSuit++;
                }
                checkNum++;
                card[i].suit = (Suit)checkSuit;
                card[i].number = checkNum;
            }
        }

        public static void CheckCard()
        {
        }
        public static void Distribute() // 각 플레이어에게 카드 배분
        {
            Player[] player = new Player[4];
            player[0] = new Player(1);
            player[1] = new Player(2);
            player[2] = new Player(3);
            player[3] = new Player(4);
        }
        public static void ShowCards() // 카드를 보여주는 함수
        {
            for(int i  = 0; i < card.Length; i++)
            {
                Console.WriteLine(card[i].suit + "의" + card[i].number);
            }
        }
        public static void Shuffle()
        {
            Random random = new Random();
            for(int i=0; i < card.Length; i++)
            {
                int randomNum = random.Next(card.Length);
                
                Card temp = card[i];
                card[i] = card[randomNum];
                card[randomNum] = temp;
            }
        }
    }
}
