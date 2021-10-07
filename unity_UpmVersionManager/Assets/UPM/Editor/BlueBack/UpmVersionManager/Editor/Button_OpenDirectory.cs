

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
	public class Button_OpenDirectory
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			if(a_button != null){
				a_button.text = "[OpenDirectory]";
				a_button.clickable.clicked += () => {

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("OpenDirectory");
					#endif

					On();
				};
			}
		}

		/** On
		*/
		private static void On()
		{
			if(Object_Setting.GetInstance() != null){
				System.Diagnostics.Process.Start("explorer","/select," + (UnityEngine.Application.dataPath + "/../").Replace("/","\\"));
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}
	}
}
#endif

