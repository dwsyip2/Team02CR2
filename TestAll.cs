using System;
using SwinGameSDK;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
namespace MyGame
{
	[TestFixture()]
	public class TestAll
	{
		[Test()]
		public void TestDefaultInitialization ()
		{
			GameBoard myDrawing = new GameBoard ();
			Assert.AreEqual (Color.DimGray, myDrawing.BackgroundColor);
		}

		[Test()]
		public void TestInitializeWithColor()
		{
			GameBoard myDrawing = new GameBoard (Color.Blue); 
			Assert.AreEqual (Color.Blue, myDrawing.BackgroundColor);
		}

		[Test()]
		public void TestSpawnVehicle()
		{
			GameBoard gb = new GameBoard (); 
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard.Initialize(0, 3, 1, "Peak Hours");
			Car c = new Car (415, 20);
			Lorry l = new Lorry (415, 20);
			Motorcycle m = new Motorcycle (415, 20);
			Fuel f = new Fuel (415, 20);

			gb.RandomSpawnVehicle (c);
			Assert.AreEqual (22.5, c.Y);
		}

		[Test()]
		public void TestDrop()
		{
			GameBoard gb = new GameBoard (); 
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard.Initialize(0, 3, 1, "Peak Hours");
			Car c = new Car (415, 20);
			Lorry l = new Lorry (415, 20);
			Motorcycle m = new Motorcycle (415, 20);
			Fuel f = new Fuel (415, 20);


			while (gb.Spawned == false)
			{
				gb.RandomSpawnVehicle (c);
			}

			Assert.AreEqual (620 ,c.Y);				

		}

		[Test()]
		public void TestNagivate()
		{
			GameBoard gb = new GameBoard (); 
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard.Initialize (0, 0, 1, "Peak Hours");
			Car c = new Car (415, 20);
			Lorry l = new Lorry (415, 20);
			Motorcycle m = new Motorcycle (415, 20);
			Fuel f = new Fuel (415, 20);

			//right
			p.NavigateRight ();
			Assert.AreEqual (510, p.X);
			//middle
			p.NavigateLeft ();
			Assert.AreEqual (415, p.X);
			//left
			p.NavigateLeft ();
			Assert.AreEqual (320, p.X);

		}

		[Test()]
		public void Testspeed()
		{
			GameBoard gb = new GameBoard (); 
			Stopwatch s1 = Stopwatch.StartNew(); 
			s1.Start ();
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard.Initialize(0, 0, 1, "Peak Hours");
			Car c = new Car (415, 20);
			Lorry l = new Lorry (415, 20);
			Motorcycle m = new Motorcycle (415, 20);
			Fuel f = new Fuel (415, 20);

	
				gb.RandomSpawnVehicle (c);
	
			Assert.AreEqual (2.5 ,c.SpeedY);			
		}

		[Test()]
		public void TestgameOver()
		{
			GameBoard gb = new GameBoard ();
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard.Initialize(0, 0, 1, "Peak Hours");
			Car c = new Car (415, 20);
			Lorry l = new Lorry (415, 20);
			Motorcycle m = new Motorcycle (415, 20);
			Fuel f = new Fuel (415, 20);

			if (gb.GameOver() == true)
			{
				ScoreBoard.Life = 3;
				ScoreBoard.Score = 1;
			}


			Assert.AreEqual (3 ,ScoreBoard.Life);	

		}


	}
}

