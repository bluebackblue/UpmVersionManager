

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
					<<NewProject>>
						000
							xxxx
							yyyy

					Samples.asmdef

				UPM
					Editor
						<<Owner>>
							<<NewProject>>
								Editor
						<<Pwner>>.<<NewProject>.Editor.asmdef

					RunTime
						<<Owner>>
							<<NewProject>>
								Config.cs
								DebugTool.cs
								Version.cs
						<<Pwner>>.<<NewProject>.asmdef

					CHANGELOG.MD
					LICENSE
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
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("Editor");

			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:","Editor/UpmVersionManagerSetting.cs",false,BlueBack.AssetLib.LineFeedOption.CRLF);

		}
	}
	#endif
}

