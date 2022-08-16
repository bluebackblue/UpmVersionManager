

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/Version.cs」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_CODE||USERDEF_BLUEBACK_CODE))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_UpmDebugToolCs
	*/
	public static class Object_UpmDebugToolCs
	{
		/** Save
		*/
		public static void Save()
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = Object_Setting.Reprece("UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/DebugTool.cs");

			//template
			System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();
			BlueBack.Code.Convert.Add(t_template,null,new string[]{
				"",
				"",
				"/**",
				"	Copyright (c) <<namespace_author>>",
				"	Released under the MIT License",
				"	@brief デバッグツール。自動生成。",
				"*/",
				"",
				"",
				"/** define",
				"*/",
				"#if((ASMDEF_BLUEBACK_DEBUG||USERDEF_BLUEBACK_DEBUG))",
				"#define ASMDEF_TRUE",
				"#else",
				"#warning \"ASMDEF_TRUE\"",
				"#endif",
				"",
				"",
				"/** <<NameSpace_Author>>.<<NameSpace_Package>>",
				"*/",
				"namespace <<NameSpace_Author>>.<<NameSpace_Package>>",
				"{",
				"	/** DebugTool",
				"	*/",
				"	public static class DebugTool",
				"	{",
				"		#if(DEF_BLUEBACK_DEBUG_ASSERT)",
				"",
				"		/** assertproc",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Assert.ProcType assertproc = BlueBack.Debug.Assert.Default;",
				"		#endif",
				"",
				"		/** Assert",
				"		*/",
				"		public static void Assert(bool a_flag,System.Exception a_exception = null)",
				"		{",
				"			if(a_flag != true){",
				"				#if(ASMDEF_TRUE)",
				"				DebugTool.assertproc(null,a_exception);",
				"				#endif",
				"			}",
				"		}",
				"",
				"		/** Assert",
				"		*/",
				"		public static void Assert(bool a_flag,string a_message)",
				"		{",
				"			if(a_flag != true){",
				"				#if(ASMDEF_TRUE)",
				"				DebugTool.assertproc(a_message,null);",
				"				#endif",
				"			}",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(DEF_BLUEBACK_DEBUG_LOG)",
				"",
				"		/** logproc",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Log.ProcType logproc = BlueBack.Debug.Log.Default;",
				"		#endif",
				"",
				"		/** Log",
				"		*/",
				"		public static void Log(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.logproc(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(DEF_BLUEBACK_DEBUG_DETAIL)",
				"",
				"		/** detailproc",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Detail.ProcType detailproc = BlueBack.Debug.Detail.Default;",
				"		#endif",
				"",
				"		/** Detail",
				"		*/",
				"		public static void Detail(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.detailproc(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(UNITY_EDITOR)",
				"",
				"		/** editorlogproc",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Log.ProcType editorlogproc = BlueBack.Debug.Log.Default;",
				"		#endif",
				"",
				"		/** editorerrorlogproc",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.ErrorLog.ProcType editorerrorlogproc = BlueBack.Debug.ErrorLog.Default;",
				"		#endif",
				"",
				"		/** EditorLog",
				"		*/",
				"		public static void EditorLog(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.editorlogproc(a_message);",
				"			#endif",
				"		}",
				"",
				"		/** EditorErrorLog",
				"		*/",
				"		public static void EditorErrorLog(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.editorerrorlogproc(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"	}",
				"}",
				"",
			});

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = Object_Setting.CreateReplaceList();

			//SaveTextWithAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			BlueBack.Code.Convert.Add(t_stringbuilder,t_replace_list,t_template);
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

