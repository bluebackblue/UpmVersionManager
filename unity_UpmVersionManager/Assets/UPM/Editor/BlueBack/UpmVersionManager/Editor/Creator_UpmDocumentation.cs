

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
{
	/** Creator_UpmDocumentation
	*/
	public class Creator_UpmDocumentation
	{
		/** Save
		*/
		public void Save()
		{
			//「UPM/Documentation~/AUTHOR_NAME.PACKAGE_NAME.md」。
			{
				string[] t_readme_md = new string[]{
					"#" + Setting.AUTHOR_NAME + "." + Setting.PACKAGE_NAME,
					Setting.AUTHOR_URL + "/" + Setting.PACKAGE_NAME,
				};

				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				foreach(string t_line in t_readme_md){
					t_stringbuilder.Append(t_line);
					t_stringbuilder.Append("\n");
				}

				string t_text = t_stringbuilder.ToString();
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,"UPM/Documentation~/" + Setting.AUTHOR_NAME + "." + Setting.PACKAGE_NAME + ".md",false,BlueBack.AssetLib.LineFeedOption.CRLF);
				UnityEngine.Debug.Log(t_text);
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

