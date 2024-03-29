

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「UPM/CHANGELOG.md」。セーブ。
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
	/** Execute_Upm_ChangeLogMd_Save
	*/
	public sealed class Execute_Upm_ChangeLogMd_Save
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			//path
			string t_path = "UPM/CHANGELOG.md";

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			foreach(string t_line in StaticValue.editor_projectparam_json.changelog){
				t_stringbuilder.Append(t_line);
				t_stringbuilder.Append("\n");
			}

			//SaveTextWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("save : " + t_path);
			#endif

			#endif
		}
	}
}
#endif

