

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ボタン。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Button_ConvertToUtf8
	*/
	public static class Button_ConvertToUtf8
	{
		/** Initialize
		*/
		public static void Initialize(UnityEngine.UIElements.Button a_button)
		{
			a_button.text = "[Convert]";
			a_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_LOG)
				DebugTool.Log("Convert");
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
			BlueBack.AssetLib.Editor.TextConvertWithAssetsPath.ConvertAll("",".*","^.*\\.(cs|meta|mesh|prefab|json|asmdef|mixer|anim)$",new System.Text.UTF8Encoding(false),BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.Code.Editor.CodeConvert.Convert();
			Window.window.OnEnable();
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

