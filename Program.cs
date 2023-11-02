namespace bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Let's roll!");
            
            var Game = new Game();
            while (!Game.Over())
            {
                Random rando = new();
                int pins = rando.Next(0, 10);
                Game.AddRoll(pins);

            }
        }
    }
}