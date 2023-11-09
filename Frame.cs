using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace bowling
{
	public class Frame
	{
		
		public int[] PinsKnockedDown { get; set; }
		public int Score { get; set; }
		public int Number { get; set; }
		public int BonusScore { get; set; }
		public int FirstRoll { get; set; }
		public int SecondRoll { get; set; }
		public int ThirdRoll { get; set; }
		public Frame PreviousFrame { get; set; }
		
		
		public Frame(int paraNumber)
		{
			FirstRoll = -1;
			SecondRoll = -1;
			ThirdRoll = -1;
			Score = 0;
			PinsKnockedDown = new int[] { FirstRoll, SecondRoll, ThirdRoll};
			Number = paraNumber;			
						
		}

		public int CurrentFrameIs() 
		{
			return Number;
		}

		// doesnt make any sense...
		//public int DoubleFrame() 
		//{
		//	return Number - 1;
		//}
		//public int FrameForTurkey()
		//{
		//	return Number - 2; 
		//}

		public bool IsStrike()
		{
			return PinsKnockedDown[0] == 10;			
		}

		public bool IsSpare()
		{
			return PinsKnockedDown[0] + PinsKnockedDown[1] == 10;
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
			if (PinsKnockedDown[0] == FirstRoll) 
			{
				PinsKnockedDown[0] = pins;
			}
			else if (PinsKnockedDown[1] == SecondRoll)
			{
				PinsKnockedDown[1] = pins;
			}
			else 
			{ 
				throw new Exception("Nur zwei Würfe zulässig"); 
			}
			if (Number == 10 && IsStrike())
			{
				PinsKnockedDown[2] = pins;
			}
			
		}  
		
        public int FrameScore()
		{
			if (PreviousFrame !=  null && PreviousFrame.IsSpare())
			{
				PreviousFrame.Score += PinsKnockedDown[0];
			}
			if (PreviousFrame != null && PreviousFrame.IsStrike())
			{
				PreviousFrame.Score += PinsKnockedDown[0] + PinsKnockedDown[1];
			}

			if (ThirdRoll != -1)
			{			
				return PinsKnockedDown[0] + PinsKnockedDown[1] + PinsKnockedDown[2]; 
			}
			else
			{
				return PinsKnockedDown[0] + PinsKnockedDown[1];
			}
			//???
		}

		//next steps: use the methods from framesClass.
		// how should i use those?
	}
}