

/** Samples.AssetLib.EncodeCheck.Editor
*/
namespace Samples.AssetLib.EncodeCheck.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** エンコード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/EncodeCheck/EncodeCheck")]
		private static void MenuItem_EncodeCheck()
		{
			string[] t_namelist = new string[]{
				"^sjis\\.txt$",

				"^utf8\\.txt$",
				"^utf8bom\\.txt$",

				"^utf16lebom\\.txt$",
				"^utf16bebom\\.txt$",

				"^utf32lebom\\.txt$",
				"^utf32bebom\\.txt$",
			};

			for(int ii=0;ii<t_namelist.Length;ii++){
				string t_path = BlueBack.AssetLib.Editor.FindFile.FindFileFistFromAssetsPath("Samples",".*",t_namelist[ii]);
				string t_text = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_path,null);
				UnityEngine.Debug.Log(t_path + "\n" + "text[0] == " + (t_text[0]) + "\n" + t_text);
			}
		}
	}
	#endif
}

