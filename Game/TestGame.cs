using System;
using NUnit.Framework;

namespace MyGame
{
	public delegate bool Running();
	public class TestGame : Game
	{
		public TestGame()
		{
			UpdateCount = 0;
		}

		public bool Running 
		{
			get;
			set;
		}

		public Running RunningDelegate 
		{
			private get;
			set;
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
	}
}

