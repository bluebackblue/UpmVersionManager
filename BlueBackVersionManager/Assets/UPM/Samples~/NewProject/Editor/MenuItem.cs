

/** Samples.VersionManager.NewProject
*/
namespace Samples.VersionManager.NewProject
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** MenuItem_NewProject
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.VersionManager/NewProject/CreateVersionManagerSetting")]
		private static void MenuItem_CreateVersionManagerSetting()
		{
			string[] t_text_list = new string[]{
				"",
				"",
				"/**",
				"	Copyright (c) blueback",
				"	Released under the MIT License",
				"	@brief 設定。",
				"*/",
				"",
				"",
				"/** Editor",
				"*/",
				"#if(UNITY_EDITOR)",
				"namespace Editor",
				"{",
				"	/** VersionManagerSetting",
				"	*/",
				"	[UnityEditor.InitializeOnLoad]",
				"	public static class VersionManagerSetting",
				"	{",
				"		/** VersionManagerSetting",
				"		*/",
				"		static VersionManagerSetting()",
				"		{",
				"			//Object_RootUssUxml",
				"			BlueBack.VersionManager.Editor.Object_RootUssUxml.Save(false);",
				"",
				"			//projectparam",
				"			BlueBack.VersionManager.Editor.Object_Setting.s_projectparam = BlueBack.VersionManager.Editor.ProjectParam.Load();",
				"",
				"			//s_object_root_readme_md",
				"			BlueBack.VersionManager.Editor.Object_Setting.s_object_root_readme_md = new BlueBack.VersionManager.Editor.Object_Setting.Creator_Type[]{",
				"",
				"				//概要。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"					t_list.Add(\"# \" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.namespace_author + \".\" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.namespace_package);",
				"					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Overview(a_argument));",
				"					return t_list.ToArray();",
				"				},",
				"",
				"				//ライセンス。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## ライセンス\",",
				"						\"MIT License\",",
				"						\"* \" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.git_url + \"/blob/main/LICENSE\",",
				"					};",
				"				},",
				"",
				"				//依存。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"					t_list.Add(\"## 依存 / 使用ライセンス等\");",
				"					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Asmdef_Dependence(a_argument));",
				"					return t_list.ToArray();",
				"				},",
				"",
				"				//動作確認。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## 動作確認\",",
				"						\"Unity \" + UnityEngine.Application.unityVersion,",
				"					};",
				"				},",
				"",
				"				//UPM。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## UPM\",",
				"						\"### 最新\",",
				"						\"* \" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.git_url + \".git?path=\" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.git_path + \"#\" + a_argument.version,",
				"						\"### 開発\",",
				"						\"* \" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.git_url + \".git?path=\" + BlueBack.VersionManager.Editor.Object_Setting.s_projectparam.git_path,",
				"					};",
				"				},",
				"",
				"				//インストール。 ",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## Unityへの追加方法\",",
				"						\"* Unity起動\",",
				"						\"* メニュー選択：「Window->Package Manager」\",",
				"						\"* ボタン選択：「左上の＋ボタン」\",",
				"						\"* リスト選択：「Add package from git URL...」\",",
				"						\"* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」\",",
				"						\"### 注\",",
				"						\"Gitクライアントがインストールされている必要がある。\",",
				"						\"* https://docs.unity3d.com/ja/current/Manual/upm-git.html\",",
				"						\"* https://git-scm.com/\",",
				"					};",
				"				},",
				"",
				"				//例。",
				"				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Exsample(a_argument));",
				"					return t_list.ToArray();",
				"				},",
				"			};",
				"		}",
				"	}",
				"}",
				"#endif",
				"",
			};

			//projectparam
			BlueBack.VersionManager.Editor.ProjectParam t_projectparam = BlueBack.VersionManager.Editor.ProjectParam.Load();

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
			}

			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			{
				for(int ii=0;ii<t_text_list.Length;ii++){
					string t_text = t_text_list[ii];
					foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
						t_text = t_text.Replace(t_pair.Key,t_pair.Value);
					}
					t_stringbuilder.Append(t_text);
					t_stringbuilder.Append('\n');
				}
			}

			{
				//path
				string t_path = "Editor/VersionManagerSetting.cs";

				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),"Editor/VersionManagerSetting.cs",BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}
		}
	}
	#endif
}

