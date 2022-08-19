

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「packages-lock.json」。削除。
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
	/** Execute_Delete_PackagesLockJson
	*/
	public sealed class Execute_Delete_PackagesLockJson : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			#if(ASMDEF_TRUE)
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.TryDelete("../Packages/packages-lock.json");
			#endif
		}
	}
}
#endif

