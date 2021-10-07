

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
	public class Button_ServerJson
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[ServerJson]";

				a_button.text = Object_RootServerJson.GetInstance().status.lasttag;
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
			if(Object_RootServerJson.GetInstance() == null){
				Object_RootServerJson.CreateInstance();
			}

			Object_RootServerJson.GetInstance().DownloadAndSave();
			Object_RootServerJson.GetInstance().Load();
			Window.s_window.OnEnable();
		}
	}
}
#endif

