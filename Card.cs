using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    // Card.cs의 내부
    public enum Suit { S, D, H, C } // 스페이드, 하트 등 카드 문양을 담은 열거형 데이터 Suit

    public struct Card // 카드 한장의 구조체 Card
    {
        public Suit suit; // 카드 문양 데이터
        public int number; // 카드 숫자 데이터
    }
}
