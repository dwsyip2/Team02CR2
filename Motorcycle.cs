using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Motorcycle:Obstacle
	{
		//private double _speed; 
		public Motorcycle (double x,double y):base(x,y)
		{
			_speedY = 2.5;
			_lifeCount = -1;
		}

		public override void Draw ()
		{
			SwinGame.DrawBitmap ("motorcycle.png", (float)X, (float)Y);
		}

		public ObstacleType getType {
			get { return ObstacleType.Motorcycle; }
		}
	}
}

