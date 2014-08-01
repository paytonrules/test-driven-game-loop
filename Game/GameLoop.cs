using System;
using NUnit.Framework;

namespace MyGame
{
	public class GameLoop
	{
		public Game Game { get; protected set; }
		public GameLoop(Game game)
		{
			Game = game;
		}

		public void Run()
		{
			if (Game.Running) {
				Game.Update();
			}
		}
	}
}

