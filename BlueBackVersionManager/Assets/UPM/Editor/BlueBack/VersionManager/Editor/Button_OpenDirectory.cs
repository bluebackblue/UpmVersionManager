

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
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
				#if(DEF_BLUEBACK_VERSIONMANAGER_LOG)
				DebugTool.Log("OpenDirectory");
				#endif

				Object_Setting.projectparam = ProjectParam.Load();
				if(Object_RootServerJson.status == null){
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

