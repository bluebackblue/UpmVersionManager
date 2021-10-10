

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
				"			//projectparam",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam = BlueBack.UpmVersionManager.Editor.ProjectParam.Load();",
				"",
				"			//s_object_root_readme_md",
				"			BlueBack.UpmVersionManager.Editor.Object_Setting.s_object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{",
				"",
				"				//概要。",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"					t_list.Add(\"# \" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.namespace_author + \".\" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.namespace_package);",
				"					t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Overview(a_argument));",
				"					return t_list.ToArray();",
				"				},",
				"",
				"				//ライセンス。",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## ライセンス\",",
				"						\"MIT License\",",
				"						\"* \" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + \"/blob/main/LICENSE\",",
				"					};",
				"				},",
				"",
				"				//依存。",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();",
				"					t_list.Add(\"## 依存 / 使用ライセンス等\");",
				"					t_list.AddRange(BlueBack.UpmVersionManager.Editor.Object_Setting.Create_RootReadMd_Asmdef_Dependence(a_argument));",
				"					return t_list.ToArray();",
				"				},",
				"",
				"				//動作確認。",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## 動作確認\",",
				"						\"Unity \" + UnityEngine.Application.unityVersion,",
				"					};",
				"				},",
				"",
				"				//UPM。",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## UPM\",",
				"						\"### 最新\",",
				"						\"* \" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + \".git?path=\" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_path + \"#\" + a_argument.version,",
				"						\"### 開発\",",
				"						\"* \" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_url + \".git?path=\" + BlueBack.UpmVersionManager.Editor.Object_Setting.s_projectparam.git_path,",
				"					};",
				"				},",
				"",
				"				//インストール。 ",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
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
				"				#if(false)",
				"				(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
				"					return new string[]{",
				"						\"## 例\",",
				"						\"```\",",
				"						\"```\",",
				"					};",
				"				},",
				"				#endif",
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
								if((t_param.namespace_author == null)||(t_param.namespace_package == null)){
									t_para_success = false;
								}
								if(t_para_success == false){
									t_param = NewProjectParam.CreateDefault();
								}
							}
						}
					}

					if(t_para_success == false){
						string t_text = BlueBack.JsonItem.Pretty.Convert(BlueBack.JsonItem.Convert.ObjectToJsonString<NewProjectParam>(t_param),"    ");
						BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					}

					{
						//ネームスペース。
						t_replace_list.Add("<<NameSpace_Author>>",t_param.namespace_author);
						t_replace_list.Add("<<NAMESPACE_AUTHOR>>",t_param.namespace_author.ToUpper());
						t_replace_list.Add("<<namespace_author>>",t_param.namespace_author.ToLower());
						t_replace_list.Add("<<NameSpace_Package>>",t_param.namespace_package);
						t_replace_list.Add("<<NAMESPACE_PACKAGE>>",t_param.namespace_package.ToUpper());
						t_replace_list.Add("<<namespace_package>>",t_param.namespace_package.ToLower());

						//対応ユニティー。
						t_replace_list.Add("<<need_unity_version>>",t_param.need_unity_version);

						//ＧＩＴ。
						t_replace_list.Add("<<git_url>>",t_param.git_url);
						t_replace_list.Add("<<git_api>>",t_param.git_api);
						t_replace_list.Add("<<git_path>>",t_param.git_path);

						//説明。
						t_replace_list.Add("<<discription>>",t_param.discription);

						//ルート用「README.md」パス。
						t_replace_list.Add("<<root_readmemd_path>>",t_param.root_readmemd_path);

						{
							t_replace_list.Add("<<asmdef_runtime_reference_list>>","");
						}
						{
							t_replace_list.Add("<<asmdef_editor_reference_list>>","");
						}
						{
							t_replace_list.Add("<<asmdef_sample_reference_list>>","");
						}

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

