

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief パッケージ更新。自動生成。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Tool
	*/
	public static class Tool
	{
		/** Reprece
		*/
		public static string Reprece(string a_string,System.Collections.Generic.Dictionary<string,string> a_replace_list)
		{
			string t_string = a_string;

			foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in a_replace_list){
				t_string = t_string.Replace(t_pair.Key,t_pair.Value);
			}

			return t_string;
		}

		/** CreateReplaceList
		*/
		public static System.Collections.Generic.Dictionary<string,string> CreateReplaceList()
		{
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				//パッケージ名。
				t_replace_list.Add("<<NAMESPACE_PACKAGE>>",StaticValue.editor_projectparam_json.namespace_package.ToUpper());
				t_replace_list.Add("<<NameSpace_Package>>",StaticValue.editor_projectparam_json.namespace_package);
				t_replace_list.Add("<<namespace_package>>",StaticValue.editor_projectparam_json.namespace_package.ToLower());

				//管理者名。
				t_replace_list.Add("<<NAMESPACE_AUTHOR>>",StaticValue.editor_projectparam_json.namespace_author.ToUpper());
				t_replace_list.Add("<<NameSpace_Author>>",StaticValue.editor_projectparam_json.namespace_author);
				t_replace_list.Add("<<namespace_author>>",StaticValue.editor_projectparam_json.namespace_author.ToLower());

				//ＧＩＴ。
				t_replace_list.Add("<<git_url>>",StaticValue.editor_projectparam_json.git_url);
				t_replace_list.Add("<<git_api>>",StaticValue.editor_projectparam_json.git_api);
				t_replace_list.Add("<<git_path>>",StaticValue.editor_projectparam_json.git_path);
			}
			return t_replace_list;
		}

		/** GetPackageVersion
		*/
		public static string GetPackageVersion()
		{
			if(StaticValue.editor_projectparam_json != null){
				System.Type t_type = System.Type.GetType(StaticValue.editor_projectparam_json.namespace_author + "."  + StaticValue.editor_projectparam_json.namespace_package + ".Version," + StaticValue.editor_projectparam_json.namespace_author + "."  + StaticValue.editor_projectparam_json.namespace_package);
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
	}
}
#endif

