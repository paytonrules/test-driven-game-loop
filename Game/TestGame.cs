using System;
using NUnit.Framework;

namespace MyGame
{
	public class TestGame : Game
	{
		public bool Running {
			get;
			set;
		}

		public bool Updated {
			get;
			set;
		}

		public void Update() 
		{
			Updated = true;
		}
	}

}

