

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

		/** s_projectparam
		*/
		public static ProjectParam s_projectparam;

		/** s_object_root_readme_md
		*/
		public static Creator_Type[] s_object_root_readme_md;

		/** AddReplaceList
		*/
		public static void AddReplaceList(System.Collections.Generic.Dictionary<string,string> a_replace_list)
		{
			//パッケージ名。
			a_replace_list.Add("<<NAMESPACE_PACKAGE>>",s_projectparam.namespace_package.ToUpper());
			a_replace_list.Add("<<NameSpace_Package>>",s_projectparam.namespace_package);

			//管理者名。
			a_replace_list.Add("<<NAMESPACE_AUTHOR>>",s_projectparam.namespace_author.ToUpper());
			a_replace_list.Add("<<NameSpace_Author>>",s_projectparam.namespace_author);
			a_replace_list.Add("<<namespace_author>>",s_projectparam.namespace_author.ToLower());

			//ＧＩＴ。
			a_replace_list.Add("<<giturl>>",s_projectparam.git_url);
			a_replace_list.Add("<<gitapi>>",s_projectparam.git_api);
			a_replace_list.Add("<<gitpath>>",s_projectparam.git_path);
		}

		/** 置き換え。
		*/
		public static string Reprece(string a_string)
		{
			string t_string = a_string;
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			AddReplaceList(t_replace_list);
			foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
				t_string = t_string.Replace(t_pair.Key,t_pair.Value);
			}

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log(t_string);
			#endif

			return t_string;
		}

		/** GetSPackageVersion
		*/
		public static string GetPackageVersion()
		{
			System.Type t_type = System.Type.GetType(s_projectparam.namespace_author + "."  + s_projectparam.namespace_package + ".Version," + s_projectparam.namespace_author + "."  + s_projectparam.namespace_package);
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

		/** 「object_root_readme_md」。概要。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Overview(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				for(int ii=0;ii<s_projectparam.discription_detal.Length;ii++){
					t_list.Add("* " + s_projectparam.discription_detal[ii]);
				}
			}
			return t_list;
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
				for(int ii=0;ii<s_projectparam.asmdef_runtime.reference_list.Length;ii++){
					t_url_list.Add("* " + s_projectparam.asmdef_runtime.reference_list[ii].url);
				}
			}

			t_list.Add("### エディター");

			//editor
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_projectparam.asmdef_editor.reference_list.Length;ii++){
					t_url_list.Add("* " + s_projectparam.asmdef_editor.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### サンプル");
			
			//sample
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_projectparam.asmdef_sample.reference_list.Length;ii++){
					t_url_list.Add("* " + s_projectparam.asmdef_sample.reference_list[ii].url);
				}
				t_list.AddRange(t_url_list);
			}

			return t_list;
		}
	}
}
#endif

