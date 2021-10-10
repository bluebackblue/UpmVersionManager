

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「Root/README.md」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_RootReadmeMd
	*/
	public static class Object_RootReadmeMd
	{
		/** s_version
		*/
		public static string s_version = null;

		/** Load
		*/
		public static void Load()
		{
			s_version = "";

			//load
			{
				string t_path = Object_Setting.s_param.root_readmemd_path;
				string t_text = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8);
				if(t_text != null){
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("load : " + t_path);
					#endif

					string t_url = (Object_Setting.s_param.git_url + Object_Setting.s_param.git_author + "/" + Object_Setting.s_param.package_name + ".git?path=" + Object_Setting.s_param.git_path + "#").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=").Replace("#","\\#");
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,"^(?<before>[\\d\\D\\n\\r]*" + t_url + ")(?<version>[0-9\\.]*)(?<after>[\\d\\D\\n\\r]*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
					if(t_match.Success == true){
						s_version = t_match.Groups["version"].Value;
					}else{
						#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
						DebugTool.Assert(false);
						#endif
						s_version = "0.0.-1";
					}
				}else{
					s_version = "0.0.-1";
				}
			}
		}

		/** Save
		*/
		public static void Save(string a_version)
		{
			//「README.md」。
			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				{
					Object_Setting.Creator_Argument t_argument = new Object_Setting.Creator_Argument(a_version);
					foreach(Object_Setting.Creator_Type t_creator in Object_Setting.s_param.object_root_readme_md){
						string[] t_list = t_creator(in t_argument);
						foreach(string t_line in t_list){
							t_stringbuilder.Append(t_line);
							t_stringbuilder.Append("\n");
						}
						t_stringbuilder.Append("\n");
					}
				}

				string t_path = Object_Setting.s_param.root_readmemd_path;
				string t_text = t_stringbuilder.ToString();
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
				DebugTool.Log("save : " + t_path);
				#endif
			}

			Object_RootReadmeMd.s_version = null;

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

