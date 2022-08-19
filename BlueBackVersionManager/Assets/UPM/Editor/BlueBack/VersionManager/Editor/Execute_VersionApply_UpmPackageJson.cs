

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
	/** Execute_VersionApply_UpmPackageJson
	*/
	public sealed class Execute_VersionApply_UpmPackageJson : Execute_Base
	{
		/** version
		*/
		public string version;

		/** constructor
		*/
		public Execute_VersionApply_UpmPackageJson(string a_version)
		{
			this.version = a_version;
		}

		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			Execute_Upm_Samples_Copy.Execute();
			Execute_Upm_ChangeLogMd_Save.Execute();
			Execute_Upm_Documentation_Save.Execute(this.version);
			Execute_Upm_ReadmeMd_Save.Execute(this.version);
			Execute_Upm_VersionCs_Save.Execute(this.version);

			if(StaticValue.editor_projectparam_json.debugtool_generate == true){
				Execute_Upm_DebugToolCs_Save.Execute();
			}

			Execute_Upm_PackageJson_Save.Execute(this.version);
			Execute_Upm_UpdatePackageCs_Save.Execute();
			Execute_Upm_Asmdef_Save.Execute();
			Execute_Convert_NoBomUtf8.Execute();
			BlueBack.Code.Editor.FileNameCheck.Check(null);
			Execute_EditorSetting_Save.Execute();
			Window.window.OnEnable();
		}
	}
}
#endif

