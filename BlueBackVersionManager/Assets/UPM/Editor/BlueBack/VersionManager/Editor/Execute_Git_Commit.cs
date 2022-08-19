

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「TortoiseGitProc」。コミット。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Git_Commit
	*/
	public sealed class Execute_Git_Commit : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			System.Diagnostics.Process.Start("TortoiseGitProc",string.Format("/command:{0} /path:\"{1}\"","commit",(UnityEngine.Application.dataPath + "/../../").Replace("/","\\")));
		}
	}
}
#endif

