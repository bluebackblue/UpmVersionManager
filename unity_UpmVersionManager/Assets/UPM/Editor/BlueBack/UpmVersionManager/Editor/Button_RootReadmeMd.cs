

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ウィンドウ。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Window
	*/
	public class Button_RootReadmeMd
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button,int a_index)
		{
			if(a_button != null){
				string[] t_version_split = Object_RootServerJson.GetInstance().status.lasttag.Split('.');
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
				if(t_version == Object_RootReadmeMd.GetInstance().version){
					a_button.AddToClassList("red");
				}

				//「readme.md」作成。
				a_button.clickable.clicked += () => {

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("RootReadmeMd : " + t_version);
					#endif

					On(t_version);
				};
			}
		}

		/** On
		*/
		private static void On(string a_version)
		{
			Object_RootReadmeMd.Save(a_version);
			Object_RootReadmeMd.GetInstance().Load();
			Window.s_window.OnEnable();

		}
	}
}
#endif
