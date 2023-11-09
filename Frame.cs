using System;

namespace bowling
{
	public class Frame
	{		
		public int Number { get; set; }
		public int BonusScore { get; set; }
		public int FirstRoll { get; set; }
		public int SecondRoll { get; set; }
		public int ThirdRoll { get; set; }
		public Frame PreviousFrame { get; set; }
		public int CurrentTry {  get; set; }
		
		public Frame(int paraNumber)
		{
			FirstRoll = 0;
			SecondRoll = 0;
			ThirdRoll = -1;			
			Number = paraNumber;
			CurrentTry = 0;
		}

		public int CurrentFrame() 
		{			
			return Number;
		}		

		

		public bool IsStrike()
		{			
			return FirstRoll == 10;			
		}

		public bool IsSpare()
		{
			return FirstRoll + SecondRoll == 10;
		}

		public bool IsDouble()
		{
			return IsStrike() && PreviousFrame != null && PreviousFrame.IsStrike();		
		}

		public bool IsTurkey()
		{
			_ = PreviousFrame;
			Frame twoFramesBefore = PreviousFrame.PreviousFrame;
			return PreviousFrame != null && IsStrike() && PreviousFrame.IsStrike() && twoFramesBefore != null && twoFramesBefore.IsStrike();

		}

		public void AddRoll(int pins)
		{
			if (CurrentTry == 0) 
			{
				FirstRoll = pins;
				CurrentTry++;
			}
			else if (CurrentTry == 1)
			{
				SecondRoll = pins;
				CurrentTry++;
			}			
			else 
			{                
                throw new Exception("Nur zwei Würfe zulässig"); 
			}
			if (Number == 10 && IsStrike())
			{
				ThirdRoll = pins;
			}
			
		}  
		
        public int FrameScore()
		{
			if (PreviousFrame != null)
			{
				BonusScore = PreviousFrame.FrameScore();
			}
			else BonusScore = 0;	
			
			if (PreviousFrame !=  null && PreviousFrame.IsSpare())
			{
				
				BonusScore += FirstRoll;
			}

			if (PreviousFrame != null && PreviousFrame.IsStrike())
			{
				
                BonusScore += FirstRoll + (CurrentTry < 1 ? SecondRoll : 0);
            }

			if (ThirdRoll != -1)
			{			
				return FirstRoll + SecondRoll + ThirdRoll + BonusScore; 
			}
			else
			{
				return FirstRoll + SecondRoll + BonusScore;
			}			
		}

		public int Score()
		{
            if (ThirdRoll != -1)
            {
                return FirstRoll + SecondRoll + ThirdRoll + BonusScore;
            }
            else
            {
                return FirstRoll + SecondRoll + BonusScore;
            }
        }

		//next steps: use the methods from framesClass.
		// how should i use those?
	}
}