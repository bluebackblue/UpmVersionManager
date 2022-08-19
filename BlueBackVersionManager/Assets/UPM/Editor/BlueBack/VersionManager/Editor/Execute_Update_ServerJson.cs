

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「server.json」更新。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Update_ServerJson
	*/
	public sealed class Execute_Update_ServerJson : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			Object_RootServerJson.DownloadAndSave();
			Object_RootServerJson.Load();
			Window.window.OnEnable();
		}
	}
}
#endif

