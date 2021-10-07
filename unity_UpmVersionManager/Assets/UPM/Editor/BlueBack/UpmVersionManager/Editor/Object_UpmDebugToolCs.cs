

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Runtime/<<author_name>>/<<package_name>>/Version.cs」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmDebugToolCs
	*/
	public class Object_UpmDebugToolCs
	{
		/** constructor
		*/
		public Object_UpmDebugToolCs()
		{
		}

		/** Save
		*/
		public static void Save()
		{
			if(Object_Setting.GetInstance() != null){
				//「UPM/Runtime/.../Version.cs」。
				{
					System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();

					BlueBack.Code.Convert.Add(t_template,new string[]{
						"",
						"",
						"/**",
						" * Copyright (c) <<authorname>>",
						" * Released under the MIT License",
						" * @brief デバッグツール。自動生成。",
						"*/",
						"",
						"",
						"/** <<AuthorName>>.<<PackageName>>",
						"*/",
						"namespace <<AuthorName>>.<<PackageName>>",
						"{",
						"	/** DebugTool",
						"	*/",
						"	public class DebugTool",
						"	{",
						"		/** s_AssertProc",
						"		*/",
						"		#if(DEF_<<AUTHORNAME>>_<<PACKAGENAME>>_ASSERT)",
						"		public static void DefaultAssertProc(System.Exception a_exception,string a_message)",
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
						"		public delegate void AssertProcType(System.Exception a_exception,string a_message);",
						"		public static AssertProcType s_AssertProc = DefaultAssertProc;",
						"		#endif",
						"",
						"		/** s_LogProc",
						"		*/",
						"		#if(DEF_<<AUTHORNAME>>_<<PACKAGENAME>>_LOG)",
						"		public static void DefaultLogProc(string a_message)",
						"		{",
						"			UnityEngine.Debug.Log(a_message);",
						"		}",
						"		public delegate void LogProcType(string a_message);",
						"		public static LogProcType s_LogProc = DebugTool.DefaultLogProc;",
						"		#endif",
						"",
						"		/** Assert",
						"		*/",
						"		#if(DEF_<<AUTHORNAME>>_<<PACKAGENAME>>_ASSERT)",
						"		public static void Assert(bool a_flag,System.Exception a_exception = null)",
						"		{",
						"			if(a_flag != true){",
						"				s_AssertProc(a_exception,null);",
						"			}",
						"		}",
						"		#endif",
						"",
						"		/** Assert",
						"		*/",
						"		#if(DEF_<<AUTHORNAME>>_<<PACKAGENAME>>_ASSERT)",
						"		public static void Assert(bool a_flag,string a_message)",
						"		{",
						"			if(a_flag != true){",
						"				s_AssertProc(null,a_message);",
						"			}",
						"		}",
						"		#endif",
						"",
						"		#if(DEF_<<AUTHORNAME>>_<<PACKAGENAME>>_LOG)",
						"		public static void Log(string a_message)",
						"		{",
						"			s_LogProc(a_message);",
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

					});


					System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
					{
						t_replace_list.Add("<<PACKAGENAME>>",Object_Setting.GetInstance().param.package_name.ToUpper());
						t_replace_list.Add("<<PackageName>>",Object_Setting.GetInstance().param.package_name);
						t_replace_list.Add("<<AUTHORNAME>>",Object_Setting.GetInstance().param.author_name.ToUpper());
						t_replace_list.Add("<<AuthorName>>",Object_Setting.GetInstance().param.author_name);
						t_replace_list.Add("<<authorname>>",Object_Setting.GetInstance().param.author_name.ToLower());
					}

					string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/DebugTool.cs";

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					BlueBack.Code.Convert.Replace(t_stringbuilder,t_replace_list,t_template);
					BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_path);
					#endif
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}
	}
}
#endif

