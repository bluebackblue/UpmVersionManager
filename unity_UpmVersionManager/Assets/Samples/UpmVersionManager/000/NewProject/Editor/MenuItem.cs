

/** Samples.UpmVersionManager.NewProject.Editor
*/
namespace Samples.UpmVersionManager.NewProject.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
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
				"			BlueBack.UpmVersionManager.Editor.Object_RootUssUxml.Save(false);",
				"",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.s_param = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param();",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.Param t_param = BlueBack.UpmVersionManager.Editor.Object_Setting.s_param;",
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
				"				//git_path",
				"				t_param.git_path = \"<<git_path>>\";",
				"",
				"				//package_name",
				"				t_param.package_name = \"<<Package_Name>>\";",
				"",
				"				//packagejson_unity",
				"				t_param.packagejson_unity = \"<<NEED_UNITY_VERSION>>\";",
				"",
				"				//packagejson_discription",
				"				t_param.packagejson_discription = \"<<discription>>\";",
				"",
				"				//packagejson_keyword",
				"				t_param.packagejson_keyword = new string[]{",
				"					<<keyword>>",
				"				};",
				"",
				"				//packagejson_dependencies",
				"				t_param.packagejson_dependencies = new System.Collections.Generic.Dictionary<string,string>(){",
				"					//{\"xxxxx.xxxxx\",\"https://github.com/xxxxx/xxxxx\"},",
				"				};",
				"",
				"				//root_readmemd_path",
				"				t_param.root_readmemd_path = \"<<root_readmemd_path>>\";",
				"",
				"				//asmdef_runtime",
				"				t_param.asmdef_runtime = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{",
				"					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{",
				"					},",
				"					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{",
				"					},",
				"				};",
				"",
				"				//asmdef_editor",
				"				t_param.asmdef_editor = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{",
				"					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{",
				"						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){",
				"							package_name = \"<<Author_Name>>.<<Package_Name>>\",",
				"							url = \"<<git_url>><<git_author>>/<<Package_Name>>\",",
				"						},",
				"					},",
				"					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{",
				"					},",
				"				};",
				"",
				"				//asmdef_sample",
				"				t_param.asmdef_sample = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefItem{",
				"					reference_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem[]{",
				"						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){",
				"							package_name = \"<<Author_Name>>.<<Package_Name>>\",",
				"							url = \"<<git_url>><<git_author>>/<<Package_Name>>\",",
				"						},",
				"						new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefReferenceItem(){",
				"							package_name = \"<<Author_Name>>.<<Package_Name>>.Editor\",",
				"							url = \"<<git_url>><<git_author>>/<<Package_Name>>\",",
				"						},",
				"					},",
				"					versiondefine_list = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param.AsmdefVersionDefineItem[]{",
				"					},",
				"				};",
				"",
				"				//changelog",
				"				t_param.changelog = new string[]{",
				"					\"# Changelog\",",
				"					\"\",",
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
				"							\"# \" + t_param.author_name + \".\" + t_param.package_name,",
				"							<<overview>>",
				"						};",
				"					},",
				"",
				"					//ライセンス。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## ライセンス\",",
				"							\"MIT License\",",
				"							\"* \" + t_param.git_url + t_param.git_author + \"/\" + t_param.package_name + \"/blob/main/LICENSE\",",
				"						};",
				"					},",
				"",
				"					//依存。",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"						t_list.Add(\"## 依存 / 使用ライセンス等\");",
				"						t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Asmdef_Dependence(a_argument));",
				"						return t_list.ToArray();",
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
				"							\"* \" + t_param.git_url + t_param.git_author + \"/\" + t_param.package_name + \".git?path=\" + t_param.git_path + \"#\" + a_argument.version,",
				"							\"### 開発\",",
				"							\"* \" + t_param.git_url + t_param.git_author + \"/\" + t_param.package_name + \".git?path=\" + t_param.git_path,",
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
				"					#if(false)",
				"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"						return new string[]{",
				"							\"## 例\",",
				"							\"```\",",
				"							\"```\",",
				"						};",
				"					},",
				"					#endif",
				"				};",
				"			}",
				"		}",
				"	}",
				"}",
				"#endif",
				"",
			};

			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				string t_path = "Editor/NewProjectParam.json";

				NewProjectParam t_param = NewProjectParam.CreateDefault();
				{
					bool t_para_success = false;
					string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8);
					if(t_jsonstring != null){
						t_jsonstring = BlueBack.JsonItem.Normalize.Convert(t_jsonstring);
						if(t_jsonstring != null){
							t_param = BlueBack.JsonItem.Convert.JsonStringToObject<NewProjectParam>(t_jsonstring);
							t_para_success = true;
							{
								if(t_param.package_name == null){
									t_para_success = false;
								}
								if(t_param.author_name == null){
									t_para_success = false;
								}
								if(t_para_success == false){
									t_param = NewProjectParam.CreateDefault();
								}
							}
						}
					}

					if(t_para_success == false){
						string t_text = BlueBack.JsonItem.Pretty.Convert(BlueBack.JsonItem.Convert.ObjectToJsonString<NewProjectParam>(t_param),"   ");
						BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					}

					{
						//パッケージ名。
						t_replace_list.Add("<<Package_Name>>",t_param.package_name);
						t_replace_list.Add("<<PACKAGE_NAME>>",t_param.package_name.ToUpper());

						//対応ユニティー。
						t_replace_list.Add("<<NEED_UNITY_VERSION>>",t_param.need_unity_version);

						//管理名。
						t_replace_list.Add("<<Author_Name>>",t_param.author_name);
						t_replace_list.Add("<<author_name>>",t_param.author_name.ToLower());

						//ＧＩＴ。
						t_replace_list.Add("<<git_url>>",t_param.git_url);
						t_replace_list.Add("<<git_author>>",t_param.git_author);
						t_replace_list.Add("<<git_path>>",t_param.git_path);

						//説明。
						t_replace_list.Add("<<discription>>",t_param.discription);

						//ルート用「README.md」パス。
						t_replace_list.Add("<<root_readmemd_path>>",t_param.root_readmemd_path);

						//キーワード。
						{
							string t_keyword_list = "";
							foreach(string t_keyword in t_param.keyword){
								t_keyword_list += "\"" + t_keyword + "\",";
							}
							t_replace_list.Add("<<keyword>>",t_keyword_list);
						}

						//概要。
						{
							string t_overview_list = "";
							for(int ii=0;ii<t_param.overview.Length;ii++){
								if(ii == 0){
									t_overview_list += "\"" + t_param.overview[ii] + "\",";
								}else{
									t_overview_list += "							\"" + t_param.overview[ii] + "\",";
								}
								if(ii < t_param.overview.Length - 1){
									t_overview_list += "\n";
								}
							}
							t_replace_list.Add("<<overview>>",t_overview_list);
						}

						//日付。
						t_replace_list.Add("<<DATE>>",System.DateTime.Today.ToString("yyyy-MM-dd"));
					}
				}
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
				string t_path = "Editor/UpmVersionManagerSetting.cs";

				BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),"Editor/UpmVersionManagerSetting.cs",false,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}
		}
	}
	#endif
}

