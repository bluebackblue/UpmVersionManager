

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
	public static class Button_ConvertToUtf8
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[ConvertToUtf8]";
				a_button.clickable.clicked += () => {
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("ConvertToUtf8");
					#endif
					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			BlueBack.AssetLib.Editor.ConvertText.ConvertTextToUtf8FromAssetsPath("",".*","^.*\\.(cs|meta|mesh|prefab|json|asmdef)$",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			Window.s_window.OnEnable();
		}
	}
}
#endif

