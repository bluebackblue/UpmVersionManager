

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。変換リスト。作成。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif



/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Create_ReplaceList
	*/
	public sealed class Execute_Create_ReplaceList
	{
		/** Execute
		*/
		public static void Execute()
		{
			StaticValue.replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				//パッケージ名。
				StaticValue.replace_list.Add("<<NAMESPACE_PACKAGE>>",StaticValue.editor_projectparam_json.namespace_package.ToUpper());
				StaticValue.replace_list.Add("<<NameSpace_Package>>",StaticValue.editor_projectparam_json.namespace_package);
				StaticValue.replace_list.Add("<<namespace_package>>",StaticValue.editor_projectparam_json.namespace_package.ToLower());

				//管理者名。
				StaticValue.replace_list.Add("<<NAMESPACE_AUTHOR>>",StaticValue.editor_projectparam_json.namespace_author.ToUpper());
				StaticValue.replace_list.Add("<<NameSpace_Author>>",StaticValue.editor_projectparam_json.namespace_author);
				StaticValue.replace_list.Add("<<namespace_author>>",StaticValue.editor_projectparam_json.namespace_author.ToLower());

				//ＧＩＴ。
				StaticValue.replace_list.Add("<<git_url>>",StaticValue.editor_projectparam_json.git_url);
				StaticValue.replace_list.Add("<<git_api>>",StaticValue.editor_projectparam_json.git_api);
				StaticValue.replace_list.Add("<<git_path>>",StaticValue.editor_projectparam_json.git_path);
			}
		}
	}
}
#endif

