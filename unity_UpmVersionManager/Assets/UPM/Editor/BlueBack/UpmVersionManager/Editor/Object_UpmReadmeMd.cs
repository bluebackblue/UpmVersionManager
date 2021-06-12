

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
	public class Object_UpmReadmeMd
	{
		/** Save
		*/
		public static void Save()
		{
			if(Object_Setting.GetInstance() != null){

				//「UPM/README.md」。
				{
					string[] t_readme_md = new string[]{
						"#" + Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name,
						Object_Setting.GetInstance().param.author_url + "/" + Object_Setting.GetInstance().param.package_name,
					};

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
					foreach(string t_line in t_readme_md){
						t_stringbuilder.Append(t_line);
						t_stringbuilder.Append("\n");
					}

					string t_path = "UPM/README.md";
					string t_text = t_stringbuilder.ToString();
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,"UPM/README.md",false,BlueBack.AssetLib.LineFeedOption.CRLF);
					UnityEngine.Debug.Log("save : " + t_path);
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

