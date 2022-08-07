

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
	/** Button_CreateUssUxml
	*/
	public static class Button_CreateUssUxml
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[CreateUssUxml]" + BlueBack.VersionManager.Version.packageversion;
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_LOG)
				DebugTool.Log("CreateUssUxml");
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
			Object_RootUssUxml.Save(true);
			Window.window.OnEnable();
		}
	}
}
#endif

