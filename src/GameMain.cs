using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 900, 650);
			GameResources.LoadResources ();
			MainMenuController myMenu = new MainMenuController ();
            GameController myGame = new GameController();
			SettingController mySetting = new SettingController ();
			UtilityFunction.gameStateStack.Push (GameState.ViewingMainPage);
			Page page = myMenu;
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				SwinGame.ProcessEvents ();
				SwinGame.ClearScreen (Color.White);
				GameState curPage = UtilityFunction.gameStateStack.Peek();
				switch (curPage) {
					case GameState.ViewingMainPage:
						page = myMenu;
                        myGame = new GameController();//clear game status
						break;
					case GameState.ViewingGamePage:
						page = myGame;
						break;
					case GameState.GameOverPage:
						myGame = new GameController ();
						page = myGame;
						break;
					case GameState.ViewingSettingPage:
					case GameState.ChangingDifficulty:
						page = mySetting;
						break;
					default:
						page = new MainMenuController();
						break;
				}
				page.Execute ();
				SwinGame.RefreshScreen (60);
				}

				SwinGame.DrawFramerate(0,0);

				//Draw onto the screen
				SwinGame.RefreshScreen(60);
        }
    }
}