

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。エディター設定。セーブ。
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
	/** Execute_EditorSetting_Save
	*/
	public sealed class Execute_EditorSetting_Save
	{
		/** Execute
		*/
		public static void Execute()
		{
			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			if(StaticValue.root_readme_md == null){
				Execute_Root_ReadmeMd_Load.Execute();
			}

			UnityEditor.PlayerSettings.companyName = StaticValue.editor_projectparam_json.namespace_author;
			UnityEditor.PlayerSettings.productName = StaticValue.editor_projectparam_json.namespace_author + StaticValue.editor_projectparam_json.namespace_package;
			UnityEditor.PlayerSettings.bundleVersion = StaticValue.root_readme_md.version;

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

