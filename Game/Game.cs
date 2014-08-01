using System;

namespace MyGame
{
	public interface Game
	{
		bool Running { get; }
		void Update();
	}
}

