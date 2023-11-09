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
                Frames[i] = new Frame(i + 1);
                if ( i > 0 )
                {
                    Frames[i].PreviousFrame = Frames[i - 1];   
                }

            }
        }
              
        public void AddRoll (int pins)
        {
            Frames[currentFrame].AddRoll(pins);
            Console.WriteLine($"Current Frame: {currentFrame}");
            if (Frames[currentFrame].IsStrike() || Frames[currentFrame].CurrentTry == 2)
            {
                currentFrame++;
            }
            //if (Frames[currentFrame].FirstRoll != -1 && Frames[currentFrame].SecondRoll != -1)
            //{
            //    currentFrame++;
            //}
        }        

        public Frame CurrentFrame()
        {            
            return Frames[currentFrame];
        }                   

        public int TotalScore()
        {
            int totalScore = 0;
            foreach ( Frame frame in Frames )
            {
                totalScore += frame.FrameScore();
                Console.WriteLine(frame.FrameScore());
            }
            // Lambda, sonst forloop 
            //return Frames.Sum(x => x.Score);
            return totalScore;
        }

        public bool Over()
        {
            return currentFrame >= Frames.Length ;
        }
    }
}

