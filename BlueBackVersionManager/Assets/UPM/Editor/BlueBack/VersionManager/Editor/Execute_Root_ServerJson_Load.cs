

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
	/** Execute_Root_ServerJson_Load
	*/
	public sealed class Execute_Root_ServerJson_Load
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			//path
			string t_path = "server.json";

			//LoadNoBomUtf8
			if(BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check(t_path) == true){
				Object_RootServerJson.status = BlueBack.JsonItem.Convert.JsonStringToObject<Object_RootServerJson.Status>(BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.Load(t_path));
				return;
			}

			//status
			Object_RootServerJson.status = new Object_RootServerJson.Status(){
				lasttag = "0.0.-1",
				time = "---",
			};

			#endif
		}
	}
}
#endif

