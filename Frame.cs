using System;


namespace bowling
{
	public class Frame
	{
		
		public int[] PinsKnockedDown { get; set; }
		public int Score { get; set; }
		private int Number { get; set; }

		
		public Frame(int paraNumber)
		{
			//Console.WriteLine("Let's roll!");
			Score = 0;
			PinsKnockedDown = new int[] { -1, -1, -1};
			Number = paraNumber;
			
		}
		public bool IsStrike()
		{
			return PinsKnockedDown[0] == 10;			
		}
		public bool IsSpare()
		{
			return PinsKnockedDown[0] + PinsKnockedDown[1] == 10;
		}
		public void addRoll()
		{

		}
	}
}