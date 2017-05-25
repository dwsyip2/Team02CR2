using System;
namespace MyGame
{
	public abstract class Page
	{
		public abstract void DrawPage ();
		public abstract void HandleInput ();
		/// <summary>
		/// Insert drawpage and handle input function as minimum requirement.
		/// </summary>
		public abstract void Execute ();
	}
}
