

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。ＵＲＬを開く。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Run_OpenURL
	*/
	public sealed class Execute_Run_OpenURL : Execute_Base
	{
		/** [BlueBack.VersionManager.Editor.Execute_Base]CallBack
		*/
		public void CallBack()
		{
			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			UnityEngine.Application.OpenURL(StaticValue.editor_projectparam_json.git_url);
		}
	}
}
#endif

