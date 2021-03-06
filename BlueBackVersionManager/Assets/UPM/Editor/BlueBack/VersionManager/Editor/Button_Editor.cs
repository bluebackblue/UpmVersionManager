

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
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
		#if(ASMDEF_TRUE)
		{
			UnityEditor.PlayerSettings.companyName = Object_Setting.projectparam.namespace_author;
			UnityEditor.PlayerSettings.productName = Object_Setting.projectparam.namespace_author + Object_Setting.projectparam.namespace_package;
			UnityEditor.PlayerSettings.bundleVersion = Object_RootReadmeMd.version;

			UnityEditor.EditorSettings.enterPlayModeOptionsEnabled = true;
			UnityEditor.EditorSettings.enterPlayModeOptions = (UnityEditor.EnterPlayModeOptions.DisableDomainReload | UnityEditor.EnterPlayModeOptions.DisableSceneReload);

			UnityEditor.AssetDatabase.SaveAssets();

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.ForceReserializeAssets();
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

