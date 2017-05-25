using System;
using SwinGameSDK;

namespace MyGame
{
	public class PlayerVehicle
	{
		double _x, _y, _acc, _spdX, _spdY;

		public DateTime _prevTime;
		public DateTime _curTime;

		public PlayerVehicle(double x,double y)
		{
			_x = x;
			_y = y;
			_spdX = 500;
			_spdY = 500;
			_acc = 1000;
			_prevTime = DateTime.Now;
			_curTime = DateTime.Now;
		}

		public void UpdateTime ()
		{
			_prevTime = _curTime;
			_curTime = DateTime.Now;
			_spdX = 500;
			_spdY = 500;
		}
		//Move up
		public void NavigateUp ()
		{
			if (Y > 90) {
				_spdY += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
				Y -= _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedY;
			}
		}

		//Move Down
		public void NavigateDown ()
		{
			if (Y < 530) {
				_spdY += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
				Y += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedY;
			}
		}
		public void NavigateLeft ()
		{
			if (X > 280)
			{
				_spdX += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
				X -= _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedX;
			}
		}

		public void NavigateRight ()
		{
			if (X < 530)
			{
				_spdX += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
				X += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedX;
			}
		}
			

		public void Draw ()
		{
			SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80); 
			SwinGame.DrawBitmap ("player.png", (float)X, (float)Y);
		}
			

		public double X
		{
			get{ return _x; }
			set{ _x = value; }

		}

		public double Y
		{
			get{ return _y; }
			set{ _y = value; }
		}

		public double SpeedX {
			get { return _spdX; }
			set { _spdX = value; }
		}

		public double SpeedY {
			get { return _spdY; }
			set { _spdY = value; }
		}

		public double Acceleration {
			get { return _acc; }
			set { _acc = value; }
		}

}
}

