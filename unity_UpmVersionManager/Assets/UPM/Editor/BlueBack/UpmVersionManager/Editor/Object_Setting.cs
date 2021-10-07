

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 設定。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_Setting
	*/
	public class Object_Setting
	{
		/** s_instance
		*/
		private static Object_Setting s_instance;

		/** GetInstance
		*/
		public static Object_Setting GetInstance()
		{
			return s_instance;
		}

		/** CreateInstance
		*/
		public static void CreateInstance()
		{
			if(s_instance == null){
				s_instance = new Object_Setting();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Creator_Argument
		*/
		public struct Creator_Argument
		{
			/** constructor
			*/
			public Creator_Argument(string a_version,Object_Setting.Param a_param)
			{
				this.version = a_version;
				this.param = a_param;
			}
			
			/** version
			*/
			public string version;

			/** param
			*/
			public Object_Setting.Param param;
		}

		/** Creator_Type
		*/
		public delegate string[] Creator_Type(in Creator_Argument a_argument);

		/** Param
		*/
		public class Param
		{
			/** AsmdefReferenceItem
			*/
			public struct AsmdefReferenceItem
			{
				/** package_name
				*/
				public string package_name;

				/** url
				*/
				public string url;
			}

			/** AsmdefVersionDefineItem
			*/
			public struct AsmdefVersionDefineItem
			{
				/** name
				*/
				public string name;

				/** define
				*/
				public string define;

				/** expression
				*/
				public string expression;
			}

			/** AsmdefItem
			*/
			public struct AsmdefItem
			{
				/** reference_list
				*/
				public AsmdefReferenceItem[] reference_list;

				/** versiondefine_list
				*/
				public AsmdefVersionDefineItem[] versiondefine_list;
			}

			/** author_name
			*/
			public string author_name;

			/** git_url
			*/
			public string git_url;

			/** git_author
			*/
			public string git_author;

			/** git_path
			*/
			public string git_path;

			/** package_name
			*/
			public string package_name;

			/** getpackageversion
			*/
			public System.Func<string> getpackageversion;

			/** packagejson_unity
			*/
			public string packagejson_unity;

			/** packagejson_discription
			*/
			public string packagejson_discription;

			/** packagejson_keyword
			*/
			public string[] packagejson_keyword;

			/** packagejson_dependencies
			*/
			public System.Collections.Generic.Dictionary<string,string> packagejson_dependencies;

			/** root_readmemd_path
			*/
			public string root_readmemd_path;

			/** asmdef_runtime
			*/
			public AsmdefItem asmdef_runtime;
			
			/** asmdef_editor
			*/
			public AsmdefItem asmdef_editor;

			/** asmdef_sample
			*/
			public AsmdefItem asmdef_sample;

			/** changelog
			*/
			public string[] changelog;

			/** object_root_readme_md
			*/
			public Creator_Type[] object_root_readme_md;
		}

		/** param
		*/
		public Param param;

		/** constructor
		*/
		private Object_Setting()
		{
		}

		/** Set
		*/
		public void Set(Param a_param)
		{
			this.param = a_param;

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("Object_Setting.Set");
			#endif
		}

		/** 依存。自動生成。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Asmdef_Dependence(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();

			t_list.Add("### ランタイム");

			//runtine
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<a_argument.param.asmdef_runtime.reference_list.Length;ii++){
					t_url_list.Add("* " + a_argument.param.asmdef_runtime.reference_list[ii].url);
				}
			}

			t_list.Add("### エディター");

			//editor
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<a_argument.param.asmdef_editor.reference_list.Length;ii++){
					t_url_list.Add("* " + a_argument.param.asmdef_editor.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### サンプル");
			
			//sample
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<a_argument.param.asmdef_sample.reference_list.Length;ii++){
					t_url_list.Add("* " + a_argument.param.asmdef_sample.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			return t_list;
		}
	}
}
#endif

