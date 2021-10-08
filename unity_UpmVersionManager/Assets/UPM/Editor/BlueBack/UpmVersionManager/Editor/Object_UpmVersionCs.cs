

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Runtime/<<author_name>>/<<package_name>>/Version.cs」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmVersionCs
	*/
	public class Object_UpmVersionCs
	{
		/** constructor
		*/
		public Object_UpmVersionCs()
		{
		}

		/** Save
		*/
		public static void Save(string a_version)
		{
			if(Object_Setting.GetInstance() != null){
				//「UPM/Runtime/.../Version.cs」。
				{
					System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();

					BlueBack.Code.Convert.Add(t_template,new string[]{
						"",
						"",
						"/**",
						" * Copyright (c) <<authorname>>",
						" * Released under the MIT License",
						" * @brief バージョン。自動生成。",
						"*/",
						"",
						"",
						"/** <<AuthorName>>.<<PackageName>>",
						"*/",
						"namespace <<AuthorName>>.<<PackageName>>",
						"{",
						"	/** Version",
						"	*/",
						"	public class Version",
						"	{",
						"		/** packagename",
						"		*/",
						"		public const string packagename = \"<<PackageName>>\";",
						"",
						"		/** packageversion",
						"		*/",
						"		public const string packageversion = \"<<packageversion>>\";",
						"",
						"		/** GetPackageVersion",
						"		*/",
						"		public static string GetPackageVersion()",
						"		{",
						"			return packageversion;",
						"		}",
						"	}",
						"}",
						"",
					});

					System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
					Object_Setting.GetInstance().AddReplaceList(t_replace_list);
					{
						t_replace_list.Add("<<packageversion>>",a_version);
					}

					string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Version.cs";

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					BlueBack.Code.Convert.Replace(t_stringbuilder,t_replace_list,t_template);
					BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_path);
					#endif
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

