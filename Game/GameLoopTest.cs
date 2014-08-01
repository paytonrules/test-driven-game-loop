using System;
using NUnit.Framework;
using System.Collections.Generic;

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

		static public bool RunningDelegate() 
		{
			var queue = new Queue<bool>();
			queue.Enqueue(true);
			queue.Enqueue(true);
			queue.Enqueue(false);

			return queue.Dequeue();
		}

		[Test]
		public void ItUpdatesUntilTheGameIsStopped()
		{
			var game = new TestGame();
			game.RunningDelegate = RunningDelegate;
			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.AreEqual(2, game.UpdateCount);
		}
	}
}


