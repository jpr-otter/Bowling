using System;
namespace bowling
{
    public class Game
    {
        private readonly Frame[] Frames = new Frame[10];
        private int currentFrame;


        public Game()
        {
            for (int i = 9; i >= 0; i--)
            {
                Frames[i] = new Frame(i + 1);
                if (i < Frames.Length - 1)
                {
                    Frames[i].NextFrame = Frames[i + 1];
                }
            }
        }

        public void AddRoll(int pins)
        {
            var frame = Frames[currentFrame];
            frame.AddRoll(pins);

            Console.WriteLine($"Current Frame: {currentFrame}   |   Pins {pins}");
            
            if (frame.IsFinished())
            {
                currentFrame++;
            }

        }

        public Frame CurrentFrame()
        {
            return Frames[currentFrame];
        }

        public int TotalScore()
        {
            int totalScore = 0;
            foreach (Frame frame in Frames)
            {
                totalScore += frame.Score();
                Console.WriteLine("__________________________________________________");
                if(frame.Number < 10 && frame.Score() < 10)
                {
                    Console.WriteLine($"{frame.Number} - {frame.Score()}  | {totalScore}");
                }
                else
                {
                    Console.WriteLine($"{frame.Number} - {frame.Score()} | {totalScore}");
                }
                Console.WriteLine("__________________________________________________");

            }
            // Lambda, sonst forloop 
            //return Frames.Sum(x => x.Score);
            return totalScore;
        }

        public bool Over()
        {
            return currentFrame >= Frames.Length;
        }
    }
}

