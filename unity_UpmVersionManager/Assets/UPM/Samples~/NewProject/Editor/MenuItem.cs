

/** Samples.UpmVersionManager.NewProject.Editor
*/
namespace Samples.UpmVersionManager.NewProject.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** MenuItem_NewProject
		*/
		[UnityEditor.MenuItem("UpmVersionManager/NewProject/CreateUpmVersionManagerSetting")]
		private static void MenuItem_NewProject_CreateUpmVersionManagerSetting()
		{
			string[] t_text_list = new string[]{
				"",
				"",
				"/**",
				" * Copyright (c) <<author_name>>",
				" * Released under the MIT License",
				" * @brief 設定。",
				"*/",
				"",
				"",
				"/** Editor",
				"*/",
				"#if(UNITY_EDITOR)",
				"namespace Editor",
				"{",
				"	/** UpmVersionManagerSetting",
				"	*/",
				"	[UnityEditor.InitializeOnLoad]",
				"	public static class UpmVersionManagerSetting",
				"	{",
				"		/** UpmVersionManagerSetting",
				"		*/",
				"		static UpmVersionManagerSetting()",
				"		{",
				"			//Object_RootUssUxml",
				"			BlueBack.UpmVersionManager.Editor.Object_RootUssUxml.CreateFile(false);",
				"",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.CreateInstance();",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.Param t_param = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param();",
				"			{",
				"				//author_name",
				"				t_param.author_name = \"<<Author_Name>>\";",
				"",
				"				//git_url",
				"				t_param.git_url = \"<<git_url>>\";",
				"",
				"				//git_author",
				"				t_param.git_author = \"<<git_author>>\";",
				"",
				"				//package_name",
				"				t_param.package_name = \"<<Package_Name>>\";",
				"",
				"				//getpackageversion",
				"				t_param.getpackageversion = <<Author_Name>>.<<Package_Name>>.Version.GetPackageVersion;",
				"",
				"				//packagejson_unity",
				"				t_param.packagejson_unity = \"<<NEED_UNITY_VERSION>>\";",
				"",
				"				//packagejson_discription",
				"				t_param.packagejson_discription = \"xxxxxxxxxxxxxxxx\";",
				"",
				"				//packagejson_keyword",
				"				t_param.packagejson_keyword = new string[]{",
				"				};",
				"",
				"				//packagejson_dependencies",
				"				t_param.packagejson_dependencies = new System.Collections.Generic.Dictionary<string,string>(){",
				"					//{\"blueback.xxxxx\",\"https://github.com/xxxxx/xxxxx\"},",
				"				};",
				"",
				"				//asmdef_reference",
				"				t_param.asmdef_reference = new string[]{",
				"",
				"				};",
				"",
				"				//editorasmdef_reference",
				"				t_param.editorasmdef_reference = new string[]{",
				"					\"<<Author_Name>>.<<Package_Name>>\",",
				"				};",
				"",
				"				//changelog",
				"				t_param.changelog = new string[]{",
				"					\"# Changelog\",",
				"					\"\",",
				"",
				"					/*",
				"					\"## [0.0.0] - 0000-00-00\",",
				"					\"### Changes\",",
				"					\"- xxxxxx\",",
				"					\"\",",
				"					*/",
				"",
				"					\"## [0.0.1] - <<DATE>>\",",
				"					\"### Changes\",",
				"					\"- Init\",",
				"					\"\",",
				"				};",
				"",
				"				//readme_md",
				"				t_param.object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{",
				"",
				"					//概要。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"# \" + a_argument.param.author_name + \".\" + a_argument.param.package_name,",
				"							\"xxxxx操作\",",
				"							\"* xxxxxxxxxxxxxxxx\",",
				"							\"* xxxxxxxxxxxxxxxx\",",
				"						};",
				"					},",
				"",
				"					//ライセンス。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## ライセンス\",",
				"							\"MIT License\",",
				"							\"* \" + a_argument.param.git_url + a_argument.param.git_author + \"/\" + a_argument.param.package_name + \"/blob/main/LICENSE\",",
				"						};",
				"					},",
				"",
				"					//依存。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## 外部依存 / 使用ライセンス等\",",
				"							//\"* \" + a_argument.param.git_url + a_argument.param.git_author + \"/\" + \"JsonItem\",",
				"							//\"### サンプルのみ\",",
				"							//\"* \" + a_argument.param.git_url + a_argument.param.git_author + \"/\" + \"AssetLib\",",
				"						};",
				"					},",
				"",
				"					//動作確認。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## 動作確認\",",
				"							\"Unity \" + UnityEngine.Application.unityVersion,",
				"						};",
				"					},",
				"",
				"					//UPM。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## UPM\",",
				"							\"### 最新\",",
				"							\"* \" + a_argument.param.git_url + a_argument.param.git_author + \"/\" + a_argument.param.package_name + \".git?path=unity_\" + a_argument.param.package_name + \"/Assets/UPM#\" + a_argument.version,",
				"							\"### 開発\",",
				"							\"* \" + a_argument.param.git_url + a_argument.param.git_author + \"/\" + a_argument.param.package_name + \".git?path=unity_\" + a_argument.param.package_name + \"/Assets/UPM\",",
				"						};",
				"					},",
				"",
				"					//インストール。 ",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## Unityへの追加方法\",",
				"							\"* Unity起動\",",
				"							\"* メニュー選択：「Window->Package Manager」\",",
				"							\"* ボタン選択：「左上の＋ボタン」\",",
				"							\"* リスト選択：「Add package from git URL...」\",",
				"							\"* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」\",",
				"							\"### 注\",",
				"							\"Gitクライアントがインストールされている必要がある。\",",
				"							\"* https://docs.unity3d.com/ja/current/Manual/upm-git.html\",",
				"							\"* https://git-scm.com/\",",
				"						};",
				"					},",
				"",
				"					//例。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## 例\",",
				"						};",
				"					},",
				"",
				"				};",
				"			}",
				"",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.GetInstance().Set(t_param);",
				"		}",
				"	}",
				"}",
				"#endif",
				"",
				"",
			};

			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				//対応ユニティー。
				t_replace_list.Add("<<NEED_UNITY_VERSION>>","2020.1");

				//管理名。
				t_replace_list.Add("<<Author_Name>>","BlueBack");
				t_replace_list.Add("<<author_name>>","blueback".ToLower());

				//ＧＩＴ。
				t_replace_list.Add("<<git_url>>","https://github.com/");
				t_replace_list.Add("<<git_author>>","bluebackblue");

				//日付。
				t_replace_list.Add("<<DATE>>",System.DateTime.Today.ToString("yyyy-MM-dd"));

				//パッケージ名。
				string t_package_name = null;
				{
					string[] t_path_list = UnityEngine.Application.dataPath.Split(new char[]{'/','\\'});
					t_package_name = t_path_list[t_path_list.Length - 3];
					UnityEngine.Debug.Log("package_name == " + t_package_name);
				}
				t_replace_list.Add("<<Package_Name>>",t_package_name);
				t_replace_list.Add("<<PACKAGE_NAME>>",t_package_name.ToUpper());

			}

			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				for(int ii=0;ii<t_text_list.Length;ii++){
					string t_text = t_text_list[ii];
					foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
						t_text = t_text.Replace(t_pair.Key,t_pair.Value);
					}
					t_stringbuilder.Append(t_text);
					t_stringbuilder.Append('\n');
				}

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),"Editor/UpmVersionManagerSetting.cs",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}
		}
	}
	#endif
}

