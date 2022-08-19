

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。バージョン適応。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_VersionApply_RootReadmeMd
	*/
	public sealed class Execute_VersionApply_RootReadmeMd : Execute_Base
	{
		/** version
		*/
		public string version;

		/** constructor
		*/
		public Execute_VersionApply_RootReadmeMd(string a_version)
		{
			this.version = a_version;
		}

		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			Execute_Editor_ProjectParamJson_Load.Execute();

			Execute_Root_ReadmeMd_Save.Execute(this.version);
			Execute_Root_ReadmeMd_Load.Execute();
			Execute_Convert_NoBomUtf8.Execute();
			Execute_EditorSetting_Save.Execute();
			BlueBack.Code.Editor.FileNameCheck.Check(null);
			Window.window.OnEnable();
		}
	}
}
#endif

