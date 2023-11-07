using System;


namespace bowling
{
	internal class Frame
	{
		
		public int[] PinsRolled;
		public int Score;
		
		public Frame()
		{
			//Console.WriteLine("Let's roll!");
			Score = 0;
			PinsRolled = new int[10];
			
		}
	}
}