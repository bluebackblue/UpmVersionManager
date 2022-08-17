

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/package.json」。
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
	/** Object_UpmPackageJson
	*/
	public static class Object_UpmPackageJson
	{
		/** Save
		*/
		public static void Save(string a_version)
		#if(ASMDEF_TRUE)
		{
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
				t_packagejson.changelogUrl = null;

				//dependencies
				t_packagejson.dependencies = new System.Collections.Generic.Dictionary<string,string>();
				{
					//asmdef_runtime
					for(int ii=0;ii<Object_Setting.projectparam.asmdef_runtime.reference_list.Length;ii++){
						{
							string t_package_pathname = Object_Setting.projectparam.asmdef_runtime.reference_list[ii].define_package_pathname;
							string t_dependence_value = Object_Setting.projectparam.asmdef_runtime.reference_list[ii].dependence_value;
							if(t_package_pathname != t_packagejson.name){
								if(t_packagejson.dependencies.ContainsKey(t_package_pathname) == false){
									t_packagejson.dependencies.Add(t_package_pathname,t_dependence_value);
								}
							}
						}
					}
					//asmdef_editor
					for(int ii=0;ii<Object_Setting.projectparam.asmdef_editor.reference_list.Length;ii++){
						{
							string t_package_pathname = Object_Setting.projectparam.asmdef_editor.reference_list[ii].define_package_pathname;
							string t_dependence_value = Object_Setting.projectparam.asmdef_editor.reference_list[ii].dependence_value;
							if(t_package_pathname != t_packagejson.name){
								if(t_packagejson.dependencies.ContainsKey(t_package_pathname) == false){
									t_packagejson.dependencies.Add(t_package_pathname,t_dependence_value);
								}
							}
						}
					}
					//asmdef_sample
					for(int ii=0;ii<Object_Setting.projectparam.asmdef_sample.reference_list.Length;ii++){
						{
							string t_package_pathname = Object_Setting.projectparam.asmdef_sample.reference_list[ii].define_package_pathname;
							string t_dependence_value = Object_Setting.projectparam.asmdef_sample.reference_list[ii].dependence_value;
							if(t_package_pathname != t_packagejson.name){
								if(t_packagejson.dependencies.ContainsKey(t_package_pathname) == false){
									t_packagejson.dependencies.Add(t_package_pathname,t_dependence_value);
								}
							}
						}
					}
				}

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

				//t_packagejson
				t_packagejson.type = null;

				//t_packagejson
				t_packagejson.unityRelease = null;
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
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

