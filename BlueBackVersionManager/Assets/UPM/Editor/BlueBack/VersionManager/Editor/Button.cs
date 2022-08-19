

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
	/** Button
	*/
	public sealed class Button
	{
		/** constructor
		*/
		public Button(UnityEngine.UIElements.VisualElement a_root,string a_label,string a_text,string a_class,Execute_Base a_execute)
		{
			UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(a_root,a_label);
			t_button.text = a_text;

			if(a_class != null){
				t_button.AddToClassList(a_class);
			}

			t_button.clickable.clicked += () => {
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(a_text);
				#endif

				a_execute.CallBack();
			};
		}
	}
}
#endif

