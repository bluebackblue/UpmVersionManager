

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。テキストコンバート。
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
	/** Execute_ConvertToNoBomUtf8
	*/
	public static class Execute_ConvertToNoBomUtf8
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)
			BlueBack.AssetLib.Editor.TextConvertWithAssetsPath.ConvertAll("",".*","^.*\\.(cs|meta|mesh|prefab|json|asmdef|mixer|anim)$",new System.Text.UTF8Encoding(false),BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.Code.Editor.CodeConvert.Convert();
			Window.window.OnEnable();
			#endif
		}
	}
}
#endif

