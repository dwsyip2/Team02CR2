using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Lorry:Obstacle
	{
		//private double _speed; 
		public Lorry (double x,double y):base(x,y)
		{
			_speedY = 2.5;
			_lifeCount = -1;
		}

		public override void Draw ()
		{
			//SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80);  
			SwinGame.DrawBitmap ("lorry.png", (float)X, (float)Y);
		}

		public ObstacleType getType { 
			get { return ObstacleType.Lorry; }
		}
	}
}

