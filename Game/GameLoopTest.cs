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
			game.EnqueRunningAnswers(false);

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsFalse(game.Updated);
		}

		[Test]
		public void ItRunsUpdateOnceBeforeTheGameIsStopped()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.IsTrue(game.Updated);
		}

		[Test]
		public void ItUpdatesUntilTheGameIsStopped()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, true, false);

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.AreEqual(2, game.UpdateCount);
		}

		[Test]
		public void ItRunsADrawAfterUpdate()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);

			var gameLoop = new GameLoop(game);

			gameLoop.Run();

			Assert.AreEqual(1, game.DrawCount);
		}

		// Input
		[Test]
		public void ItPassesTheInputResultsToUpdate()
		{
			var game = new TestGame();
			var inputHandler = new StubInputHandler();
			var inputState = new InputState();
			inputHandler.ReturnedInput = inputState;

			var gameLoop = new GameLoop {
				Game = game,
				InputHandler = inputHandler
			};

			gameLoop.Run();

			// Note ARe SAME not EQUAL
			Assert.AreSame(inputState, game.UpdatedWith);
		}
		// Fixed Update Step
	}
}


