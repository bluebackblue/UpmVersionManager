

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。エディター情報のセーブ。
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
	/** Execute_Save_Editor
	*/
	public sealed class Execute_Save_Editor
	{
		/** Execute
		*/
		public static void Execute()
		{
			UnityEditor.PlayerSettings.companyName = Object_Setting.projectparam.namespace_author;
			UnityEditor.PlayerSettings.productName = Object_Setting.projectparam.namespace_author + Object_Setting.projectparam.namespace_package;
			UnityEditor.PlayerSettings.bundleVersion = Object_RootReadmeMd.version;

			UnityEditor.EditorSettings.enterPlayModeOptionsEnabled = true;
			UnityEditor.EditorSettings.enterPlayModeOptions = (UnityEditor.EnterPlayModeOptions.DisableDomainReload | UnityEditor.EnterPlayModeOptions.DisableSceneReload);

			UnityEditor.AssetDatabase.SaveAssets();

			#if(ASMDEF_TRUE)
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.ForceReserializeAssets();
			#endif
		}
	}
}
#endif

