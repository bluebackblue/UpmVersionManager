

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「UPM/README.md」。セーブ。
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
	/** Execute_Upm_ReadmeMd_Save
	*/
	public sealed class Execute_Upm_ReadmeMd_Save
	{
		/** Execute
		*/
		public static void Execute(string a_version)
		{
			#if(ASMDEF_TRUE)

			//path
			string t_path = "UPM/README.md";

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			{
				ReadmeMdCreator.Argument t_argument = new ReadmeMdCreator.Argument(a_version);
				foreach(ReadmeMdCreator.CallBackType t_callback in StaticValue.readmemd_creator_callback){
					string[] t_list = t_callback(in t_argument);
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

