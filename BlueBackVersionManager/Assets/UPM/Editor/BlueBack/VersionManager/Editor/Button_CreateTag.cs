

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
	/** Button_CreateTag
	*/
	public static class Button_CreateTag
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[CreateTag]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log("CreateTag");
				#endif

				Object_Setting.projectparam = ProjectParam.Load();
				if(Object_RootServerJson.status == null){
					Object_RootServerJson.Load();
				}

				On();
			};
		}

		/** On
		*/
		private static void On()
		{
			System.Diagnostics.Process.Start("TortoiseGitProc",string.Format("/command:{0} /path:\"{1}\" /name:\"{2}\"","tag",(UnityEngine.Application.dataPath + "/../../").Replace("/","\\"),Object_RootReadmeMd.version));
		}
	}
}
#endif

