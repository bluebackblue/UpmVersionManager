

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
	public class Object_RootReadmeMd
	{
		/** s_instance
		*/
		private static Object_RootReadmeMd s_instance;

		/** GetInstance
		*/
		public static Object_RootReadmeMd GetInstance()
		{
			return s_instance;
		}

		/** CreateInstance
		*/
		public static void CreateInstance()
		{
			if(s_instance == null){
				s_instance = new Object_RootReadmeMd();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** version
		*/
		public string version;

		/** constructor
		*/
		private Object_RootReadmeMd()
		{
		}

		/** Load
		*/
		public void Load()
		{
			if(Object_Setting.GetInstance() != null){
				this.version = "";

				//load
				{
					string t_path = "../../README.md";
					string t_text = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("load : " + t_path);
					#endif

					string t_url = (Object_Setting.GetInstance().param.author_url + "/" + Object_Setting.GetInstance().param.package_name + ".git?path=unity_" + Object_Setting.GetInstance().param.package_name + "/Assets/UPM#").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=").Replace("#","\\#");
					this.version = System.Text.RegularExpressions.Regex.Replace(t_text,"^(?<before>[\\d\\D\\n\\r]*)(?<version_before>\\n\\* " +  t_url + ")(?<version>[0-9\\.]*)(?<after>[\\d\\D\\n\\r]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
						return a_a_match.Groups["version"].Value;
					},System.Text.RegularExpressions.RegexOptions.Multiline);
				}
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Save
		*/
		public static void Save(string a_version)
		{
			if(Object_Setting.GetInstance() != null){
				//「README.md」。
				{
					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					{
						Object_Setting.Creator_Argument t_argument = new Object_Setting.Creator_Argument(
							a_version,
							Object_Setting.GetInstance().param
						);
						foreach(Object_Setting.Creator_Type t_creator in Object_Setting.GetInstance().param.object_root_readme_md){
							string[] t_list = t_creator(in t_argument);
							foreach(string t_line in t_list){
								t_stringbuilder.Append(t_line);
								t_stringbuilder.Append("\n");
							}
							t_stringbuilder.Append("\n");
						}
					}

					string t_path = "../../README.md";
					string t_text = t_stringbuilder.ToString();
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("save : " + t_path);
					#endif
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}
		}
	}
}
#endif

