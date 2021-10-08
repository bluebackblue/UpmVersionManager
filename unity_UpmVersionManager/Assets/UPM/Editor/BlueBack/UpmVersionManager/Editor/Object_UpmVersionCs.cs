

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
	public static class Object_UpmVersionCs
	{
		/** Save
		*/
		public static void Save(string a_packageversion)
		{
			//path
			string t_path = "UPM/Runtime/" + Object_Setting.s_param.author_name + "/" + Object_Setting.s_param.package_name + "/Version.cs";

			//template
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
				"	public static class Version",
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

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			Object_Setting.AddReplaceList(t_replace_list);
			{
				t_replace_list.Add("<<packageversion>>",a_packageversion);
			}

			//SaveUtf8TextToAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			BlueBack.Code.Convert.Replace(t_stringbuilder,t_replace_list,t_template);
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + t_path);
			#endif
		}
	}
}
#endif

