

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
	public class Object_UpmPackageJson
	{
		/** JsonObject
		*/
		private struct JsonObject
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

		/** HEAD
		*/
		private readonly static string[] HEAD = new string[]{
			"",
			"",
			"/**",
			" * Copyright (c) blueback",
			" * Released under the MIT License",
			" * @brief バージョン。",
			"*/",
			"",
			"",
			"/** <<namespace_comment>>",
			"*/",
			"namespace <<namespace_name>>",
			"{",
			"	/** Version",
			"	*/",
			"	public class Version",
			"	{",
			"		/** version",
			"		*/",
			"		public const string packageversion = \"<<version>>\";",
			"",
			"		/** GetPackageVersion",
			"		*/",
			"		public string GetPackageVersion()",
			"		{",
			"			return packageversion;",
			"		}",
			"	}",
			"}",
			"",
		};

		/** Save
		*/
		public static void Save(string a_version)
		{
			if(Object_Setting.GetInstance() != null){
				//「UPM/package.json」。
				{
					JsonObject t_jsonobject;
					{
						//name
						t_jsonobject.name = (Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name).ToLower();

						//displayName
						t_jsonobject.displayName = Object_Setting.GetInstance().param.package_name;

						//version
						t_jsonobject.version = a_version;

						//unity
						t_jsonobject.unity = Object_Setting.GetInstance().param.packagejson_unity;

						//discription
						t_jsonobject.discription = Object_Setting.GetInstance().param.packagejson_discription;

						//author
						t_jsonobject.author.name = Object_Setting.GetInstance().param.author_name;
						t_jsonobject.author.url = "https://github.com/bluebackblue";
				
						//keyword
						t_jsonobject.keyword = Object_Setting.GetInstance().param.packagejson_keyword;
				
						//dependencies
						t_jsonobject.dependencies = new System.Collections.Generic.Dictionary<string,string>();
						{
						}

						//samples
						t_jsonobject.samples = new System.Collections.Generic.List<JsonObject.Samples>();
						{
							string t_path = "Samples/" + Object_Setting.GetInstance().param.package_name + "/000";
							System.Collections.Generic.List<string> t_sample_directory_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateOnlyTopDirectoryNameListFromAssetsPath(t_path);
							for(int ii=0;ii<t_sample_directory_list.Count;ii++){
								JsonObject.Samples t_sample_item = new JsonObject.Samples();
								{
									t_sample_item.path = "Samples~/" + t_sample_directory_list[ii];
									t_sample_item.displayName = t_sample_directory_list[ii];
								}
								t_jsonobject.samples.Add(t_sample_item);
							}
						}
					}

					{
						string t_path = "UPM/package.json";
						string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString<JsonObject>(t_jsonobject);
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
						UnityEngine.Debug.Log("save : " + t_path);
					}
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}
	}
}
#endif

