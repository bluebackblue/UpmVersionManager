

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

			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			//url
			string t_url = StaticValue.editor_projectparam_json.git_api + "/releases/latest";

			//path
			string t_path = "server.json";

			//LoadTextWithUrl
			BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.LoadTextWithUrl.TryLoad(t_url,null);
			if(t_result.result == true){
				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(t_result.value));
				if(t_jsonitem.IsExistItem("tag_name") == true){
					StaticValue.root_server_json = new File_Root_ServerJson();
					StaticValue.root_server_json.lasttag = t_jsonitem.GetItem("tag_name").GetStringData();
					StaticValue.root_server_json.time = System.DateTime.Now.ToString();

					//SaveTextWithAssetsPath
					BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(BlueBack.JsonItem.Convert.ObjectToJsonString<File_Root_ServerJson>(StaticValue.root_server_json),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
					BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				}
			}

			#endif
		}
	}
}
#endif

