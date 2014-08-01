using System;

namespace MyGame
{
	public interface Game
	{
		bool Running { get; set; }
		void Update();
	}
}

