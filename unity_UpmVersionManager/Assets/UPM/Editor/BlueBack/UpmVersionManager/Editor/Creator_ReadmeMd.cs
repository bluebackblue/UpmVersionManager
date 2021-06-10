

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
{
	/** Creator_ServerJson
	*/
	public class Creator_ReadmeMd
	{
		/** version
		*/
		public string version;

		/** constructor
		*/
		public Creator_ReadmeMd()
		{
			this.version = "";

			//load
			{
				string t_text = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath("../../README.md",System.Text.Encoding.GetEncoding("utf-8"));
				string[] t_text_list = t_text.Split(new char[]{'\r','\n'});

				string t_url = (Setting.AUTHOR_URL + "/" + Setting.PACKAGE_NAME + ".git?path=unity_" + Setting.PACKAGE_NAME + "/Assets/UPM").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=");

				System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex("\\* " + t_url + "\\#" + "(?<version>.*)");
				foreach(string t_text_line in t_text_list){
					System.Text.RegularExpressions.Match t_match = t_regex.Match(t_text_line);
					if(t_match.Success == true){
						System.Text.RegularExpressions.GroupCollection t_group_collection = t_match.Groups;
						foreach(System.Text.RegularExpressions.Group t_group in t_group_collection){
							if(t_group.Success == true){
								if(t_group.Name == "version"){
									this.version = t_group.Value;
								}
							}
						}
					}
				}
			}
		}

		/** Save
		*/
		public void Save(string a_version)
		{
			//「README.md」。
			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				{
					//READMEMD_STRINGCREATOR
					{
						Setting.ReadmeMd_StringCreator_Argument t_argument = new Setting.ReadmeMd_StringCreator_Argument(){
							version = a_version,
						};

						foreach(Setting.ReadmeMd_StringCreator_Type t_creator in Setting.READMEMD_STRINGCREATOR){
							string[] t_list = t_creator(in t_argument);

							foreach(string t_line in t_list){
								t_stringbuilder.Append(t_line);
								t_stringbuilder.Append("\n");
							}
							t_stringbuilder.Append("\n");
						}
					}
				}

				string t_text = t_stringbuilder.ToString();
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,"../../README.md",false,BlueBack.AssetLib.LineFeedOption.CRLF);
				UnityEngine.Debug.Log(t_text);
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

