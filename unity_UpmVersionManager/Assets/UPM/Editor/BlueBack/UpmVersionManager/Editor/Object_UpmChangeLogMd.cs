

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/CHANGELOG.md」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmChangeLogMd
	*/
	public class Object_UpmChangeLogMd
	{
		/** Save
		*/
		public static void Save()
		{
			if(Object_Setting.GetInstance() != null){
				//「UPM/CHANGELOG.md」。
				{
					string[] t_readme_md = Object_Setting.GetInstance().param.changelog;

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
					foreach(string t_line in t_readme_md){
						t_stringbuilder.Append(t_line);
						t_stringbuilder.Append("\n");
					}

					string t_path = "UPM/CHANGELOG.md";
					string t_text = t_stringbuilder.ToString();
					BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_path);
					#endif
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}
		}
	}
}
#endif

