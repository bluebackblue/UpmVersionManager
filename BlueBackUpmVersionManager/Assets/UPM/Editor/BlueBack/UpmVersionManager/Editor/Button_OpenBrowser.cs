

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
	public static class Button_OpenBrowser
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[OpenBrowser]";
				a_button.clickable.clicked += () => {
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("OpenBrowser");
					#endif
					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			UnityEngine.Application.OpenURL(Object_Setting.s_param.git_url + Object_Setting.s_param.git_author + "/" + Object_Setting.s_param.package_name);
		}
	}
}
#endif

