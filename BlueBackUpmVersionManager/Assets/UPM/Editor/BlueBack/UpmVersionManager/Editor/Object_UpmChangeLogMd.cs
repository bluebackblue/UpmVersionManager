

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
	public static class Object_UpmChangeLogMd
	{
		/** Save
		*/
		public static void Save()
		{
			//path
			string t_path = "UPM/CHANGELOG.md";

			//stringbuilder
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			foreach(string t_line in Object_Setting.s_projectparam.changelog){
				t_stringbuilder.Append(t_line);
				t_stringbuilder.Append("\n");
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

