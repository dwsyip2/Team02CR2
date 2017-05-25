using System;
using SwinGameSDK;
using System.Diagnostics;

namespace MyGame
{
	public static class ScoreBoard
	{
		private static int _score, _stage;
		private static int _life;
		private static string _traffic;

		public static void Initialize (int score, int life, int stage, string traffic)
		{
			_score = score;
			_life = life;
			_stage = stage;
			_traffic = traffic;
		}
		public static void Increment()
		{
			_life++;
		}

		public static void Decrement()
		{
			_life--;
		}

		public static void NextStage()
		{
			_stage++;
		}
			
		public static string Traffic
		{
			get{ return _traffic;}
			set{ _traffic = value;}
		}

		public static int Score
		{
			get{ return _score;}
			set{ _score = value;}
		}
		public static int Life
		{
			get{ return _life;}
			set{ _life = value;}
		}
		public static int Stage
		{
			get{ return _stage;}
			set{ _stage = value;}
		}
	}
}

