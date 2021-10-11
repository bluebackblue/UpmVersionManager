

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージ更新。自動生成。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** UpdatePackage
	*/
	#if(!DEF_USER_BLUEBACK_UPMVERSIONMANAGER)
	public static class UpdatePackage
	{
		/** MenuItem_BlueBack_UpmVersionManager_UpdatePackage
		*/
		[UnityEditor.MenuItem("BlueBack/UpmVersionManager/UpdatePackage " + Version.packageversion)]
		public static void MenuItem_BlueBack_UpmVersionManager_UpdatePackage()
		{
			string t_version = GetLastReleaseNameFromGitHub();
			if(t_version == null){
				#if(UNITY_EDITOR)
				DebugTool.EditorLogError("GetLastReleaseNameFromGitHub : connect error");
				#endif
			}else if(t_version.Length <= 0){
				UnityEditor.PackageManager.Client.Add(Object_Setting.s_projectparam.git_url + ".git?path=" + Object_Setting.s_projectparam.git_path);
			}else{
				UnityEditor.PackageManager.Client.Add(Object_Setting.s_projectparam.git_url + ".git?path=" + Object_Setting.s_projectparam.git_path + "#" + t_version);
			}
		}

		/** DownloadBinary
		*/
		private static byte[] DownloadBinary(string a_url)
		{
			try{
				using(UnityEngine.Networking.UnityWebRequest t_webrequest = ((System.Func<UnityEngine.Networking.UnityWebRequest>)(()=>{
					return UnityEngine.Networking.UnityWebRequest.Get(a_url);
				}))()){
					UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_webrequest.SendWebRequest();
					while(true){
						System.Threading.Thread.Sleep(1);
						if(t_async.isDone == true){
							if(t_webrequest.error != null){
								string t_text = "";
								if(t_webrequest.downloadHandler.text != null){
									t_text = t_webrequest.downloadHandler.text;
								}
								#if(UNITY_EDITOR)
								DebugTool.EditorLogError(a_url + " : " + t_webrequest.error + " : " + t_text);
								#endif
								return null;
							}else{
								return t_webrequest.downloadHandler.data;
							}
						}
					}
				}
			}catch(System.Exception t_exception){
				DebugTool.EditorLogError(a_url + " : " + t_exception.Message + "\n" + t_exception.StackTrace);
				return null;
			}
		}

		/** GetLastReleaseNameFromGitHub
		*/
		private static string GetLastReleaseNameFromGitHub()
		{
			string t_url = Object_Setting.s_projectparam.git_api + "/releases/latest";

			try{
				byte[] t_binary = DownloadBinary(t_url);
				if(t_binary != null){
					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,".*(?<name>\\\"tag_name\\\")\\s*\\:\\s*\\\"(?<value>[a-zA-Z0-9_\\.]*)\\\".*");
					t_text = t_match.Groups["value"].Value;
					if(t_text != null){
						return t_text;
					}else{
						#if(UNITY_EDITOR)
						DebugTool.EditorLogError(t_url + " : text == null");
						#endif
						return null;
					}
				}else{
					#if(UNITY_EDITOR)
					DebugTool.EditorLogError(t_url + " : binary == null");
					#endif
					return null;
				}
			}catch(System.Exception t_exception){
				#if(UNITY_EDITOR)
				DebugTool.EditorLogError(t_url + " : " + t_exception.Message + "\n" + t_exception.StackTrace);
				#endif
				return null;
			}
		}
	}
	#endif
}
#endif

