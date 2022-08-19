

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「UPM/Documentation~/<<NameSpace_Author>>.<<NameSpace_Package>>.md」。セーブ。
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
	/** Execute_Upm_Documentation_Save
	*/
	public static class Execute_Upm_Documentation_Save
	{
		/** Execute
		*/
		public static void Execute(string a_version)
		{
			#if(ASMDEF_TRUE)

			//path
			string t_path = Object_Setting.Reprece("UPM/Documentation~/<<NameSpace_Author>>.<<NameSpace_Package>>.md");

			//DeleteDirectoryWithAssetsPath
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("UPM/Documentation~");

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			{
				Object_Setting.Creator_Argument t_argument = new Object_Setting.Creator_Argument(a_version);
				foreach(Object_Setting.Creator_Type t_creator in Object_Setting.object_root_readme_md){
					string[] t_list = t_creator(in t_argument);
					foreach(string t_line in t_list){
						t_stringbuilder.Append(t_line);
						t_stringbuilder.Append("\n");
					}
					t_stringbuilder.Append("\n");
				}
			}

			//SaveTextWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#endif
		}
	}
}
#endif

