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
			var game = new TestGame();
			game.RunningDelegate = () => {
				return false;
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsFalse(game.Updated);
		}

		[Test]
		public void ItRunsUpdateOnceBeforeTheGameIsStopped()
		{
			var game = new TestGame();
			var queue = new Queue<bool>();
			queue.Enqueue(true);
			queue.Enqueue(false);
			game.RunningDelegate = () => {
				return queue.Dequeue();
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsTrue(game.Updated);
		}

		[Test]
		public void ItUpdatesUntilTheGameIsStopped()
		{
			var game = new TestGame();
			var queue = new Queue<bool>();
			queue.Enqueue(true);
			queue.Enqueue(true);
			queue.Enqueue(false);
			game.RunningDelegate = () => {
				return queue.Dequeue();
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.AreEqual(2, game.UpdateCount);
		}

		[Test]
		public void ItRunsADrawAfterUpdate()
		{
			var game = new TestGame();
			var queue = new Queue<bool>();
			queue.Enqueue(true);
			queue.Enqueue(false);
			game.RunningDelegate = () => {
				return queue.Dequeue();
			};

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.AreEqual(1, game.DrawCount);
		}
	}
}


