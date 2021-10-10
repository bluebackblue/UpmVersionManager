

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
	public static class Button_ServerJson
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[ServerJson]";

				if(Object_RootServerJson.s_status == null){
					Object_RootServerJson.Load();
				}

				a_button.text = Object_RootServerJson.s_status.lasttag;
				a_button.AddToClassList("red");

				a_button.clickable.clicked += () => {

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("ServerJson");
					#endif

					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			Object_Setting.s_projectparam = ProjectParam.Load();

			Object_RootServerJson.DownloadAndSave();
			Object_RootServerJson.Load();
			Window.s_window.OnEnable();
		}
	}
}
#endif

