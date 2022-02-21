

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
	/** Button_RootReadmeMd
	*/
	public static class Button_RootReadmeMd
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button,int a_index)
		{
			string[] t_version_split = Object_RootServerJson.s_status.lasttag.Split('.');
			int t_version_split_item2 = int.Parse(t_version_split[2]);

			string t_version;

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
					t_version = "";
					UnityEngine.Debug.Assert(false);
				}break;
			}

			a_button.text = t_version;

			if(Object_RootReadmeMd.s_version == null){
				Object_RootReadmeMd.Load();
			}

			if(t_version == Object_RootReadmeMd.s_version){
				a_button.AddToClassList("red");
			}

			//「readme.md」作成。
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_VERSIONMANAGER_LOG)
				DebugTool.Log("RootReadmeMd : " + t_version);
				#endif

				Object_Setting.s_projectparam = ProjectParam.Load();
				if(Object_RootServerJson.s_status == null){
					Object_RootServerJson.Load();
				}

				On(t_version);
			};
		}

		/** On
		*/
		private static void On(string a_version)
		{
			Object_RootReadmeMd.Save(a_version);
			Object_RootReadmeMd.Load();
			Window.s_window.OnEnable();
		}
	}
}
#endif

