

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。リスタードウィンドウ。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_RestartWindow
	*/
	public sealed class Execute_RestartWindow : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			Execute_Root_UssUxml_Save.Execute(true);
			Window.window.OnEnable();
		}
	}
}
#endif

