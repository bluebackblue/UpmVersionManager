

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
					});

					System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
					{
						t_replace_list.Add("<<namespace_name>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name);
						t_replace_list.Add("<<namespace_comment>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name);
						t_replace_list.Add("<<version>>",a_version);
					}

					string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Version.cs";

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					BlueBack.Code.Convert.Replace(t_stringbuilder,t_replace_list,t_template);
					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);

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

