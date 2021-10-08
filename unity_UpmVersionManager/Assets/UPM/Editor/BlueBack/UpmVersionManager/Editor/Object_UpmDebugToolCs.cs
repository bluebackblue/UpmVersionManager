

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
	public static class Object_UpmDebugToolCs
	{
		/** Save
		*/
		public static void Save()
		{
			//path
			string t_path = "UPM/Runtime/" + Object_Setting.s_param.author_name + "/" + Object_Setting.s_param.package_name + "/DebugTool.cs";

			//template
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
				"	public static class DebugTool",
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

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			Object_Setting.AddReplaceList(t_replace_list);

			//SaveUtf8TextToAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			BlueBack.Code.Convert.Replace(t_stringbuilder,t_replace_list,t_template);
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
	}
}
#endif
