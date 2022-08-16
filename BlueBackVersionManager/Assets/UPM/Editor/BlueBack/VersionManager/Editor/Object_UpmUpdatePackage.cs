

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/Editor/<<NameSpace_Author>>/<<NameSpace_Package>>/Editor/UpdatePackage.cs」。
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
	/** Object_UpmUpdatePackage
	*/
	public static class Object_UpmUpdatePackage
	{
		/** Save
		*/
		public static void Save()
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = Object_Setting.Reprece("UPM/Editor/<<NameSpace_Author>>/<<NameSpace_Package>>/Editor/UpdatePackage.cs");

			//template
			System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();
			BlueBack.Code.Convert.Add(t_template,null,new string[]{
				"",
				"",
				"/**",
				"	Copyright (c) <<namespace_author>>",
				"	Released under the MIT License",
				"	@brief パッケージ更新。自動生成。",
				"*/",
				"",
				"",
				"/** <<NameSpace_Author>>.<<NameSpace_Package>>.Editor",
				"*/",
				"#if(UNITY_EDITOR)",
				"namespace <<NameSpace_Author>>.<<NameSpace_Package>>.Editor",
				"{",
				"	/** UpdatePackage",
				"	*/",
				"	public static class UpdatePackage",
				"	{",
				"		/** packageversion",
				"		*/",
				"		public const string packageversion = Version.packageversion;",
				"",
				"		/** MenuItem_UpdatePackage_Develop",
				"		*/",
				"		#if(!USERDEF_<<NAMESPACE_AUTHOR>>_<<NAMESPACE_PACKAGE>>)",
				"		[UnityEditor.MenuItem(\"<<NameSpace_Author>>/<<NameSpace_Package>>/UpdatePackage/Develop\")]",
				"		#endif",
				"		public static void MenuItem_UpdatePackage_Develop()",
				"		{",
				"			string t_name = \"<<git_url>>.git?path=<<git_path>>\";",
				"			UnityEditor.PackageManager.Requests.AddRequest t_request = UnityEditor.PackageManager.Client.Add(t_name);",
				"			while(t_request.Status == UnityEditor.PackageManager.StatusCode.InProgress){",
				"				if(UnityEditor.EditorUtility.DisplayCancelableProgressBar(t_name,t_name,1.0f) == true){",
				"					break;",
				"				}",
				"				System.Threading.Thread.Sleep(1000);",
				"			}",
				"			UnityEditor.EditorUtility.ClearProgressBar();",
				"		}",
				"",
				"		/** MenuItem_UpdatePackage_Last",
				"		*/",
				"		#if(!USERDEF_<<NAMESPACE_AUTHOR>>_<<NAMESPACE_PACKAGE>>)",
				"		[UnityEditor.MenuItem(\"<<NameSpace_Author>>/<<NameSpace_Package>>/UpdatePackage/Last \" + Version.packageversion)]",
				"		#endif",
				"		public static void MenuItem_UpdatePackage_Last()",
				"		{",
				"			string t_version = Inner_GetLastReleaseNameFromGitHub();",
				"			if(t_version != null){",
				"				string t_name = \"<<git_url>>.git?path=<<git_path>>#\" + t_version;",
				"				UnityEditor.PackageManager.Requests.AddRequest t_request = UnityEditor.PackageManager.Client.Add(t_name);",
				"				while(t_request.Status == UnityEditor.PackageManager.StatusCode.InProgress){",
				"					if(UnityEditor.EditorUtility.DisplayCancelableProgressBar(t_name,t_name,1.0f) == true){",
				"						break;",
				"					}",
				"					System.Threading.Thread.Sleep(1000);",
				"				}",
				"				UnityEditor.EditorUtility.ClearProgressBar();",
				"			}",
				"		}",
				"",
				"		/** Inner_DownloadBinary",
				"		*/",
				"		private static byte[] Inner_DownloadBinary(string a_url)",
				"		{",
				"			try{",
				"				using(UnityEngine.Networking.UnityWebRequest t_webrequest = ((System.Func<UnityEngine.Networking.UnityWebRequest>)(()=>{",
				"					return UnityEngine.Networking.UnityWebRequest.Get(a_url);",
				"				}))()){",
				"					UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_webrequest.SendWebRequest();",
				"					while(true){",
				"						System.Threading.Thread.Sleep(1);",
				"						if(t_async.isDone == true){",
				"							if(t_webrequest.error != null){",
				"								string t_text = \"\";",
				"								if(t_webrequest.downloadHandler.text != null){",
				"									t_text = t_webrequest.downloadHandler.text;",
				"								}",
				"								#if(UNITY_EDITOR)",
				"								DebugTool.EditorErrorLog(a_url + \" : \" + t_webrequest.error + \" : \" + t_text);",
				"								#endif",
				"								return null;",
				"							}else{",
				"								return t_webrequest.downloadHandler.data;",
				"							}",
				"						}",
				"					}",
				"				}",
				"			}catch(System.Exception t_exception){",
				"				DebugTool.EditorErrorLog(a_url + \" : \" + t_exception.Message + \"\\n\" + t_exception.StackTrace);",
				"				return null;",
				"			}",
				"		}",
				"",
				"		/** Inner_GetLastReleaseNameFromGitHub",
				"		*/",
				"		private static string Inner_GetLastReleaseNameFromGitHub()",
				"		{",
				"			string t_url = \"<<git_api>>/releases/latest\";",
				"",
				"			try{",
				"				byte[] t_binary = Inner_DownloadBinary(t_url);",
				"				if(t_binary != null){",
				"					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);",
				"					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,\".*(?<name>\\\\\\\"tag_name\\\\\\\")\\\\s*\\\\:\\\\s*\\\\\\\"(?<value>[a-zA-Z0-9_\\\\.]*)\\\\\\\".*\");",
				"					t_text = t_match.Groups[\"value\"].Value;",
				"					if(t_text != null){",
				"						return t_text;",
				"					}else{",
				"						#if(UNITY_EDITOR)",
				"						DebugTool.EditorErrorLog(t_url + \" : text == null\");",
				"						#endif",
				"						return null;",
				"					}",
				"				}else{",
				"					#if(UNITY_EDITOR)",
				"					DebugTool.EditorErrorLog(t_url + \" : binary == null\");",
				"					#endif",
				"					return null;",
				"				}",
				"			}catch(System.Exception t_exception){",
				"				#if(UNITY_EDITOR)",
				"				DebugTool.EditorErrorLog(t_url + \" : \" + t_exception.Message + \"\\n\" + t_exception.StackTrace);",
				"				#endif",
				"				return null;",
				"			}",
				"		}",
				"	}",
				"}",
				"#endif",
				"",
			});

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = Object_Setting.CreateReplaceList();

			//SaveTextWithAssetsPath
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			BlueBack.Code.Convert.Add(t_stringbuilder,t_replace_list,t_template);
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

