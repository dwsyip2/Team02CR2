using System.Collections.Generic;
using SwinGameSDK;

public static class GameResources
{
	static Dictionary<string, Font> _Fonts = new Dictionary<string, Font> ();

	static void NewFont (string fontName, string filename, int size)
	{
		_Fonts.Add (fontName, SwinGame.LoadFont (SwinGame.PathToResource (filename, ResourceKind.FontResource), size));
	}

	static void LoadFonts ()
	{
		NewFont ("ArialLarge", "arial.ttf", 80);
		NewFont ("Courier", "cour.ttf", 14);
		NewFont ("CourierSmall", "cour.ttf", 8);
		NewFont ("Menu", "ffaccess.ttf", 8);
		NewFont ("New", "maven_pro_regular.ttf", 16);
	}

	public static void LoadResources ()
	{
		LoadFonts ();
	}

	public static Font GameFont (string font)
	{
		return _Fonts [font];
	}

}