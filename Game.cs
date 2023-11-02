using System;
namespace bowling
{
    public class Game
    {
        private readonly Frame[] Frames = new Frame[10];
        private int currentFrame;
        

        public Game()
        {  
        }

        public void AddRoll(int pins)
        {
            Frame frame = Frames[currentFrame];
            frame.PinsRolled.Append(pins);

            if (Over())
            {
                Console.WriteLine("Game over");
            }
            
        }        

        public int TotalScore()
        {   
            // mit for loop sonst 
            return Frames.Sum(x => x.Score);
        }
        
        public bool Over() 
        {
            if (1==1)
            return true;
        }
    }

}

