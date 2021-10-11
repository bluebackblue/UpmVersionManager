

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Editor/<<NameSpace_Author>>/<<NameSpace_Package>>/Editor/UpdatePackage.cs」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmUpdatePackage
	*/
	public static class Object_UpmUpdatePackage
	{
		/** Save
		*/
		public static void Save()
		{
			//path
			string t_path = Object_Setting.Reprece("UPM/Editor/<<NameSpace_Author>>/<<NameSpace_Package>>/Editor/UpdatePackage.cs");

			//template
			System.Collections.Generic.List<string> t_template = new System.Collections.Generic.List<string>();
			BlueBack.Code.Convert.Add(t_template,new string[]{
				"",
				"",
				"/**",
				" * Copyright (c) <<namespace_author>>",
				" * Released under the MIT License",
				" * @brief パッケージ更新。自動生成。",
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
				"	#if(!DEF_USER_<<NAMESPACE_AUTHOR>>_<<NAMESPACE_PACKAGE>>)",
				"	public static class UpdatePackage",
				"	{",
				"		/** MenuItem_<<NameSpace_Author>>_<<NameSpace_Package>>_UpdatePackage",
				"		*/",
				"		[UnityEditor.MenuItem(\"<<NameSpace_Author>>/<<NameSpace_Package>>/UpdatePackage \" + Version.packageversion)]",
				"		public static void MenuItem_<<NameSpace_Author>>_<<NameSpace_Package>>_UpdatePackage()",
				"		{",
				"			string t_version = GetLastReleaseNameFromGitHub();",
				"			if(t_version == null){",
				"				#if(UNITY_EDITOR)",
				"				DebugTool.EditorLogError(\"GetLastReleaseNameFromGitHub : connect error\");",
				"				#endif",
				"			}else if(t_version.Length <= 0){",
				"				UnityEditor.PackageManager.Client.Add(Object_Setting.s_projectparam.git_url + \".git?path=\" + Object_Setting.s_projectparam.git_path);",
				"			}else{",
				"				UnityEditor.PackageManager.Client.Add(Object_Setting.s_projectparam.git_url + \".git?path=\" + Object_Setting.s_projectparam.git_path + \"#\" + t_version);",
				"			}",
				"		}",
				"",
				"		/** DownloadBinary",
				"		*/",
				"		private static byte[] DownloadBinary(string a_url)",
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
				"								DebugTool.EditorLogError(a_url + \" : \" + t_webrequest.error + \" : \" + t_text);",
				"								#endif",
				"								return null;",
				"							}else{",
				"								return t_webrequest.downloadHandler.data;",
				"							}",
				"						}",
				"					}",
				"				}",
				"			}catch(System.Exception t_exception){",
				"				DebugTool.EditorLogError(a_url + \" : \" + t_exception.Message + \"\\n\" + t_exception.StackTrace);",
				"				return null;",
				"			}",
				"		}",
				"",
				"		/** GetLastReleaseNameFromGitHub",
				"		*/",
				"		private static string GetLastReleaseNameFromGitHub()",
				"		{",
				"			string t_url = Object_Setting.s_projectparam.git_api + \"/releases/latest\";",
				"",
				"			try{",
				"				byte[] t_binary = DownloadBinary(t_url);",
				"				if(t_binary != null){",
				"					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);",
				"					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,\".*(?<name>\\\\\\\"tag_name\\\\\\\")\\\\s*\\\\:\\\\s*\\\\\\\"(?<value>[a-zA-Z0-9_\\\\.]*)\\\\\\\".*\");",
				"					t_text = t_match.Groups[\"value\"].Value;",
				"					if(t_text != null){",
				"						return t_text;",
				"					}else{",
				"						#if(UNITY_EDITOR)",
				"						DebugTool.EditorLogError(t_url + \" : text == null\");",
				"						#endif",
				"						return null;",
				"					}",
				"				}else{",
				"					#if(UNITY_EDITOR)",
				"					DebugTool.EditorLogError(t_url + \" : binary == null\");",
				"					#endif",
				"					return null;",
				"				}",
				"			}catch(System.Exception t_exception){",
				"				#if(UNITY_EDITOR)",
				"				DebugTool.EditorLogError(t_url + \" : \" + t_exception.Message + \"\\n\" + t_exception.StackTrace);",
				"				#endif",
				"				return null;",
				"			}",
				"		}",
				"	}",
				"	#endif",
				"}",
				"#endif",
				"",
			});

			//replace_list
			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			Object_Setting.AddReplaceList(t_replace_list);

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
