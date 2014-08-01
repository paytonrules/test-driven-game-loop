using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture]
	public class GameLoopTest
	{
		[Test]
		public void ItDoesNothingWhenTheGameIsStopped()
		{
			var game = new TestGame();
			game.Running = false;

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsFalse(game.Updated);
		}
	}
}

