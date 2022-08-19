

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「Root/README.md」。ダウンロード後セーブ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Root_ServerJson_DownloadAndSave
	*/
	public sealed class Execute_Root_ServerJson_DownloadAndSave
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			//url
			string t_url = Object_Setting.projectparam.git_api + "/releases/latest";

			//path
			string t_path = "server.json";

			//LoadTextWithUrl
			BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.LoadTextWithUrl.TryLoad(t_url,null);
			if(t_result.result == true){
				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(t_result.value));
				if(t_jsonitem.IsExistItem("tag_name") == true){
					Object_RootServerJson.status.lasttag = t_jsonitem.GetItem("tag_name").GetStringData();
					Object_RootServerJson.status.time = System.DateTime.Now.ToString();

					//SaveTextWithAssetsPath
					BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(BlueBack.JsonItem.Convert.ObjectToJsonString<Object_RootServerJson.Status>(Object_RootServerJson.status),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
					BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				}
			}

			#endif
		}
	}
}
#endif

