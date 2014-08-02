using System;
using NUnit.Framework;

namespace MyGame
{
	public class NullInputHandler : InputHandler 
	{
		public InputState CurrentState { get { return new InputState(); }}
	}

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
			InputHandler = new NullInputHandler();
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

