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
            Frames[currentFrame].AddRoll(pins);
            Console.WriteLine($"Current Frame: {currentFrame}");
            if ((Frames[currentFrame].IsStrike() && Frames[currentFrame].Number != 10) || Frames[currentFrame].CurrentTry == 2)
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
                Console.WriteLine(frame.Score());
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

