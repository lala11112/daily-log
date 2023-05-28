using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public Card[] card = new Card[5];
        private int counter = 0;
        public int numCard;
        private int playerNo = 1;
        public int PlayerNo
        {
            get { return playerNo; } 
            set 
            {
                playerNo = value;
            }
        }
        public Player(int playerno)
        {
            this.playerNo = playerno;
            Console.WriteLine("플레이어" + PlayerNo + "의 카드");
            for (int i = 5 * (PlayerNo - 1); i < (5 * (PlayerNo - 1)) + 5; i++)
            {
                card[counter] = Cards.card[i];
                Console.Write(card[counter].suit + "의" + card[counter].number + " ");
                counter++;
            }
            Console.WriteLine();
            
        }
    }
}
