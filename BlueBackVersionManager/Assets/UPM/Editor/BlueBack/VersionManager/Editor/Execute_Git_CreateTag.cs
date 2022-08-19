

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「TortoiseGitProc」。タグ作成。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Git_CreateTag
	*/
	public sealed class Execute_Git_CreateTag : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			System.Diagnostics.Process.Start("TortoiseGitProc",string.Format("/command:{0} /path:\"{1}\" /name:\"{2}\"","tag",(UnityEngine.Application.dataPath + "/../../").Replace("/","\\"),Object_RootReadmeMd.version));
		}
	}
}
#endif

