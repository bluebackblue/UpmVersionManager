

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Documentation~/<<author_name>>.<<package_name>>.md」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmDocumentation
	*/
	public class Object_UpmDocumentation
	{
		/** Save
		*/
		public static void Save(string a_version)
		{
			if(Object_Setting.GetInstance() != null){

				//「UPM/Documentation~」
				{
					string t_path = "UPM/Documentation~";
					BlueBack.AssetLib.Editor.DeleteDirectory.DeleteDirectoryFromAssetsPath(t_path);
					BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
				}

				//「UPM/Documentation~/<<author_name>>.<<package_name>>.md」。
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

					string t_path = "UPM/Documentation~/" + Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".md";
					string t_text = t_stringbuilder.ToString();
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_path);
					#endif
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}
	}
}
#endif

