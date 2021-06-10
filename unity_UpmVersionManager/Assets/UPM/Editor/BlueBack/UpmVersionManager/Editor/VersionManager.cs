

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
{
	/** VersionManager
	*/
	public class VersionManager
	{
		/** MenuItem_OpenWindow
		*/
		[UnityEditor.MenuItem("BlueBack/VersionManager/Open")]
		private static void MenuItem_Open()
		{
			Window.OpenWindow();
		}

		/** MenuItem_OpenWindow
		*/
		[UnityEditor.MenuItem("BlueBack/VersionManager/Close")]
		private static void MenuItem_Close()
		{
			Window.CloseWindow();
		}
	}
}
#endif

