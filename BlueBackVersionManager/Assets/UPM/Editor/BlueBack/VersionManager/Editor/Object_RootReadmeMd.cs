

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「Root/README.md」。
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
	/** Object_RootReadmeMd
	*/
	public static class Object_RootReadmeMd
	{
		/** version
		*/
		public static string version = null;

		/** Load
		*/
		public static void Load()
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = "";
			if(Object_Setting.projectparam != null){
				t_path = Object_Setting.projectparam.root_readmemd_path;
			}

			//LoadTextWithAssetsPath
			{
				BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
				if(t_result.result == true){
					string t_url = (Object_Setting.projectparam.git_url + ".git?path=" + Object_Setting.projectparam.git_path + "#").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=").Replace("#","\\#");
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_result.value,"^(?<before>[\\d\\D\\n\\r]*" + t_url + ")(?<version>[0-9\\.]*)(?<after>[\\d\\D\\n\\r]*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
					if(t_match.Success == true){
						Object_RootReadmeMd.version = t_match.Groups["version"].Value;
						return;
					}
				}
			}

			Object_RootReadmeMd.version = "0.0.-1";
			return;
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif

		/** Save
		*/
		public static void Save(string a_version)
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = Object_Setting.projectparam.root_readmemd_path;

			//SaveTextWithAssetsPath
			{
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
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

