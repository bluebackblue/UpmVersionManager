

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。プッシュ。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Push
	*/
	public sealed class Execute_Push : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			System.Diagnostics.Process.Start("TortoiseGitProc",string.Format("/command:{0} /path:\"{1}\"","push",(UnityEngine.Application.dataPath + "/../../").Replace("/","\\")));
		}
	}
}
#endif

