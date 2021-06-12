

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
					string t_text = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_path,System.Text.Encoding.GetEncoding("utf-8"));
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("load : " + t_path);
					#endif

					string[] t_text_list = t_text.Split(new char[]{'\r','\n'});
					string t_url = (Object_Setting.GetInstance().param.author_url + "/" + Object_Setting.GetInstance().param.package_name + ".git?path=unity_" + Object_Setting.GetInstance().param.package_name + "/Assets/UPM").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=");
					System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex("\\* " + t_url + "\\#" + "(?<version>.*)");
					foreach(string t_text_line in t_text_list){
						System.Text.RegularExpressions.Match t_match = t_regex.Match(t_text_line);
						if(t_match.Success == true){
							System.Text.RegularExpressions.GroupCollection t_group_collection = t_match.Groups;
							foreach(System.Text.RegularExpressions.Group t_group in t_group_collection){
								if(t_group.Success == true){
									if(t_group.Name == "version"){
										this.version = t_group.Value;
									}
								}
							}
						}
					}
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

