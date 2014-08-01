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
			while (Game.Running) {
				Game.Update();
				Game.Draw();
			}
		}
	}
}

