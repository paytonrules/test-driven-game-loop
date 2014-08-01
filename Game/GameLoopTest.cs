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
			var game = new TestGame {
				Running = false
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsFalse(game.Updated);
		}

		[Test]
		public void ItRunsUpdateOnceBeforeTheGameIsStopped()
		{
			var game = new TestGame {
				Running = true
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsTrue(game.Updated);
		}
	}
}

