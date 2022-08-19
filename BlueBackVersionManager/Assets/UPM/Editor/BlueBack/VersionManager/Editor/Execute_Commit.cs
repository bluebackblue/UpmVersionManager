

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。コミット。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Commit
	*/
	public sealed class Execute_Commit : Execute_Base
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

