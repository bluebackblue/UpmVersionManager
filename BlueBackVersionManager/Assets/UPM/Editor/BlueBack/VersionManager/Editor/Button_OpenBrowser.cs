

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
	/** Button_OpenBrowser
	*/
	public static class Button_OpenBrowser
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[OpenBrowser]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_LOG)
				DebugTool.Log("OpenBrowser");
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
			UnityEngine.Application.OpenURL(Object_Setting.projectparam.git_url);
		}
	}
}
#endif

