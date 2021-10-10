

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/README.md」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmReadmeMd
	*/
	public static class Object_UpmReadmeMd
	{
		/** Save
		*/
		public static void Save(string a_version)
		{
			//path
			string t_path = "UPM/README.md";

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			{
				Object_Setting.Creator_Argument t_argument = new Object_Setting.Creator_Argument(a_version);
				foreach(Object_Setting.Creator_Type t_creator in Object_Setting.s_object_root_readme_md){
					string[] t_list = t_creator(in t_argument);
					foreach(string t_line in t_list){
						t_stringbuilder.Append(t_line);
						t_stringbuilder.Append("\n");
					}
					t_stringbuilder.Append("\n");
				}
			}
			
			//SaveUtf8TextToAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
	}
}
#endif

