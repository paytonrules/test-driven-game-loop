using System;

namespace MyGame
{
	public class NullInputHandler : InputHandler
	{
		public InputState CurrentState { get { return new InputState(); } }
		public void Poll() {}
	}
}