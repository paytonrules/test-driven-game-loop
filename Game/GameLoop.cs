using System;
using NUnit.Framework;

namespace MyGame
{
	public class NullTimer : Timer
	{
		public float GetTime() {
			return 0;
		}
	}

	public class GameLoop
	{
		public Game Game { get; set; }
		public InputHandler InputHandler { get; set; }
		public Timer Timer { get; set; }

		public GameLoop()
		{
		}

		public GameLoop(Game game, InputHandler inputHandler) 
		{
			Game = game;
			InputHandler = inputHandler;
			Timer = new NullTimer();
		}

		public void Run()
		{
			var previousTime = Timer.GetTime();
			while (Game.Running) {
				var currentTime = Timer.GetTime();
				var lag = currentTime - previousTime;
				while (lag >= 0) {
					Game.Update(InputHandler.CurrentState);
					lag -= 16;
				}
				Game.Draw();
			}
		}
	}
}

