using System;

namespace MyGame
{
	public class StubInputHandler : InputHandler
	{
		protected bool InputIsReady;
		public InputState ReturnedInput { get; set; }
		public InputState CurrentState { 
			get { 
				if (InputIsReady) {
					InputIsReady = false;
					return ReturnedInput;
				}
				return null;
			}
		}

		public StubInputHandler()
		{
			InputIsReady = false;
		}

		public void Poll()
		{
			InputIsReady = true;
		}
	}
}

