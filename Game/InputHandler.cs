using System;

namespace MyGame
{
	public interface InputHandler
	{
		InputState CurrentState { get; }
		void Poll();
	}
}