

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「Root/server.json」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_RootServerJson
	*/
	public static class Object_RootServerJson
	{
		/** Status
		*/
		public class Status
		{
			/** lasttag
			*/
			public string lasttag;

			/** time
			*/
			public string time;
		}

		/** status
		*/
		public static Status s_status = null;

		/** Load
		*/
		public static void Load()
		{
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath("server.json") == true){
				//load
				string t_path = "server.json";
				s_status = BlueBack.JsonItem.Convert.JsonStringToObject<Status>(BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8));
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
				DebugTool.Log("load : " + t_path);
				#endif
			}else{
				//dummy
				s_status = new Status();
				s_status.lasttag = "0.0.-1";
				s_status.time = "---";
			}
		}

		/** DownloadAndSave
		*/
		public static void DownloadAndSave()
		{
			string t_path_download = Object_Setting.s_projectparam.git_api + "/releases/latest";
			string t_jsonstring_download = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromUrl(t_path_download,null,System.Text.Encoding.UTF8);
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("download : " + t_path_download + " : " + t_jsonstring_download);
			#endif

			t_jsonstring_download = BlueBack.JsonItem.Normalize.Convert(t_jsonstring_download);
			BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring_download);
			if(s_status.lasttag != t_jsonitem.GetItem("tag_name").GetStringData()){
				s_status.lasttag = t_jsonitem.GetItem("tag_name").GetStringData();
				s_status.time = System.DateTime.Now.ToString();

				//save
				{
					string t_path = "server.json";
					string t_jsonstring_save = BlueBack.JsonItem.Convert.ObjectToJsonString<Status>(s_status);
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring_save,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_path);
					#endif
				}
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

