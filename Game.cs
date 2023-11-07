using System;
namespace bowling
{
    public class Game
    {
        private readonly Frame[] Frames = new Frame[10];
        private int currentFrame;
        

        public Game()
        {
            for (int i = 0; i < Frames.Length; i++)
            {
                Frames[i] = new Frame();
            }
        }

        public void AddRoll(int pins)
        {
            if (currentFrame >= Frames.Length)
            {
                Console.WriteLine("Game over");
                return;
            }

            Frame frame = Frames[currentFrame];
            if (frame.PinsRolled[0] == 0)
            {
                frame.PinsRolled[0] = pins;
                frame.Score += pins;
                Console.WriteLine($"First Roll: {pins}");
            }
            else if (frame.PinsRolled[1] == 0)
            {
                if (frame.PinsRolled[0] + pins > 10)
                {
                    Console.WriteLine("Invalid roll. The total pins knocked down in a frame cannot exceed 10.");
                    return;
                }
                frame.PinsRolled[1] = pins;
                frame.Score += pins;
                Console.WriteLine($"Second Roll: {pins}");
                Console.WriteLine($"Frame {currentFrame + 1} score: {frame.Score}");

                if (currentFrame > 0 && Frames[currentFrame - 1].PinsRolled[0] == 10)
                {
                    Frames[currentFrame - 1].Score += pins;
                    Console.WriteLine($"Previous frame was a strike! Adding {pins} points to previous frame's score.");
                }
                currentFrame++;
            }
            Console.WriteLine($"Total score: {TotalScore()}");
        }        

        public int TotalScore()
        {   
            // mit for loop sonst 
            return Frames.Sum(x => x.Score);
        }

        public bool Over()
        {
            return currentFrame >= Frames.Length;
        }
    }

}

