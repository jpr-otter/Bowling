using System;


namespace bowling
{
	public class Frame
	{
		
		public int[] PinsRolled { get; set; }
		public int Score { get; set; }
		
		public Frame()
		{
			//Console.WriteLine("Let's roll!");
			Score = 0;
			PinsRolled = new int[2];
			
		}
	}
}