

/** Samples.UpmVersionManager.NewProject.Editor
*/
namespace Samples.UpmVersionManager.NewProject.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** MenuItem_NewProject

			Assets
				Editor
					UpmVersionManagerSetting.cs

				Samples
					<<Package_Name>>
						000
							xxxx
							yyyy

					Samples.asmdef

				UPM
					Editor
						<<Owner_Name>>
							<<Package_Name>>
								Editor
						<<Owner_Name>>.<<Package_Name>.Editor.asmdef

					RunTime
						<<Owner_Name>>
							<<Package_Name>>
								Config.cs
								DebugTool.cs
								Version.cs
						<<Owner_Name>>.<<Package_Name>.asmdef

					CHANGELOG.md
					LICENSE.md
					package.json
					README.md

				csc.rsp
				server.json
				UpmVersionManagerWindow.uss
				UpmVersionManagerWindow.uxml

		*/
		[UnityEditor.MenuItem("UpmVersionManager/NewProject")]
		private static void MenuItem_NewProject()
		{
			string t_package_name = "NewProject";
			string t_owner_name = "Owner_Name";

			string t_path_upmversionmanagersetting_cs = "Editor/UpmVersionManagerSetting.cs";

			string t_path_config_cs = "UPM/RunTime/" + t_owner_name + "/" + t_package_name + "/Config.cs";
			string t_path_debugtool_cs = "UPM/RunTime/" + t_owner_name + "/" + t_package_name + "/DebugTool.cs";
			string t_path_version_cs = "UPM/RunTime/" + t_owner_name + "/" + t_package_name + "/Version.cs";

			string t_path_changelog_md = "UPM/CHANGELOG.md";
			string t_path_license_md = "UPM/LICENSE.md";
			string t_path_package_json = "UPM/package.json";
			string t_path_readme_md = "UPM/README.md";

			string t_path_csc_rsp = "csc.rsp";
			string t_path_server_json = "server.json";

			//UpmVersionManagerSetting.cs
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("Editor");
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_upmversionmanagersetting_cs) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_upmversionmanagersetting_cs,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//Samples
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("Samples/" + t_package_name + "/000");

			//UPM
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("UPM/Editor/" + t_owner_name + "/" + t_package_name + "/Editor");
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("UPM/RunTime/" + t_owner_name + "/" + t_package_name);

			//Config.cs
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_config_cs) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_config_cs,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//DebugTool.cs
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_debugtool_cs) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_debugtool_cs,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//Version.cs
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_version_cs) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_version_cs,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM/CHANGELOG.md
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_changelog_md) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_changelog_md,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM/LICENSE.md
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_license_md) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_license_md,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM/package.json
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_package_json) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_package_json,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM/README.md
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_readme_md) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_readme_md,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//csc.rsp
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_csc_rsp) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("",t_path_csc_rsp,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//server.json
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_server_json) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("",t_path_server_json,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}
		}
	}
	#endif
}

