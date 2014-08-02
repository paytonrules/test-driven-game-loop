using System;
using NUnit.Framework;

namespace MyGame
{
	public class GameLoop
	{
		public Game Game { get; set; }
		public InputHandler InputHandler { get; set; }

		public GameLoop(Game game, InputHandler inputHandler) 
		{
			Game = game;
			InputHandler = inputHandler;
		}

		public void Run()
		{
			while (Game.Running) {
				Game.Update(InputHandler.CurrentState);
				Game.Draw();
			}
		}
	}
}

