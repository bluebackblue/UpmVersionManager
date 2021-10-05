

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
	public class Object_RootServerJson
	{
		/** s_instance
		*/
		private static Object_RootServerJson s_instance;

		/** GetInstance
		*/
		public static Object_RootServerJson GetInstance()
		{
			return s_instance;
		}

		/** CreateInstance
		*/
		public static void CreateInstance()
		{
			if(s_instance == null){
				s_instance = new Object_RootServerJson();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Param
		*/
		public struct Param
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
		public Param status;

		/** constructor
		*/
		private Object_RootServerJson()
		{
		}

		/** Load
		*/
		public void Load()
		{
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath("server.json") == true){
				//load
				string t_path = "server.json";
				this.status = BlueBack.JsonItem.Convert.JsonStringToObject<Param>(BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8));
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
				DebugTool.Log("load : " + t_path);
				#endif
			}else{
				//dummy
				this.status.lasttag = "0.0.-1";
				this.status.time = "---";
			}
		}

		/** DownloadAndSave
		*/
		public void DownloadAndSave()
		{
			if(Object_Setting.GetInstance() != null){

				//download
				{
					string t_path_download = "https://api.github.com/repos/" + Object_Setting.GetInstance().param.git_author + "/" + Object_Setting.GetInstance().param.package_name + "/releases/latest";
					string t_jsonstring_download = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromUrl(t_path_download,null,System.Text.Encoding.UTF8);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("download : " + t_path_download);
					#endif
					
					t_jsonstring_download = BlueBack.JsonItem.Normalize.Convert(t_jsonstring_download);
					BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring_download);
					if(this.status.lasttag != t_jsonitem.GetItem("name").GetStringData()){
						this.status.lasttag = t_jsonitem.GetItem("name").GetStringData();
						this.status.time = System.DateTime.Now.ToString();

						//save
						{
							string t_path = "server.json";
							string t_jsonstring_save = BlueBack.JsonItem.Convert.ObjectToJsonString<Param>(this.status);
							BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring_save,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
							#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
							DebugTool.Log("save : " + t_path);
							#endif
						}
					}
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

