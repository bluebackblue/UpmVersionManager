

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
	public static class Object_Setting
	{
		/** Creator_Argument
		*/
		public struct Creator_Argument
		{
			/** constructor
			*/
			public Creator_Argument(string a_version)
			{
				this.version = a_version;
			}
			
			/** version
			*/
			public string version;
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

			/** git_repos
			*/
			public string git_repos;

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
		public static Param s_param = null;

		/** AddReplaceList
		*/
		public static void AddReplaceList(System.Collections.Generic.Dictionary<string,string> a_replace_list)
		{
			//パッケージ名。
			a_replace_list.Add("<<PACKAGENAME>>",s_param.package_name.ToUpper());
			a_replace_list.Add("<<PackageName>>",s_param.package_name);

			//管理者名。
			a_replace_list.Add("<<AUTHORNAME>>",s_param.author_name.ToUpper());
			a_replace_list.Add("<<AuthorName>>",s_param.author_name);
			a_replace_list.Add("<<authorname>>",s_param.author_name.ToLower());

			//ＧＩＴ。
			a_replace_list.Add("<<gitauthor>>",s_param.git_author);
			a_replace_list.Add("<<giturl>>",s_param.git_url);
			a_replace_list.Add("<<gitpath>>",s_param.git_path);
			a_replace_list.Add("<<gitrepos>>",s_param.git_repos);
		}

		/** GetSPackageVersion
		*/
		public static string GetPackageVersion()
		{
			System.Type t_type = System.Type.GetType(s_param.author_name + "."  + s_param.package_name + ".Version," + s_param.author_name + "."  + s_param.package_name);
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
				for(int ii=0;ii<s_param.asmdef_runtime.reference_list.Length;ii++){
					t_url_list.Add("* " + s_param.asmdef_runtime.reference_list[ii].url);
				}
			}

			t_list.Add("### エディター");

			//editor
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_param.asmdef_editor.reference_list.Length;ii++){
					t_url_list.Add("* " + s_param.asmdef_editor.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### サンプル");
			
			//sample
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_param.asmdef_sample.reference_list.Length;ii++){
					t_url_list.Add("* " + s_param.asmdef_sample.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			return t_list;
		}
	}
}
#endif

