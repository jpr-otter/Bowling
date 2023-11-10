namespace bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nLet's roll!\n");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("__________________________________________________");
            var Game = new Game();
            Game.AddRoll(1);
            Game.AddRoll(4);

            Game.AddRoll(4);
            Game.AddRoll(5);

            Game.AddRoll(6);
            Game.AddRoll(4); //spare

            Game.AddRoll(5);
            Game.AddRoll(5);

            Game.AddRoll(10); // strike

            Game.AddRoll(0);
            Game.AddRoll(1);

            Game.AddRoll(7);
            Game.AddRoll(3);

            Game.AddRoll(6);
            Game.AddRoll(4);

            Game.AddRoll(10); // strike

            Game.AddRoll(2);
            Game.AddRoll(8); //spare
            Game.AddRoll(6);
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Game Over");

            
            
            //var Game2 = new Game();

            //for (int i = 0; i <= 10; i++)
            //{
            //    Game2.AddRoll(10);
            //}
            //Console.WriteLine("Game Over");

            //while (!Game.Over())
            //{

            //    Random random = new();
            //    int maxPins = 10;
            //    if (Game.CurrentFrame().PinsRolled[0] != 0)
            //    {
            //        maxPins = 10 - Game.CurrentFrame().PinsRolled[0];
            //    }
            //    int pins = random.Next(0, maxPins + 1);
            //    Game.AddRoll(pins);

            //    Game.AddRoll(10);

            //}
            Console.WriteLine($"Total score: {Game.TotalScore()}");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("__________________________________________________");
            //Console.WriteLine($"Total score Game Two: {Game2.TotalScore()}");
        }
    }
}