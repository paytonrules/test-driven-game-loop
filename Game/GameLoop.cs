using System;
using NUnit.Framework;

namespace MyGame
{
	public class GameLoop
	{
		public Game Game { get; set; }
		public InputHandler InputHandler { get; set; }

		public GameLoop() 
		{
		}

		public GameLoop(Game game)
		{
			Game = game;
		}

		public void Run()
		{
			while (Game.Running) {
				Game.Update(new InputState());
				Game.Draw();
			}
		}
	}
}

