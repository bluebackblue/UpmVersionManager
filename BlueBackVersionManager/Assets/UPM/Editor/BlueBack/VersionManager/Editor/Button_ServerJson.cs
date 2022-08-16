

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
	/** Button_ServerJson
	*/
	public static class Button_ServerJson
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(Object_RootServerJson.status != null){
				a_button.text = Object_RootServerJson.status.lasttag;
			}

			a_button.AddToClassList("red");

			a_button.clickable.clicked += () => {

				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log("ServerJson");
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
			Object_RootServerJson.DownloadAndSave();
			Object_RootServerJson.Load();
			Window.window.OnEnable();
		}
	}
}
#endif

