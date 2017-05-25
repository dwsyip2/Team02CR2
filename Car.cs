using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Car:Obstacle
	{
		public Car (double x,double y):base(x,y)
		{
			_lifeCount = -1;
		}

		public override void Draw ()
		{
				//SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80); 
				SwinGame.DrawBitmap ("car.png", (float)X, (float)Y);
		}

		public ObstacleType getType {
			get { return ObstacleType.Car; }
		}
	}
}

