

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
	/** Button_ConvertToUtf8
	*/
	public static class Button_ConvertToUtf8
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[ConvertToUtf8]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
				DebugTool.Log("ConvertToUtf8");
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
			BlueBack.AssetLib.Editor.TextConvertTool.ConvertAll("",".*","^.*\\.(cs|meta|mesh|prefab|json|asmdef|mixer|anim)$",System.Text.Encoding.UTF8,BlueBack.AssetLib.LineFeedOption.CRLF);
			Window.s_window.OnEnable();
		}
	}
}
#endif

