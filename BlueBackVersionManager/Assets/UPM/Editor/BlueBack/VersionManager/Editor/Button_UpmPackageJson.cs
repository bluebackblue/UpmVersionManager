

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Button_UpmPackageJson
	*/
	public static class Button_UpmPackageJson
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button,int a_index)
		{
			string t_version = "";
			if(Object_RootServerJson.status != null){
				string[] t_version_split = Object_RootServerJson.status.lasttag.Split('.');
				int t_version_split_item2 = int.Parse(t_version_split[2]);
				switch(a_index){
				case 0:
					{
						t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 - 1);
					}break;
				case 1:
					{
						t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2);
					}break;
				case 2:
					{
						t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 + 1);
					}break;
				default:
					{
						UnityEngine.Debug.Assert(false);
					}break;
				}
			}

			a_button.text = t_version;
			if(t_version == Object_Setting.GetPackageVersion()){
				a_button.AddToClassList("red");
			}

			//「package.json」作成。
			a_button.clickable.clicked += () => {

				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log("UpmPackageJson : " + t_version);
				#endif

				On(t_version);
			};
		}

		/** On
		*/
		private static void On(string a_version)
		{
			Execute_Upm_Samples_Copy.Execute();
			Execute_Upm_ChangeLogMd_Save.Execute();
			Execute_Upm_Documentation_Save.Execute(a_version);
			Execute_Upm_ReadmeMd_Save.Execute(a_version);
			Execute_Upm_VersionCs_Save.Execute(a_version);

			if(Object_Setting.projectparam.debugtool_generate == true){
				Execute_Upm_DebugToolCs_Save.Execute();
			}

			Execute_Upm_PackageJson_Save.Execute(a_version);
			Execute_Upm_UpdatePackageCs_Save.Execute();
			Object_UpmAsmdef.Save();
			Execute_Convert_NoBomUtf8.Execute();
			BlueBack.Code.Editor.FileNameCheck.Check(null);
			Execute_EditorSetting_Save.Execute();
			Window.window.OnEnable();
		}
	}
}
#endif

