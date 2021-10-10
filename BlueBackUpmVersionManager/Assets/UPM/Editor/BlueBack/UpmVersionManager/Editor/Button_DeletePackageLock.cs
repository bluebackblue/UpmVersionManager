

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ウィンドウ。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Window
	*/
	public static class Button_DeletePacakgeLock
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[DeletePacakgeLock]";
				a_button.clickable.clicked += () => {
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("DeletePacakgeLock");
					#endif
					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			BlueBack.AssetLib.Editor.DeleteFile.TryDeleteFileFromAssetsPath("../Packages/packages-lock.json");
		}
	}
}
#endif

