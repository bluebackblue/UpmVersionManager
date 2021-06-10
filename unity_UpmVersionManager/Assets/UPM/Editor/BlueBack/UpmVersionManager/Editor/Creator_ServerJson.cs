

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
{
	/** Creator_ServerJson
	*/
	public class Creator_ServerJson
	{
		/** Status
		*/
		public struct Status
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
		public Status status;

		/** constructor
		*/
		public Creator_ServerJson()
		{
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath("server.json") == true){
				//load
				string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath("server.json",null);
				this.status = BlueBack.JsonItem.Convert.JsonStringToObject<Status>(t_jsonstring);
			}else{
				//dummy
				this.status.lasttag = "0.0.-1";
				this.status.time = "---";
			}
		}

		/** Download
		*/
		public void Download()
		{
			//download
			{
				string t_jsonstring_download = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromUrl("https://api.github.com/repos/bluebackblue/" + Setting.PACKAGE_NAME + "/releases/latest",null,System.Text.Encoding.GetEncoding("utf-8"));
				UnityEngine.Debug.Log(t_jsonstring_download);
					
				t_jsonstring_download = BlueBack.JsonItem.Normalize.Convert(t_jsonstring_download);
				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring_download);
				if(this.status.lasttag != t_jsonitem.GetItem("name").GetStringData()){
					this.status.lasttag = t_jsonitem.GetItem("name").GetStringData();
					this.status.time = System.DateTime.Now.ToString();

					//save
					{
						string t_jsonstring_save = BlueBack.JsonItem.Convert.ObjectToJsonString<Status>(this.status);
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring_save,"server.json",false,BlueBack.AssetLib.LineFeedOption.CRLF);
						UnityEngine.Debug.Log(t_jsonstring_save);
					}
				}
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

