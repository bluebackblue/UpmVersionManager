

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
				"#if(ASMDEF_BLUEBACK_DEBUG)",
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
				"		/** assert",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Assert.CallBackType assert = BlueBack.Debug.Assert.Execute;",
				"		#endif",
				"",
				"		/** Assert",
				"		*/",
				"		public static void Assert(bool a_flag,System.Exception a_exception = null)",
				"		{",
				"			if(a_flag != true){",
				"				#if(ASMDEF_TRUE)",
				"				DebugTool.assert(null,a_exception);",
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
				"				DebugTool.assert(a_message,null);",
				"				#endif",
				"			}",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(DEF_BLUEBACK_DEBUG_LOG)",
				"",
				"		/** log",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Log.CallBackType log = BlueBack.Debug.Log.Execute;",
				"		#endif",
				"",
				"		/** Log",
				"		*/",
				"		public static void Log(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.log(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(DEF_BLUEBACK_DEBUG_DETAIL)",
				"",
				"		/** detail",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.Detail.CallBackType detail = BlueBack.Debug.Detail.Execute;",
				"		#endif",
				"",
				"		/** Detail",
				"		*/",
				"		public static void Detail(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.detail(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"",
				"		#if(UNITY_EDITOR)",
				"",
				"		/** editorlog",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.EditorLog.CallBackType editorlog = BlueBack.Debug.EditorLog.Execute;",
				"		#endif",
				"",
				"		/** editorerrorlog",
				"		*/",
				"		#if(ASMDEF_TRUE)",
				"		public static BlueBack.Debug.EditorErrorLog.CallBackType editorerrorlog = BlueBack.Debug.EditorErrorLog.Execute;",
				"		#endif",
				"",
				"		/** EditorLog",
				"		*/",
				"		public static void EditorLog(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.editorlog(a_message);",
				"			#endif",
				"		}",
				"",
				"		/** EditorErrorLog",
				"		*/",
				"		public static void EditorErrorLog(string a_message)",
				"		{",
				"			#if(ASMDEF_TRUE)",
				"			DebugTool.editorerrorlog(a_message);",
				"			#endif",
				"		}",
				"",
				"		#endif",
				"	}",
				"}",
				"",
			});


			if(Object_Setting.projectparam.debugtool_generate == true){
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
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

