using System;

namespace MyGame
{
	public class StubInputHandler : InputHandler
	{
		public InputState ReturnedInput { get; set; }
		public InputState CurrentState { get { return ReturnedInput; }}

		public StubInputHandler()
		{
		}
	}
}

