using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyGame
{
	public class NullInputHandler : InputHandler
	{
		public InputState CurrentState { get { return new InputState(); } }
		public void Poll() {}
	}

	public class FakeTimer : Timer
	{
		public Queue<float> Times { get; set; }

		public float GetTime() 
		{
			return Times.Dequeue();
		}
	}

	public class SecondTicker : Timer
	{
		float currentTime;

		public SecondTicker()
		{
			currentTime = 0.0f;
		}

		public float GetTime() 
		{
			var existingTime = currentTime;
			currentTime++;
			return existingTime;
		}
	}

	[TestFixture]
	public class GameLoopTest
	{
		[Test]
		public void ItDoesNothingWhenTheGameIsStopped()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(false);

			var gameLoop = new GameLoop {
				Game = game, 
				Timer = new SecondTicker()
			};

			gameLoop.Run();

			Assert.IsFalse(game.Updated);
		}

		[Test]
		public void ItRunsUpdateOnceBeforeTheGameIsStopped()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);

			var gameLoop = new GameLoop {
				Game = game,
				Timer = new SecondTicker(),
				FrameLength = 1
			};

			gameLoop.Run();

			Assert.IsTrue(game.Updated);
			Assert.AreEqual(1, game.UpdateCount);
		}

		[Test]
		public void ItUpdatesUntilTheGameIsStopped()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, true, false);

			var gameLoop = new GameLoop {
				Game = game,
				Timer = new SecondTicker(),
				FrameLength = 1.0f
			};

			gameLoop.Run();

			Assert.AreEqual(2, game.UpdateCount);
		}

		[Test]
		public void ItRunsADrawAfterUpdate()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);

			var gameLoop = new GameLoop { 
				Game = game,
				Timer = new SecondTicker(),
				FrameLength = 1
			};

			gameLoop.Run();

			Assert.AreEqual(1, game.DrawCount);
		}

		[Test]
		public void ItPassesTheInputResultsToUpdate()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);
			var inputHandler = new StubInputHandler();
			var inputState = new InputState();
			inputHandler.ReturnedInput = inputState;

			var gameLoop = new GameLoop {
				Game = game , 
				InputHandler = inputHandler, 
				Timer = new SecondTicker(),
				FrameLength = 1
			};

			gameLoop.Run();

			Assert.AreSame(inputHandler.ReturnedInput, game.UpdatedWith);
		}

		[Test]
		public void ItWillUpdateOneExtraTimeToCatchUpWhenTheLagIsTooLarge()
		{
			var game = new TestGame();
			game.EnqueRunningAnswers(true, false);
			var time = new FakeTimer();
			time.Times = new Queue<float>();
			time.Times.Enqueue(0);
			time.Times.Enqueue(2);

			var gameLoop = new GameLoop {
				Game = game,
				InputHandler = new NullInputHandler(),
				Timer = time, 
				FrameLength = 1
			};

			gameLoop.Run();

			Assert.AreEqual(2, game.UpdateCount);
			Assert.AreEqual(1, game.DrawCount);
		}
	}
}


