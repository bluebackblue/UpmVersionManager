

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
{
	/** Creator_UpmChangeLogMd
	*/
	public class Creator_UpmChangeLogMd
	{
		/** Save
		*/
		public void Save()
		{
			//「UPM/CHANGELOG.md」。
			{
				string[] t_readme_md = Setting.CHANGELOG;

				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				foreach(string t_line in t_readme_md){
					t_stringbuilder.Append(t_line);
					t_stringbuilder.Append("\n");
				}

				string t_text = t_stringbuilder.ToString();
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,"UPM/CHANGELOG.md",false,BlueBack.AssetLib.LineFeedOption.CRLF);

				UnityEngine.Debug.Log(t_text);
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

