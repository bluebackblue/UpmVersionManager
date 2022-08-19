

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「UPM/package.json」。セーブ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_JSONITEM||USERDEF_BLUEBACK_JSONITEM))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Upm_PackageJson_Save
	*/
	public static class Execute_Upm_PackageJson_Save
	{
		/** Execute
		*/
		public static void Execute(string a_version)
		{
			#if(ASMDEF_TRUE)

			//path
			string t_path = "UPM/package.json";

			//package
			PackageJson t_packagejson;
			{
				//name
				t_packagejson.name = Object_Setting.Reprece("<<namespace_author>>.<<namespace_package>>");

				//version
				t_packagejson.version = a_version;

				//description
				t_packagejson.description = Object_Setting.projectparam.description_simple;

				//displayName
				t_packagejson.displayName = Object_Setting.Reprece("<<NameSpace_Author>>.<<NameSpace_Package>>");

				//unity
				t_packagejson.unity = Object_Setting.projectparam.need_unity_version;

				//author
				t_packagejson.author.name = Object_Setting.projectparam.namespace_author;
				t_packagejson.author.email = null;
				t_packagejson.author.url =  Object_Setting.projectparam.git_url;

				//changelogUrl
				t_packagejson.changelogUrl = Object_Setting.projectparam.changelog_url;

				//dependencies
				t_packagejson.dependencies = new System.Collections.Generic.Dictionary<string,string>();

				//documentationUrl
				t_packagejson.documentationUrl = null;

				//hideInEditor
				t_packagejson.hideInEditor = false;

				//keyword
				t_packagejson.keywords = Object_Setting.projectparam.keyword;

				//license
				t_packagejson.license = Object_Setting.projectparam.license;

				//licensesUrl
				t_packagejson.licensesUrl = null;

				//samples
				t_packagejson.samples = new System.Collections.Generic.List<PackageJson.Samples>();

				//t_packagejson
				t_packagejson.type = null;

				//t_packagejson
				t_packagejson.unityRelease = null;
			}

			//packagejson.dependencies
			{
				Inner_AddToDependenciesList(ref t_packagejson,Object_Setting.projectparam.asmdef_runtime.reference_list);
				Inner_AddToDependenciesList(ref t_packagejson,Object_Setting.projectparam.asmdef_editor.reference_list);
				Inner_AddToDependenciesList(ref t_packagejson,Object_Setting.projectparam.asmdef_sample.reference_list);
			}

			//packagejson.samples
			{
				string t_path_sampletop = Object_Setting.Reprece("Samples/<<NameSpace_Author>>.<<NameSpace_Package>>/000");
				System.Collections.Generic.List<string> t_sample_directory_list = BlueBack.AssetLib.Editor.CreateDirectoryNameListWithAssetsPath.CreateTopOnly(t_path_sampletop);
				for(int ii=0;ii<t_sample_directory_list.Count;ii++){
					PackageJson.Samples t_sample_item = new PackageJson.Samples();
					{
						t_sample_item.path = "Samples~/" + t_sample_directory_list[ii];
						t_sample_item.displayName = t_sample_directory_list[ii];
					}
					t_packagejson.samples.Add(t_sample_item);
				}
			}

			//packagejsonitem
			BlueBack.JsonItem.JsonItem t_packagejsonitem = BlueBack.JsonItem.Convert.ObjectToJsonItem<PackageJson>(t_packagejson);

			//SaveTextWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_packagejsonitem.ConvertToJsonString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("save : " + t_path);
			#endif

			#endif
		}

		/** Inner_AddToDependenciesList
		*/
		private static void Inner_AddToDependenciesList(ref PackageJson a_packagejson,ProjectParam.Asmdef.Reference[] a_reference_list)
		{
			//asmdef_runtime
			for(int ii=0;ii<a_reference_list.Length;ii++){
				ref ProjectParam.Asmdef.Reference t_reference  = ref a_reference_list[ii];
				if(Object_Setting.projectparam.datalist.TryGetValue(t_reference.rootnamespace,out ProjectParam.DataItem t_dataitem) == true){
					if(t_reference.package_dependence == true){
						if(t_dataitem.domain != a_packagejson.name){
							if(a_packagejson.dependencies.ContainsKey(t_dataitem.domain) == false){
								a_packagejson.dependencies.Add(t_dataitem.domain,t_dataitem.dependence);
								#if(DEF_BLUEBACK_DEBUG_LOG)
								DebugTool.Log(string.Format("dependencies : {0} : {1}",t_dataitem.domain,t_dataitem.dependence));
								#endif
							}
						}
					}
				}else{
					#if(UNITY_EDITOR)
					DebugTool.EditorErrorLog(t_reference.rootnamespace);
					#endif
				}
			}
		}
	}
}
#endif

