

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/Version.cs」。セーブ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_CODE||USERDEF_BLUEBACK_CODE))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Execute_Upm_VersionCs_Save
	*/
	public sealed class Execute_Upm_VersionCs_Save
	{
		/** Execute

			a_packageversion : バージョン。

		*/
		public static void Execute(string a_packageversion)
		{
			#if(ASMDEF_TRUE)

			//path
			Execute_Create_ReplaceList.Execute();
			string t_path = Tool.Reprece("UPM/Runtime/<<NameSpace_Author>>/<<NameSpace_Package>>/Version.cs",StaticValue.replace_list);

			//template
			System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();
			BlueBack.Code.Convert.Add(t_template,null,new string[]{
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

			//SaveTextWithAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();

			Execute_Create_ReplaceList.Execute();
			{
				StaticValue.replace_list.Add("<<packageversion>>",a_packageversion);
			}
			BlueBack.Code.Convert.Add(t_stringbuilder,StaticValue.replace_list,t_template);

			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#endif
		}
	}
}
#endif

