

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** BlueBack.VersionManager.Editor
*/
#if((UNITY_EDITOR)&&(ASMDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_JSONITEM))
namespace BlueBack.VersionManager.Editor
{
	/** Button_Editor
	*/
	public static class Button_Editor
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[Editor]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_VERSIONMANAGER_LOG)
				DebugTool.Log("OpenBrowser");
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
			UnityEditor.PlayerSettings.companyName = Object_Setting.s_projectparam.namespace_author;
			UnityEditor.PlayerSettings.productName = Object_Setting.s_projectparam.namespace_author + Object_Setting.s_projectparam.namespace_package;
			UnityEditor.PlayerSettings.bundleVersion = Object_RootReadmeMd.s_version;

			UnityEditor.EditorSettings.enterPlayModeOptionsEnabled = true;
			UnityEditor.EditorSettings.enterPlayModeOptions = (UnityEditor.EnterPlayModeOptions.DisableDomainReload | UnityEditor.EnterPlayModeOptions.DisableSceneReload);

			UnityEditor.AssetDatabase.SaveAssets();

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.ForceReserializeAssets();
		}
	}
}
#endif

