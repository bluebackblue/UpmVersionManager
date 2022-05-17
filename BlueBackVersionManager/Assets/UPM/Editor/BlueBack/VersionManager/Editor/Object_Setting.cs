

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 設定。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
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

		/** CreateReplaceList
		*/
		public static System.Collections.Generic.Dictionary<string,string> CreateReplaceList()
		{
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				//パッケージ名。
				t_replace_list.Add("<<NAMESPACE_PACKAGE>>",s_projectparam.namespace_package.ToUpper());
				t_replace_list.Add("<<NameSpace_Package>>",s_projectparam.namespace_package);
				t_replace_list.Add("<<namespace_package>>",s_projectparam.namespace_package.ToLower());

				//管理者名。
				t_replace_list.Add("<<NAMESPACE_AUTHOR>>",s_projectparam.namespace_author.ToUpper());
				t_replace_list.Add("<<NameSpace_Author>>",s_projectparam.namespace_author);
				t_replace_list.Add("<<namespace_author>>",s_projectparam.namespace_author.ToLower());

				//ＧＩＴ。
				t_replace_list.Add("<<git_url>>",s_projectparam.git_url);
				t_replace_list.Add("<<git_api>>",s_projectparam.git_api);
				t_replace_list.Add("<<git_path>>",s_projectparam.git_path);
			}
			return t_replace_list;
		}

		/** 置き換え。
		*/
		public static string Reprece(string a_string)
		{
			string t_string = a_string;
			System.Collections.Generic.Dictionary<string,string> t_replace_list = CreateReplaceList();
			foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in t_replace_list){
				t_string = t_string.Replace(t_pair.Key,t_pair.Value);
			}
			return t_string;
		}

		/** GetPackageVersion
		*/
		public static string GetPackageVersion()
		{
			if((s_projectparam.namespace_author != null)&&(s_projectparam.namespace_package != null)){
				System.Type t_type = System.Type.GetType(s_projectparam.namespace_author + "."  + s_projectparam.namespace_package + ".Version," + s_projectparam.namespace_author + "."  + s_projectparam.namespace_package);
				if(t_type != null){
					System.Reflection.MethodInfo t_methodinfo = t_type.GetMethod("GetPackageVersion",System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Public);
					if(t_methodinfo != null){
						System.Object t_object = t_methodinfo.Invoke(null,null);
						if(t_object is string){
							return (string)t_object;
						}
					}
				}
			}
			return "0.0.-1";
		}

		/** 「object_root_readme_md」。概要。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Overview(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				for(int ii=0;ii<s_projectparam.discription_detal.Length;ii++){
					t_list.Add(s_projectparam.discription_detal[ii]);
				}
			}
			return t_list;
		}

		/** 「object_root_readme_md」。依存。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Asmdef_Dependence(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();

			t_list.Add("### ランタイム");

			//runtine
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_projectparam.asmdef_runtime.reference_list.Length;ii++){
					switch(s_projectparam.asmdef_runtime.reference_list[ii].mode){
					case "package":
					case "url":
						{
							t_url_list.Add("* " + s_projectparam.asmdef_runtime.reference_list[ii].url);
						}break;
					}
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### エディター");

			//editor
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_projectparam.asmdef_editor.reference_list.Length;ii++){
					switch(s_projectparam.asmdef_editor.reference_list[ii].mode){
					case "package":
					case "url":
						{
							t_url_list.Add("* " + s_projectparam.asmdef_editor.reference_list[ii].url);
						}break;
					}
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### サンプル");
			
			//sample
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<s_projectparam.asmdef_sample.reference_list.Length;ii++){
					switch(s_projectparam.asmdef_sample.reference_list[ii].mode){
					case "package":
					case "url":
						{
							t_url_list.Add("* " + s_projectparam.asmdef_sample.reference_list[ii].url);
						}break;
					}
				}
				t_list.AddRange(t_url_list);
			}

			return t_list;
		}

		/** 「object_root_readme_md」。例。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Exsample(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument)
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = "Editor/Exsample.cs";

			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex("^(?<nest>\\t*)\\/\\/(?<command>\\<\\<[a-zA-Z0-9_\\.]*\\>\\>)(?<argument>.*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
			bool t_blocknow = false;
			int t_nest = 0;

			//LoadTextWithAssetsPath
			BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
			if(t_result.result == true){
				string[] t_line_list = t_result.value.Replace("\r","").Split('\n');
				for(int ii=0;ii<t_line_list.Length;ii++){
					System.Text.RegularExpressions.Match t_match = t_regex.Match(t_line_list[ii]);
					if(t_match.Success == true){

						#pragma warning disable 0162
						switch(t_match.Groups["command"].Value){
						case "<<COMMENT>>":
							{
								t_list.Add(t_match.Groups["argument"].Value);
								continue;
							}break;
						case "<<CS_BLOCK_START>>":
							{
								t_list.Add("```cs");
								t_blocknow = true;
								t_nest = t_match.Groups["nest"].Value.Length;
								continue;
							}break;
						case "<<CS_BLOCK_END>>":
							{
								t_list.Add("```");
								t_blocknow = false;
								continue;
							}break;
						case "<<BLOCK_START>>":
							{
								t_list.Add("```");
								t_blocknow = true;
								t_nest = t_match.Groups["nest"].Value.Length;
								continue;
							}break;
						case "<<BLOCK_END>>":
							{
								t_list.Add("```");
								t_blocknow = false;
								continue;
							}break;
						}
						#pragma warning restore
					}

					if(t_blocknow == true){
						if(t_line_list[ii].Length >= t_nest){
							string t_line = t_line_list[ii].Substring(t_nest);
							t_list.Add(t_line);
						}
					}
				}
			}

			return t_list;
		}
		#else
		{
			#warning "ASMDEF_TRUE"
			return null;
		}
		#endif
	}
}
#endif

