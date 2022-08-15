

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief セーブ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** SaveEditor
	*/
	public static class SaveEditor
	{
		/** Save
		*/
		public static void Save()
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

