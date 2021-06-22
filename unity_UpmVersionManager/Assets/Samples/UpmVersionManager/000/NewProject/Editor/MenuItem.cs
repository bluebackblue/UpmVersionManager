

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
		[UnityEditor.MenuItem("UpmVersionManager/NewProject")]
		private static void MenuItem_NewProject()
		{
			//変換リスト。
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();

			//対応ユニティー。
			t_replace_list.Add("<<NEED_UNITY_VERSION>>","2020.1");

			//管理名。
			string t_author_name = "BlueBack";
			t_replace_list.Add("<<Author_Name>>",t_author_name);
			t_replace_list.Add("<<author_name>>",t_author_name.ToLower());
			t_replace_list.Add("<<AUTHOR_NAME>>",t_author_name.ToUpper());

			//管理ＵＲＬ。
			string t_author_url = "https://github.com/bluebackblue";
			t_replace_list.Add("<<author_url>>",t_author_url);

			//日付。
			t_replace_list.Add("<<DATE>>",System.DateTime.Today.ToString("yyyy-MM-dd"));

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
					"							\"* \" + a_argument.param.author_url + \"/\" + a_argument.param.package_name + \"/blob/main/LICENSE\",",
					"						};",
					"					},",
					"",
					"					//依存。",
					"					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {",
					"						return new string[]{",
					"							\"## 外部依存 / 使用ライセンス等\",",
					"							//\"* \" + a_argument.param.author_url + \"/\" + \"JsonItem\",",
					"							//\"### サンプルのみ\",",
					"							//\"* \" + a_argument.param.author_url + \"/\" + \"AssetLib\",",
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
					"							\"* \" + a_argument.param.author_url + \"/\" + a_argument.param.package_name + \".git?path=unity_\" + a_argument.param.package_name + \"/Assets/UPM#\" + a_argument.version,",
					"							\"### 開発\",",
					"							\"* \" + a_argument.param.author_url + \"/\" + a_argument.param.package_name + \".git?path=unity_\" + a_argument.param.package_name + \"/Assets/UPM\",",
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
					"-define:DEF_USER_<<AUTHOR_NAME>>",
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

			//スクリプト作成（UPM/Runtime/<<Author_Name>>/<<Package_Name>>/Config.cs）。
			{
				string[] t_text_list = new string[]{
					"",
					"",
					"/**",
					" * Copyright (c) <<author_name>>",
					" * Released under the MIT License",
					" * @brief コンフィグ。",
					"*/",
					"",
					"",
					"/** <<Author_Name>>.<<Package_Name>>",
					"*/",
					"namespace <<Author_Name>>.<<Package_Name>>",
					"{",
					"	/** Config",
					"	*/",
					"	public class Config",
					"	{",
					"		/** ERRORPROC",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_ASSERT)",
					"		public delegate void ErrorProcType(System.Exception a_exception,string a_message);",
					"		public static ErrorProcType ERRORPROC = DebugTool.ErrorProc;",
					"		#endif",
					"",
					"		/** LOGPROC",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_LOG)",
					"		public delegate void LogProcType(string a_message);",
					"		public static LogProcType LOGPROC = DebugTool.LogProc;",
					"		#endif",
					"	}",
					"}",
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

				string t_path = "UPM/Runtime/<<Author_Name>>/<<Package_Name>>/Config.cs";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//スクリプト作成（UPM/Runtime/<<Author_Name>>/<<Package_Name>>/DebugTool.cs）。
			{
				string[] t_text_list = new string[]{
					"",
					"",
					"/**",
					" * Copyright (c) <<author_name>>",
					" * Released under the MIT License",
					" * @brief デバッグツール。",
					"*/",
					"",
					"",
					"/** <<Author_Name>>.<<Package_Name>>",
					"*/",
					"namespace <<Author_Name>>.<<Package_Name>>",
					"{",
					"	/** DebugTool",
					"	*/",
					"	public class DebugTool",
					"	{",
					"		/** Assert",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_ASSERT)",
					"		public static void Assert(bool a_flag,System.Exception a_exception = null)",
					"		{",
					"			if(a_flag != true){",
					"				Config.ERRORPROC(a_exception,null);",
					"			}",
					"		}",
					"		#endif",
					"",
					"		/** Assert",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_ASSERT)",
					"		public static void Assert(bool a_flag,string a_message)",
					"		{",
					"			if(a_flag != true){",
					"				Config.ERRORPROC(null,a_message);",
					"			}",
					"		}",
					"		#endif",
					"",
					"		/** ErrorProc",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_ASSERT)",
					"		public static void ErrorProc(System.Exception a_exception,string a_message)",
					"		{",
					"			if(a_message != null){",
					"				UnityEngine.Debug.LogError(a_message);",
					"			}",
					"",
					"			if(a_exception != null){",
					"				UnityEngine.Debug.LogError(a_exception.ToString());",
					"			}",
					"",
					"			UnityEngine.Debug.Assert(false);",
					"		}",
					"		#endif",
					"",
					"		/** LogProc",
					"		*/",
					"		#if(DEF_<<AUTHOR_NAME>>_<<PACKAGE_NAME>>_LOG)",
					"		public static void LogProc(string a_message)",
					"		{",
					"			UnityEngine.Debug.Log(a_message);",
					"		}",
					"		#endif",
					"",
					"		/** EditorLog",
					"		*/",
					"		#if(UNITY_EDITOR)",
					"		public static void EditorLog(string a_text)",
					"		{",
					"			UnityEngine.Debug.Log(a_text);",
					"		}",
					"		#endif",
					"",
					"		/** EditorLogError",
					"		*/",
					"		#if(UNITY_EDITOR)",
					"		public static void EditorLogError(string a_text)",
					"		{",
					"			UnityEngine.Debug.LogError(a_text);",
					"		}",
					"		#endif",
					"	}",
					"}",
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

				string t_path = "UPM/Runtime/<<Author_Name>>/<<Package_Name>>/DebugTool.cs";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_path = t_path.Replace(t_pair.Key,t_pair.Value);
				}

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//Asmdef作成（Samples/Samples.asmdef）。
			{
				string t_name = "Samples";

				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_AssociativeArray());
				{
					t_jsonitem.AddItem("name",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_StringData(t_name)),false);
					t_jsonitem.AddItem("rootNamespace",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_StringData("")),false);
					t_jsonitem.AddItem("references",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("includePlatforms",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("excludePlatforms",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("allowUnsafeCode",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
					t_jsonitem.AddItem("overrideReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
					t_jsonitem.AddItem("precompiledReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("autoReferenced",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(true)),false);
					t_jsonitem.AddItem("defineConstraints",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("versionDefines",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("noEngineReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
				}

				string t_path = "Samples/" + t_name + ".asmdef";
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonitem.ConvertToJsonString().ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			//Asmdef作成（UPM/Runtime/<<Author_Name>>.<<Package_Name>>.asmdef）。
			{
				string t_name = "<<Author_Name>>.<<Package_Name>>";
				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
					t_name = t_name.Replace(t_pair.Key,t_pair.Value);
				}

				BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_AssociativeArray());
				{
					t_jsonitem.AddItem("name",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_StringData(t_name)),false);
					t_jsonitem.AddItem("rootNamespace",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_StringData("")),false);
					t_jsonitem.AddItem("references",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("includePlatforms",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("excludePlatforms",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("allowUnsafeCode",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
					t_jsonitem.AddItem("overrideReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
					t_jsonitem.AddItem("precompiledReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("autoReferenced",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(true)),false);
					t_jsonitem.AddItem("defineConstraints",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("versionDefines",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_IndexArray()),false);
					t_jsonitem.AddItem("noEngineReferences",new BlueBack.JsonItem.JsonItem(new BlueBack.JsonItem.Value_Number<bool>(false)),false);
				}

				string t_path = "UPM/Runtime/" + t_name + ".asmdef";
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonitem.ConvertToJsonString().ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
	#endif
}

