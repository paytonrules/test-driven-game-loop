using System;
using NUnit.Framework;

namespace MyGame
{
	public class GameLoop
	{
		const float DefaultFrameLength = (1.0f / 60.0f) * 1000;
		public Game Game { get; set; }
		public InputHandler InputHandler { get; set; }
		public Timer Timer { get; set; }
		public float FrameLength;

		public GameLoop()
		{
			FrameLength = DefaultFrameLength;
			InputHandler = new NullInputHandler();
		}
			
		public void Run()
		{
			var previousTime = Timer.GetTime();
			while (Game.Running) {
				var currentTime = Timer.GetTime();
				var lag = currentTime - previousTime;

				InputHandler.Poll();

				while (lag >= FrameLength) {
					Game.Update(InputHandler.CurrentState);
					lag -= FrameLength;
				}

				previousTime = currentTime;
				Game.Draw();
			}
		}
	}
}

