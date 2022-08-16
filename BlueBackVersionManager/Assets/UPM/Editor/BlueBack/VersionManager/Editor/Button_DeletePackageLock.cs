

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Button_DeletePackageLock
	*/
	public static class Button_DeletePackageLock
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[DeletePackageLock]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log("DeletePackageLock");
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
		#if(ASMDEF_TRUE)
		{
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.TryDelete("../Packages/packages-lock.json");
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

