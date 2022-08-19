

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「Editor/ProjectParam.json」。ロード。
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
	/** Execute_Editor_ProjectParamJson_Load
	*/
	public sealed class Execute_Editor_ProjectParamJson_Load
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			File_Editor_ProjectParamJson t_file = null;

			//path
			string t_path = "Editor/ProjectParam.json.txt";

			//LoadTextWithAssetsPath
			{
				BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
				if(t_result.result == true){
					t_file = BlueBack.JsonItem.Convert.JsonStringToObject<File_Editor_ProjectParamJson>(BlueBack.JsonItem.Normalize.Convert(t_result.value));
				}
			}

			if(t_file == null){
				t_file = new File_Editor_ProjectParamJson(){
				};
			}

			StaticValue.editor_projectparam_json = t_file;

			#endif
		}
	}
}
#endif

