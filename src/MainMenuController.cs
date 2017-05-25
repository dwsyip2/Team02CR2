using System;
using SwinGameSDK;
namespace MyGame
{
	public class MainMenuController:Page
	{
		const int ButtonX = 50;
		const int ButtonY = 150;
		const int Spacing = 5;
		const int ButtonWidth = 200;
		const int ButtonHeight = 50;
		string [] menu = {
			"Play",
			"High Score",
			"Setting",
			"Instruction",
		};

		public override void DrawPage ()
		{
			SwinGame.DrawBitmap ("bg.jpg", 0, 0);

			for(int i = 0; i < menu.Length ; i++) {
				SwinGame.FillRectangle (Color.White, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				if (UtilityFunction.IsMouseInRectangle (ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight, SwinGame.MousePosition ())) {
					if (SwinGame.MouseDown (MouseButton.LeftButton))
						SwinGame.FillRectangle(Color.GreenYellow, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
					else
						SwinGame.DrawRectangle (Color.Gold, ButtonX, ButtonY + (Spacing + ButtonHeight) * i, ButtonWidth, ButtonHeight);
				}
				SwinGame.DrawText (menu [i], Color.Black, ButtonX + 10 * Spacing, ButtonY + ButtonHeight / 2 + (Spacing + ButtonHeight) * i);
			}
		}

		public override void Execute ()
		{
			HandleInput ();
			DrawPage ();
		}

		public override void HandleInput ()
		{
			Point2D clicked = SwinGame.MousePosition ();
			if(GameState.ViewingMainPage == UtilityFunction.gameStateStack.Peek())
				HandleMenuInput ();
		}

		private void HandleMenuInput ()
		{
			for (int i = 0; i < menu.Length; i++) {
				if (SwinGame.MouseClicked (MouseButton.LeftButton)
				   && UtilityFunction.IsMouseInRectangle (ButtonX, ButtonY + (Spacing + ButtonHeight) * i,
														   ButtonWidth, ButtonHeight, SwinGame.MousePosition ()))
					PerformMenuAction (i);
			}
		}

		void PerformMenuAction (int button)
		{
			switch (button) {
			case 2:
				UtilityFunction.gameStateStack.Push (GameState.ViewingSettingPage);
				break;
			default:
				UtilityFunction.gameStateStack.Push (GameState.ViewingGamePage);
				break;
			}
		}
}
}
