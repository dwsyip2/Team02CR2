using System;
using SwinGameSDK;

namespace MyGame
{
	public class SettingController:Page
	{
		const int ButtonX = 50;
		const int ButtonY = 150;
		const int Spacing = 5;
		const int ButtonWidth = 200;
		const int ButtonHeight = 50;
		string [] menu = {
			"Difficulty",
			"Maximum Obstacle",
			"Sound / Music",
		};
		string [][] secondLevelList = {
			new string[]{
			"Easy",
			"Medium",
			"Hard",
			"Extreme"
			}
		};

		public override void DrawPage ()
		{
			SwinGame.DrawBitmap ("bg.jpg", 0, 0);
			for (int i = 0; i < menu.Length; i++) {
				SwinGame.FillRectangle (Color.Yellow, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				if (UtilityFunction.IsMouseInRectangle (ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight, SwinGame.MousePosition ())) {
					if (SwinGame.MouseDown (MouseButton.LeftButton))
						SwinGame.FillRectangle (Color.GreenYellow, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
					else
						SwinGame.DrawRectangle (Color.Gold, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				}
				SwinGame.DrawText (menu [i], Color.Black,ButtonX + 10 * Spacing, ButtonY + ButtonHeight / 2 + (Spacing + ButtonHeight) * i);
			}
		}

		public override void Execute ()
		{
			DrawPage ();
			if (UtilityFunction.gameStateStack.Peek () == GameState.ChangingDifficulty) 
				DrawSecondLevelButtons (0);
			HandleInput ();
		}

		void HandleSettingButtonInput ()
		{
			for (int i = 0; i < menu.Length; i++) {
				if (SwinGame.MouseClicked (MouseButton.LeftButton)
				   && UtilityFunction.IsMouseInRectangle (ButtonX, ButtonY + (Spacing + ButtonHeight) * i,
														   ButtonWidth, ButtonHeight, SwinGame.MousePosition ())) {
					PerformSettingAction (i);
				}
			}
		}

		void PerformSettingAction (int button)
		{
			switch (button) {
			case 0:
				UtilityFunction.gameStateStack.Push (GameState.ChangingDifficulty);
				break;
			default:
				break;
			}
		}

		void DrawSecondLevelButtons (int row)
		{
			UtilityFunction.gameStateStack.Push (GameState.ChangingDifficulty);
			int Level = 1;
			for (int i = 0; i < secondLevelList[row].Length; i++) {
				SwinGame.FillRectangle (Color.LightYellow, ButtonX + (Spacing + ButtonWidth) * (Level), ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				if (UtilityFunction.IsMouseInRectangle (ButtonX + (Spacing + ButtonWidth) * (Level), ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight, SwinGame.MousePosition ())) {
					if (SwinGame.MouseDown (MouseButton.LeftButton))
						SwinGame.FillRectangle (Color.GreenYellow, ButtonX + (Spacing + ButtonWidth) * (Level), ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
					else
						SwinGame.DrawRectangle (Color.Gold, ButtonX + (Spacing + ButtonWidth) * (Level), ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				}
				SwinGame.DrawText (secondLevelList [row][i], Color.Black, ButtonX + 10 * Spacing + (Spacing + ButtonWidth) * (Level) , ButtonY + ButtonHeight / 2 + (Spacing + ButtonHeight) * i);
			}
		}


		void HandleDifficultyButtonInput ()
		{
			int Level = 1;
			for (int i = 0; i < secondLevelList [0].Length; i++) {
				if (SwinGame.MouseClicked (MouseButton.LeftButton)
				    && UtilityFunction.IsMouseInRectangle (ButtonX + (Spacing + ButtonWidth) * (Level), ButtonY + (Spacing + ButtonHeight) * i,
														   ButtonWidth, ButtonHeight, SwinGame.MousePosition ())) {
					PerformDifficultyChanges (i);
					break;
				}
			}
			while(UtilityFunction.gameStateStack.Peek() == GameState.ChangingDifficulty)
			UtilityFunction.gameStateStack.Pop ();
		}

		void PerformDifficultyChanges (int button)
		{
			switch (button) {
			case 0:
				UtilityFunction.currentDifficulty = GameDifficulty.Easy;
				break;
			case 1:
				UtilityFunction.currentDifficulty = GameDifficulty.Medium;
				break;
			case 2:
				UtilityFunction.currentDifficulty = GameDifficulty.Hard;
				break;
			case 3:
				UtilityFunction.currentDifficulty = GameDifficulty.Extreme;
				break;
			default:
				break;
			}
		}

		public override void HandleInput ()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (UtilityFunction.gameStateStack.Peek () == GameState.ViewingSettingPage)
					HandleSettingButtonInput ();
				else if (UtilityFunction.gameStateStack.Peek () == GameState.ChangingDifficulty)
					HandleDifficultyButtonInput ();
			}
			if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE))
				UtilityFunction.gameStateStack.Pop ();
		}
	}
}
