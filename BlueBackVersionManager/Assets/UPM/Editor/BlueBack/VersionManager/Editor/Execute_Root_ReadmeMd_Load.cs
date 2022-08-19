

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「Root/README.md」。ロード。
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
	/** Execute_Root_ReadmeMd_Load
	*/
	public sealed class Execute_Root_ReadmeMd_Load
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			//path
			string t_path = "";
			if(Object_Setting.projectparam != null){
				t_path = Object_Setting.projectparam.root_readmemd_path;
			}

			//LoadTextWithAssetsPath
			{
				BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
				if(t_result.result == true){
					string t_url = (Object_Setting.projectparam.git_url + ".git?path=" + Object_Setting.projectparam.git_path + "#").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=").Replace("#","\\#");
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_result.value,"^(?<before>[\\d\\D\\n\\r]*" + t_url + ")(?<version>[0-9\\.]*)(?<after>[\\d\\D\\n\\r]*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
					if(t_match.Success == true){
						Object_RootReadmeMd.version = t_match.Groups["version"].Value;
						return;
					}
				}
			}

			Object_RootReadmeMd.version = "0.0.-1";

			#endif
		}
	}
}
#endif

