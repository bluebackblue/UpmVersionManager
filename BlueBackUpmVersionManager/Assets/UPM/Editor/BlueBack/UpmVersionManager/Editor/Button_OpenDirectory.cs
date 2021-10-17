

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ボタン。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Button_OpenDirectory
	*/
	public static class Button_OpenDirectory
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[OpenDirectory]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
				DebugTool.Log("OpenDirectory");
				#endif

				Object_Setting.s_projectparam = ProjectParam.Load();
				if(Object_RootServerJson.s_status == null){
					Object_RootServerJson.Load();
				}

				On();
			};
		}

		/** On
		*/
		private static void On()
		{
			System.Diagnostics.Process.Start("explorer","/select," + (UnityEngine.Application.dataPath + "/../").Replace("/","\\"));
		}
	}
}
#endif

