

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Editor/<<author_name>>/<<package_name>>/Editor/UpdatePackage.cs」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmUpdatePackage
	*/
	public class Object_UpmUpdatePackage
	{
		/** constructor
		*/
		public Object_UpmUpdatePackage()
		{
		}

		/** Save
		*/
		public static void Save()
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
						" * @brief パッケージ更新。",
						"*/",
						"",
						"",
						"/** <<namespace_comment>>",
						"*/",
						"#if(UNITY_EDITOR)",
						"namespace <<namespace_name>>",
						"{",
						"	/** UpdatePackage",
						"	*/",
						"	#if(!DEF_USER_BLUEBACK_UPMVERSIONMANAGER)",
						"	public class UpdatePackage",
						"	{",
						"		/** MenuItem_BlueBack_<<packagename>>_UpdatePackage",
						"		*/",
						"		[UnityEditor.MenuItem(\"BlueBack/<<packagename>>/UpdatePackage\")]",
						"		public static void MenuItem_BlueBack_<<packagename>>_UpdatePackage()",
						"		{",
						"			string t_version = GetLastReleaseNameFromGitHub(\"bluebackblue\",Version.packagename);",
						"			if(t_version == null){",
						"				DebugTool.EditorLogError(\"GetLastReleaseNameFromGitHub : connect error\");",
						"			}else if(t_version.Length <= 0){",
						"				UnityEditor.PackageManager.Client.Add(\"https://github.com/bluebackblue/<<packagename>>.git?path=unity_<<packagename>>/Assets/UPM\");",
						"			}else{",
						"				UnityEditor.PackageManager.Client.Add(\"https://github.com/bluebackblue/<<packagename>>.git?path=unity_<<packagename>>/Assets/UPM#\" + t_version);",
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
						"								DebugTool.EditorLogError(a_url + \" : \" + t_webrequest.error + \" : \" + t_text);",
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
						"		private static string GetLastReleaseNameFromGitHub(string a_auther,string a_reposname)",
						"		{",
						"			try{",
						"				byte[] t_binary = DownloadBinary(\"https://api.github.com/repos/\" + a_auther + \"/\" + a_reposname + \"/releases/latest\");",
						"				if(t_binary != null){",
						"					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);",
						"					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,\".*(?<name>\\\\\\\"tag_name\\\\\\\")\\\\s*\\\\:\\\\s*\\\\\\\"(?<value>[a-zA-Z0-9_\\\\.]*)\\\\\\\".*\");",
						"					t_text = t_match.Groups[\"value\"].Value;",
						"					if(t_text != null){",
						"						return t_text;",
						"					}else{",
						"						DebugTool.EditorLogError(a_auther + \" : \" + a_reposname + \" : text == null\");",
						"						return null;",
						"					}",
						"				}else{",
						"					DebugTool.EditorLogError(a_auther + \" : \" + a_reposname + \" : binary == null\");",
						"					return null;",
						"				}",
						"			}catch(System.Exception t_exception){",
						"				DebugTool.EditorLogError(a_auther + \" : \" + a_reposname + \" : \" + t_exception.Message + \"\\n\" + t_exception.StackTrace);",
						"				return null;",
						"			}",
						"		}",
						"	}",
						"	#endif",
						"}",
						"#endif",
						"",
					});


					System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
					{
						t_replace_list.Add("<<namespace_name>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor");
						t_replace_list.Add("<<namespace_comment>>",Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor");
						t_replace_list.Add("<<packagename>>",Object_Setting.GetInstance().param.package_name);
					}

					string t_path = "UPM/Editor/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Editor/UpdatePackage.cs";

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

