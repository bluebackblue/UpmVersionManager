

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 設定。
*/


/** Editor
*/
#if(UNITY_EDITOR)
namespace Editor
{
	/** UpmVersionManagerSetting
	*/
	[UnityEditor.InitializeOnLoad]
	public static class UpmVersionManagerSetting
	{
		/** UpmVersionManagerSetting
		*/
		static UpmVersionManagerSetting()
		{
			//Object_RootUssUxml
			BlueBack.UpmVersionManager.Editor.Object_RootUssUxml.Save(false);

			//projectparam
			BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam = BlueBack.UpmVersionManager.Editor.ProjectParam.Load();

			//s_object_root_readme_md
			BlueBack.UpmVersionManager.Editor.Object_Setting.s_object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{

				//概要。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("# " + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.namespace_author + "." + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.namespace_package);
					t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Overview(a_argument));
					return t_list.ToArray();
				},

				//ライセンス。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## ライセンス",
						"MIT License",
						"* " + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + "/blob/main/LICENSE",
					};
				},

				//依存。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("## 依存 / 使用ライセンス等");
					t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Asmdef_Dependence(a_argument));
					return t_list.ToArray();
				},

				//動作確認。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## 動作確認",
						"Unity " + UnityEngine.Application.unityVersion,
					};
				},

				//UPM。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## UPM",
						"### 最新",
						"* " + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + ".git?path=" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_path + "#" + a_argument.version,
						"### 開発",
						"* " + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + ".git?path=" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_path,
					};
				},

				//インストール。 
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## Unityへの追加方法",
						"* Unity起動",
						"* メニュー選択：「Window->Package Manager」",
						"* ボタン選択：「左上の＋ボタン」",
						"* リスト選択：「Add package from git URL...」",
						"* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」",
						"### 注",
						"Gitクライアントがインストールされている必要がある。",
						"* https://docs.unity3d.com/ja/current/Manual/upm-git.html",
						"* https://git-scm.com/",
					};
				},

				//例。
				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Exsample(a_argument));
					return t_list.ToArray();
				},
			};
		}
	}
}
#endif

