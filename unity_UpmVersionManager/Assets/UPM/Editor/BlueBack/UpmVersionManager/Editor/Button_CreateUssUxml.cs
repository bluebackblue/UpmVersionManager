

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
	public static class Button_CreateUssUxml
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[CreateUssUxml]";
				a_button.clickable.clicked += () => {
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("CreateUssUxml");
					#endif
					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			Object_RootUssUxml.Save(true);
			Window.s_window.OnEnable();
		}
	}
}
#endif

