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
        public Frame CurrentFrame()
        {
            return Frames[currentFrame];
        }

        public void AddRoll(int pins)
        {
            /*
            
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
            
            
            if (currentFrame >= Frames.Length)
            {
                //Console.WriteLine("Game over");
                if (Frames[Frames.Length - 1].PinsRolled[0] == 10 && Frames[Frames.Length - 1].PinsRolled[1] == 10)
                {
                    // Wenn der letzte Frame ein perfekter Frame war, fügen Sie die Punkte des letzten Wurfs zur Gesamtpunktzahl hinzu
                    Frames[Frames.Length - 1].Score += pins;
                    Console.WriteLine("Perfect frame! Adding points to last frame's score.");
                }
                Console.WriteLine("Game over");
                Console.WriteLine($"Total score: {TotalScore()}");
                return;
            }
            */

            Frame frame = Frames[currentFrame];

            if (frame.PinsRolled[0] == 0)
            {
                frame.PinsRolled[0] = pins;
                frame.Score += pins; // Aktualisiert die Punktzahl
                Console.WriteLine($"First roll: {pins}");
                Console.WriteLine($"Frame {currentFrame + 1} score: {frame.Score}");
                if (pins == 10) // Strike
                {
                    Console.WriteLine("Strike!");
                    if (currentFrame > 0 && Frames[currentFrame - 1].PinsRolled[0] == 10) // Double
                    {
                        Frames[currentFrame - 1].Score += pins;
                        Console.WriteLine("Double!");
                        if (currentFrame > 1 && Frames[currentFrame - 2].PinsRolled[0] == 10) // Turkey
                        {
                            Frames[currentFrame - 2].Score += pins;
                            Console.WriteLine("Turkey!");
                        }
                    }
                    currentFrame++;
                }
            }

            else if (frame.PinsRolled[1] == 0)
            {
                frame.PinsRolled[1] = pins;
                frame.Score += pins; // Aktualisiert die Punktzahl
                Console.WriteLine($"Second roll: {pins}");
                Console.WriteLine($"Frame {currentFrame + 1} score: {frame.Score}");

                if (frame.PinsRolled[0] + pins == 10) // Spare
                {
                    Console.WriteLine("Spare!");
                }
                Console.WriteLine($"Frame {currentFrame + 1} score: {frame.Score}");

                // Überprüft ob der vorherige Wurf ein Spare war
                if (currentFrame > 0 && Frames[currentFrame - 1].PinsRolled[0] + Frames[currentFrame - 1].PinsRolled[1] == 10)
                {
                    Frames[currentFrame - 1].Score += pins;
                    Console.WriteLine("Adding points to previous frame's score due to spare.");
                }

                if (currentFrame == Frames.Length - 1 && (frame.PinsRolled[0] == 10 || frame.PinsRolled[0] + frame.PinsRolled[1] == 10)) // Last frame and it's a strike or a spare
                {
                    
                    return; // Do not increment currentFrame to allow a third roll
                }

                currentFrame++;
            }
            else // Third roll in the last frame
            {
                frame.PinsRolled[2] = pins;
                frame.Score += pins;
                Console.WriteLine($"Third roll: {pins}");
                Console.WriteLine($"Frame {currentFrame + 1} score: {frame.Score}");
                currentFrame++;
            }
            Console.WriteLine($"Total score: {TotalScore()}");

            
        }            

        public int TotalScore()
        {
            int totalScore = 0;
            foreach ( var pin in Frames )
            {
                totalScore += pin.Score;
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

