

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/package.json」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmPackageJson
	*/
	public static class Object_UpmPackageJson
	{
		/** Save
		*/
		public static void Save(string a_version)
		{
			//path
			string t_path = "UPM/package.json";

			//package
			PackageJson t_packagejson;
			{
				//name
				t_packagejson.name = Object_Setting.Reprece("<<namespace_author>>.<<namespace_package>>");

				//displayName
				t_packagejson.displayName = Object_Setting.Reprece("<<NameSpace_Author>>.<<NameSpace_Package>>");

				//version
				t_packagejson.version = a_version;

				//unity
				t_packagejson.unity = Object_Setting.s_projectparam.need_unity_version;

				//discription
				t_packagejson.discription = Object_Setting.s_projectparam.discription_simple;

				//author
				t_packagejson.author.name = Object_Setting.s_projectparam.namespace_author;
				t_packagejson.author.url =  Object_Setting.s_projectparam.git_url;
				
				//keyword
				t_packagejson.keyword = Object_Setting.s_projectparam.keyword;
				
				//dependencies
				t_packagejson.dependencies = new System.Collections.Generic.Dictionary<string,string>();
				{
				}

				//samples
				t_packagejson.samples = new System.Collections.Generic.List<PackageJson.Samples>();
				{
					string t_path_sampletop = Object_Setting.Reprece("Samples/<<NameSpace_Package>>/000");
					System.Collections.Generic.List<string> t_sample_directory_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateOnlyTopDirectoryNameListFromAssetsPath(t_path_sampletop);
					for(int ii=0;ii<t_sample_directory_list.Count;ii++){
						PackageJson.Samples t_sample_item = new PackageJson.Samples();
						{
							t_sample_item.path = "Samples~/" + t_sample_directory_list[ii];
							t_sample_item.displayName = t_sample_directory_list[ii];
						}
						t_packagejson.samples.Add(t_sample_item);
					}
				}
			}

			//SaveUtf8TextToAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(BlueBack.JsonItem.Convert.ObjectToJsonString<PackageJson>(t_packagejson),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
	}
}
#endif

