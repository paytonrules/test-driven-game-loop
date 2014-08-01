using System;
using NUnit.Framework;

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
		public bool Updated { 
			get { 
				return UpdateCount > 0;
			}
		}

		public bool Running 
		{
			get {
				return RunningDelegate();
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
			
		public Func<bool> RunningDelegate 
		{
			private get;
			set;
		}			
	}
}