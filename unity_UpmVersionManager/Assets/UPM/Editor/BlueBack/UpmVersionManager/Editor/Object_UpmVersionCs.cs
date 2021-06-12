

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
			"		public static string GetPackageVersion()",
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
				//「UPM/Runtime/.../Version.cs」。
				{
					System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
					{
						t_replace_list.Add("<<namespace_name>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name);
						t_replace_list.Add("<<namespace_comment>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name);
						t_replace_list.Add("<<version>>",a_version);
					}

					string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Version.cs";
					string t_text = BlueBack.AssetLib.Editor.SaveScript.SaveScriptToAssetsPath(null,t_path,HEAD,null,null,null,t_replace_list,false,BlueBack.AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("save : " + t_path);
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

