namespace bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Let's roll!");
            
            var Game = new Game();
            //Game.AddRoll(1);
            //Game.AddRoll(4);
            //Game.AddRoll(4);
            //Game.AddRoll(5);
            //Game.AddRoll(6);
            //Game.AddRoll(4);
            //Game.AddRoll(5);
            //Game.AddRoll(5);
            //Game.AddRoll(10);
            //Game.AddRoll(0);
            //Game.AddRoll(1);
            //Game.AddRoll(7);
            for (int i = 1; i <= 10; i++)
            {
                Game.AddRoll(10);
            }
            //Game.AddRoll(10);
            //Game.AddRoll(10);
            //Game.AddRoll(5);

            
           


            //while (!Game.Over())
            //{
                
            //    //Random random = new();
            //    //int maxPins = 10;  
            //    //if (Game.CurrentFrame().PinsRolled[0] != 0)
            //    //{
            //    //    maxPins = 10 - Game.CurrentFrame().PinsRolled[0];
            //    //}
            //    //int pins = random.Next(0, maxPins + 1);
            //    //Game.AddRoll(pins);
                
            //    Game.AddRoll(10);
              
            //}
            Console.WriteLine("Game Over");
            Console.WriteLine($"Total score: {Game.TotalScore()}");
            //Console.WriteLine($"Current Frame: {Game.Number}");
            //Console.WriteLine($"Bonus Score: {Game.BonusScore}");
            //Console.WriteLine($"FirstRoll Score: {frame.FirstRoll}");

        }
    }
}