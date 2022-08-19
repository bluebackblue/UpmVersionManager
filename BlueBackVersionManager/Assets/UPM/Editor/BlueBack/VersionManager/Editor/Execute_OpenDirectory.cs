

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。ディレクトリを開く。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_OpenDirectory
	*/
	public sealed class Execute_OpenDirectory : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			System.Diagnostics.Process.Start("explorer","/select," + (UnityEngine.Application.dataPath + "/../").Replace("/","\\"));
		}
	}
}
#endif

