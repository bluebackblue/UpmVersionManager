

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
			BlueBack.UpmVersionManager.Editor.Object_RootUssUxml.CreateFile(false);

			BlueBack.UpmVersionManager.Editor.Object_Setting.CreateInstance();
			BlueBack.UpmVersionManager.Editor.Object_Setting.Param t_param = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param();
			{
				//author_name
				t_param.author_name = "BlueBack";

				//git_url
				t_param.git_url = "https://github.com/";

				//git_author
				t_param.git_author = "bluebackblue";

				//git_path
				t_param.git_path = "unity_UpmVersionManager/Assets/UPM";

				//package_name
				t_param.package_name = "UpmVersionManager";

				//packagejson_unity
				t_param.packagejson_unity = "2020.1";

				//packagejson_discription
				t_param.packagejson_discription = "UPMバージョン操作";

				//packagejson_keyword
				t_param.packagejson_keyword = new string[]{
					"upm",
				};

				//packagejson_dependencies
				t_param.packagejson_dependencies = new System.Collections.Generic.Dictionary<string,string>(){
					//{"xxxxx.xxxxx","https://github.com/xxxxx/xxxxx"},
				};

				//root_readmemd_path
				t_param.root_readmemd_path = "../../README.md";

				//asmdef_runtime
				t_param.asmdef_runtime = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{
					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{
					},
					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{
					},
				};

				//asmdef_editor
				t_param.asmdef_editor = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{
					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.UpmVersionManager",
							url = "https://github.com/bluebackblue/UpmVersionManager",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.AssetLib",
							url = "https://github.com/bluebackblue/AssetLib",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.AssetLib.Editor",
							url = "https://github.com/bluebackblue/AssetLib",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.JsonItem",
							url = "https://github.com/bluebackblue/JsonItem",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.Code",
							url = "https://github.com/bluebackblue/Code",
						},
					},
					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{
					},
				};

				//asmdef_sample
				t_param.asmdef_sample = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{
					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.UpmVersionManager",
							url = "https://github.com/bluebackblue/UpmVersionManager",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.UpmVersionManager.Editor",
							url = "https://github.com/bluebackblue/UpmVersionManager",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.AssetLib",
							url = "https://github.com/bluebackblue/AssetLib",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.AssetLib.Editor",
							url = "https://github.com/bluebackblue/AssetLib",
						},
						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){
							package_name = "BlueBack.JsonItem",
							url = "https://github.com/bluebackblue/JsonItem",
						},
					},
					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{
					},
				};

				//changelog
				t_param.changelog = new string[]{
					"# Changelog",
					"",

					"## [0.0.1] - 2021-10-08",
					"### Changes",
					"- Init",
					"",
				};

				//readme_md
				t_param.object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{

					//概要。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"# " + a_argument.param.author_name + "." + a_argument.param.package_name,
							"UPMバージョン操作",
							"* package.json出力",
						};
					},

					//ライセンス。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## ライセンス",
							"MIT License",
							"* " + a_argument.param.git_url + a_argument.param.git_author + "/" + a_argument.param.package_name + "/blob/main/LICENSE",
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
							"* " + a_argument.param.git_url + a_argument.param.git_author + "/" + a_argument.param.package_name + ".git?path=" + a_argument.param.git_path + "#" + a_argument.version,
							"### 開発",
							"* " + a_argument.param.git_url + a_argument.param.git_author + "/" + a_argument.param.package_name + ".git?path=" + a_argument.param.git_path,
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
					#if(false)
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## 例",
							"```",
							"```",
						};
					},
					#endif

				};
			}

			BlueBack.UpmVersionManager.Editor.Object_Setting.GetInstance().Set(t_param);
		}
	}
}
#endif

