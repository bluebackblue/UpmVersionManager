

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/CHANGELOG.md」。
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
	/** Object_UpmChangeLogMd
	*/
	public static class Object_UpmChangeLogMd
	{
		/** Save
		*/
		public static void Save()
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = "UPM/CHANGELOG.md";

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			foreach(string t_line in Object_Setting.projectparam.changelog){
				t_stringbuilder.Append(t_line);
				t_stringbuilder.Append("\n");
			}

			//SaveTextWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#if(DEF_BLUEBACK_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

