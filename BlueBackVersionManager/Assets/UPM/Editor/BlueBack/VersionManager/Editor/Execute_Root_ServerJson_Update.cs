

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「server.json」。更新。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Root_ServerJson_Update
	*/
	public sealed class Execute_Root_ServerJson_Update : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			Execute_Root_ServerJson_DownloadAndSave.Execute();
			Execute_Root_ServerJson_Load.Execute();
			Window.window.OnEnable();
		}
	}
}
#endif

