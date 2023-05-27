namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Cards cards = new Cards();
            Cards.ShowCards();
            Console.WriteLine("---------- 섞어~ 섞어~ ----------");
            Cards.Shuffle();
            Cards.ShowCards();
        }
    }
}