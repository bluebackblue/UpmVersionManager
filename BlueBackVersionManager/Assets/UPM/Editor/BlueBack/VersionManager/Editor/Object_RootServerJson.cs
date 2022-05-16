

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「Root/server.json」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&((ASMDEF_BLUEBACK_JSONITEM||USERDEF_BLUEBACK_JSONITEM)))
#define ASMDEF_TRUE
#endif

/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_RootServerJson
	*/
	public static class Object_RootServerJson
	{
		/** Status
		*/
		public sealed class Status
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
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = "server.json";

			//LoadNoBomUtf8
			if(BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check(t_path) == true){
				s_status = BlueBack.JsonItem.Convert.JsonStringToObject<Status>(BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.Load(t_path));
				return;
			}
			
			//s_status
			s_status = new Status(){
				lasttag = "0.0.-1",
				time = "---",
			};
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif

		/** DownloadAndSave
		*/
		public static void DownloadAndSave()
		#if(ASMDEF_TRUE)
		{
			//url
			string t_url = Object_Setting.s_projectparam.git_api + "/releases/latest";
			
			//path
			string t_path = "server.json";

			//LoadTextWithUrl
			BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithUrl.TryLoad(t_url,null);
			if(t_result.result == true){
				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(t_result.value));
				if(t_jsonitem.IsExistItem("tag_name") == true){
					s_status.lasttag = t_jsonitem.GetItem("tag_name").GetStringData();
					s_status.time = System.DateTime.Now.ToString();

					//SaveTextWithAssetsPath
					BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(BlueBack.JsonItem.Convert.ObjectToJsonString<Status>(s_status),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
					BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				}
			}
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

