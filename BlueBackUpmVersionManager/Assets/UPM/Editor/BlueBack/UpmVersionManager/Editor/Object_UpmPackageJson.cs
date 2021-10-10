

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
		/** Package
		*/
		private struct Package
		{
			/** Author
			*/
			public struct Author
			{
				/** 名前。
				*/
				public string name;

				/** ＵＲＬ。
				*/
				public string url;
			}

			/** Samples
			*/
			public struct Samples
			{
				/** 表示名。
				*/
				public string displayName;

				/** パス。
				*/
				public string path;
			}

			/** 名前。
			*/
			public string name;

			/** 表示名。
			*/
			public string displayName;

			/** version
			*/
			public string version;

			/** unity
			*/
			public string unity;

			/** 説明。
			*/
			public string discription;

			/** 作者。
			*/
			public Author author;

			/** キーワード。
			*/
			public string[] keyword;

			/** 依存関係。
			*/
			public System.Collections.Generic.Dictionary<string,string> dependencies;

			/** サンプル。
			*/
			public System.Collections.Generic.List<Samples> samples;
		}

		/** Save
		*/
		public static void Save(string a_version)
		{
			//path
			string t_path = "UPM/package.json";

			//package
			Package t_package;
			{
				//name
				t_package.name = (Object_Setting.s_param.author_name + "." + Object_Setting.s_param.package_name).ToLower();

				//displayName
				t_package.displayName = Object_Setting.s_param.package_name;

				//version
				t_package.version = a_version;

				//unity
				t_package.unity = Object_Setting.s_param.packagejson_unity;

				//discription
				t_package.discription = Object_Setting.s_param.packagejson_discription;

				//author
				t_package.author.name = Object_Setting.s_param.author_name;
				t_package.author.url =  Object_Setting.s_param.git_url +  Object_Setting.s_param.git_author;
				
				//keyword
				t_package.keyword = Object_Setting.s_param.packagejson_keyword;
				
				//dependencies
				t_package.dependencies = Object_Setting.s_param.packagejson_dependencies;

				//samples
				t_package.samples = new System.Collections.Generic.List<Package.Samples>();
				{
					string t_path_sampletop = "Samples/" + Object_Setting.s_param.package_name + "/000";
					System.Collections.Generic.List<string> t_sample_directory_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateOnlyTopDirectoryNameListFromAssetsPath(t_path_sampletop);
					for(int ii=0;ii<t_sample_directory_list.Count;ii++){
						Package.Samples t_sample_item = new Package.Samples();
						{
							t_sample_item.path = "Samples~/" + t_sample_directory_list[ii];
							t_sample_item.displayName = t_sample_directory_list[ii];
						}
						t_package.samples.Add(t_sample_item);
					}
				}
			}

			//SaveUtf8TextToAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(BlueBack.JsonItem.Convert.ObjectToJsonString<Package>(t_package),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
	}
}
#endif

