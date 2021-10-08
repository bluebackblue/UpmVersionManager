

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

		/** AddReplaceList
		*/
		public void AddReplaceList(System.Collections.Generic.Dictionary<string,string> a_replace_list)
		{
			//パッケージ名。
			a_replace_list.Add("<<PACKAGENAME>>",this.param.package_name.ToUpper());
			a_replace_list.Add("<<PackageName>>",this.param.package_name);

			//管理者名。
			a_replace_list.Add("<<AUTHORNAME>>",this.param.author_name.ToUpper());
			a_replace_list.Add("<<AuthorName>>",this.param.author_name);
			a_replace_list.Add("<<authorname>>",this.param.author_name.ToLower());

			//ＧＩＴ。
			a_replace_list.Add("<<gitauthor>>",this.param.git_author);
			a_replace_list.Add("<<giturl>>",this.param.git_url);
			a_replace_list.Add("<<gitpath>>",this.param.git_path);
		}

		/** GetSPackageVersion
		*/
		public string GetPackageVersion()
		{
			System.Type t_type = System.Type.GetType(this.param.author_name + "."  + this.param.package_name + ".Version," + this.param.author_name + "."  + this.param.package_name);
			if(t_type != null){
				System.Reflection.MethodInfo t_methodinfo = t_type.GetMethod("GetPackageVersion",System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Public);
				if(t_methodinfo != null){
					System.Object t_object = t_methodinfo.Invoke(null,null);
					if(t_object is string){
						return (string) t_object;
					}
				}
			}

			return "0.0.-1";
		}

		/** 「object_root_readme_md」。依存。
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

