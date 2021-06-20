

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

			Assets
				Editor
					UpmVersionManagerSetting.cs

				Samples
					<<Package_Name>>
						000
							xxxx
							yyyy

					Samples.asmdef

				UPM
					Editor
						<<Owner_Name>>
							<<Package_Name>>
								Editor
						<<Owner_Name>>.<<Package_Name>.Editor.asmdef

					RunTime
						<<Owner_Name>>
							<<Package_Name>>
								Config.cs
								DebugTool.cs
								Version.cs
						<<Owner_Name>>.<<Package_Name>.asmdef

					CHANGELOG.md
					LICENSE.md
					package.json
					README.md

				csc.rsp
				server.json
				UpmVersionManagerWindow.uss
				UpmVersionManagerWindow.uxml

		*/
		[UnityEditor.MenuItem("UpmVersionManager/NewProject")]
		private static void MenuItem_NewProject()
		{
			//変換リスト。
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();

			//管理名。
			string t_author_name = "BlueBack";
			t_replace_list.Add("<<Author_Name>>",t_author_name);
			t_replace_list.Add("<<author_name>>",t_author_name.ToLower());
			t_replace_list.Add("<<AUTHOR_NAME>>",t_author_name.ToUpper());

			//管理ＵＲＬ。
			string t_author_url = "https://github.com/bluebackblue";
			t_replace_list.Add("<<author_url>>",t_author_url);

			//パッケージ名。
			string t_package_name = null;
			{
				string t_path = UnityEngine.Application.dataPath;
				string[] t_path_list = t_path.Split(new char[]{'/','\\'});
				t_package_name = t_path_list[t_path_list.Length - 3];
				UnityEngine.Debug.Log("package_name == " + t_package_name);
			}
			t_replace_list.Add("<<Package_Name>>",t_package_name);
			t_replace_list.Add("<<PACKAGE_NAME>>",t_package_name.ToUpper());

			//フォルダの作成（Editor）。
			{
				BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath("Editor");
			}

			//スクリプト作成（UpmVersionManagerSetting.cs）。
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
					"				//author_url",
					"				t_param.author_url = \"<<author_url>>\";",
					"",
					"				//■package_name",
					"				t_param.package_name = \"<<Package_Name>>\";",
					"",
					"				//■getpackageversion",
					"				t_param.getpackageversion = <<Author_Name>>.<<Package_Name>>.Version.GetPackageVersion;",
					"",
					"				//packagejson_unity",
					"				t_param.packagejson_unity = \"\";",
					"",
					"				//■packagejson_discription",
					"				t_param.packagejson_discription = \"\";",
					"",
					"				//■packagejson_keyword",
					"				t_param.packagejson_keyword = new string[]{",
					"				};",
					"",
					"				//■changelog",
					"				t_param.changelog = new string[]{",
					"				};",
					"",
					"				//■readme_md",
					"				t_param.object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{",
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

				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				for(int ii=0;ii<t_text_list.Length;ii++){
					string t_text = t_text_list[ii];
					foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
						t_text = t_text.Replace(t_pair.Key,t_pair.Value);
					}
					t_stringbuilder.Append(t_text);
					t_stringbuilder.Append('\n');
				}

				string t_path = "Editor/UpmVersionManagerSetting.cs";

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//フォルダの作成（UPM/Runtime/<<Author_Name>>/<<Package_Name>>）。
			{
				string t_path = "UPM/Runtime/<<Author_Name>>/<<Package_Name>>";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}
				BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
			}

			//スクリプト作成（UPM/Runtime/<<Author_Name>>/<<Package_Name>>/version.cs）。
			{
				string[] t_text_list = new string[]{
					"",
					"",
					"/**",
					" * Copyright (c) <<author_name>>",
					" * Released under the MIT License",
					" * @brief バージョン。",
					"*/",
					"",
					"",
					"/** <<Author_Name>>.<<Package_Name>>",
					"*/",
					"namespace <<Author_Name>>.<<Package_Name>>",
					"{",
					"	/** Version",
					"	*/",
					"	public class Version",
					"	{",
					"		/** version",
					"		*/",
					"		public const string packageversion = \"0.0.0\";",
					"",
					"		/** GetPackageVersion",
					"		*/",
					"		public static string GetPackageVersion()",
					"		{",
					"			return packageversion;",
					"		}",
					"	}",
					"}",
				};

				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				for(int ii=0;ii<t_text_list.Length;ii++){
					string t_text = t_text_list[ii];
					foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
						t_text = t_text.Replace(t_pair.Key,t_pair.Value);
					}
					t_stringbuilder.Append(t_text);
					t_stringbuilder.Append('\n');
				}

				string t_path = "UPM/Runtime/<<Author_Name>>/<<Package_Name>>/Version.cs";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//フォルダの作成（Samples/<<Package_Name>>/000）。
			{
				string t_path = "Samples/<<Package_Name>>/000";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}
				BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
			}

			//フォルダの作成（UPM/Documentation~）。
			{
				string t_path = "UPM/Documentation~";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}
				BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
			}

			//スクリプト作成（UPM/Runtime/<<Author_Name>>/<<Package_Name>>/version.cs）。
			{
				string[] t_text_list = new string[]{
					"-define:DEF_USER_BLUEBACK",
					"-define:DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_ASSERT",
				};

				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
				for(int ii=0;ii<t_text_list.Length;ii++){
					string t_text = t_text_list[ii];
					foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
						t_text = t_text.Replace(t_pair.Key,t_pair.Value);
					}
					t_stringbuilder.Append(t_text);
					t_stringbuilder.Append('\n');
				}

				string t_path = "csc.rsp";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM\Runtime\BlueBack\AssetLib/Config.cs
			//UPM\Runtime\BlueBack\AssetLib/DebugTool.cs


			/*

			//UPM/LICENSE.md
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_license_md) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_license_md,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//UPM/README.md
			if(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path_readme_md) == false){
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("//TODO:",t_path_readme_md,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}
			*/

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
	#endif
}

