

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/Version.cs」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_CODE||USERDEF_BLUEBACK_CODE))
#define ASMDEF_TRUE
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_UpmVersionCs
	*/
	public static class Object_UpmVersionCs
	{
		/** Save
		*/
		public static void Save(string a_packageversion)
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = Object_Setting.Reprece("UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/Version.cs");

			//template
			System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();
			BlueBack.Code.Convert.Add(t_template,new string[]{
				"",
				"",
				"/**",
				"	Copyright (c) <<namespace_author>>",
				"	Released under the MIT License",
				"	@brief バージョン。自動生成。",
				"*/",
				"",
				"",
				"/** <<NameSpace_Author>>.<<NameSpace_Package>>",
				"*/",
				"namespace <<NameSpace_Author>>.<<NameSpace_Package>>",
				"{",
				"	/** Version",
				"	*/",
				"	public static class Version",
				"	{",
				"		/** packagename",
				"		*/",
				"		public const string packagename = \"<<NameSpace_Package>>\";",
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
			System.Collections.Generic.Dictionary<string,string> t_replace_list = Object_Setting.CreateReplaceList();
			{
				t_replace_list.Add("<<packageversion>>",a_packageversion);
			}

			//SaveTextWithAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			BlueBack.Code.Convert.Add(t_stringbuilder,t_replace_list,t_template);
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
		#else
		{
		}
		#endif
	}
}
#endif

