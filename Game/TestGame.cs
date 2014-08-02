using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace MyGame
{
	public class InvalidDrawException : Exception
	{
	}

	public class TestGame : Game
	{
		public TestGame()
		{
			UpdateCount = 0;
		}

		public int UpdateCount { get; private set; }
		public int DrawCount { get; private set; }
		protected Queue<bool> runningAnswers;

		public bool Updated { 
			get { 
				return UpdateCount > 0;
			}
		}

		public bool Running 
		{
			get {
				return runningAnswers.Dequeue();
			}
		}

		public void Update() 
		{
			UpdateCount++;
		}

		public void Draw()
		{
			if (DrawCount != (UpdateCount - 1))
				throw new InvalidDrawException();

			DrawCount++;
		}
			
		public void EnqueRunningAnswers(params bool[] answers)
		{
			runningAnswers = new Queue<bool>();
			foreach (var answer in answers) {
				runningAnswers.Enqueue(answer);
			}
		}
	}
}