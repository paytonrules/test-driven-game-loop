using System;
using NUnit.Framework;

namespace MyGame
{
	public class TestGame : Game
	{
		public TestGame()
		{
			UpdateCount = 0;
		}

		public bool Running 
		{
			get {
				return RunningDelegate();
			}
		}

		public bool Updated 
		{
			get;
			set;
		}

		public void Update() 
		{
			Updated = true;
			UpdateCount++;
		}

		public int UpdateCount 
		{
			get;
			set;
		}

		public Func<bool> RunningDelegate 
		{
			private get;
			set;
		}
			
	}
}

