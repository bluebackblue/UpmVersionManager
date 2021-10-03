	

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージ更新。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** UpdatePackage
	*/
	public class UpdatePackage
	{
		/** MenuItem_BlueBack_UpmVersionManager_UpdatePackage
		*/
		[UnityEditor.MenuItem("BlueBack/UpmVersionManager/UpdatePackage")]
		public static void MenuItem_BlueBack_UpmVersionManager_UpdatePackage()
		{
			string t_version = GetLastReleaseNameFromGitHub("bluebackblue",Version.packagename);
			if(t_version == null){
				DebugTool.EditorLogError("GetLastReleaseNameFromGitHub : connect error");
			}else if(t_version.Length <= 0){
				UnityEditor.PackageManager.Client.Add("https://github.com/bluebackblue/" + Version.packagename + ".git?path=unity_" + Version.packagename + "/Assets/UPM");
			}else{
				UnityEditor.PackageManager.Client.Add("https://github.com/bluebackblue/" + Version.packagename + ".git?path=unity_" + Version.packagename + "/Assets/UPM#" + t_version);
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
								DebugTool.EditorLogError(a_url + " : " + t_webrequest.error + " : " + t_text);
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
		private static string GetLastReleaseNameFromGitHub(string a_auther,string a_reposname)
		{
			try{
				byte[] t_binary = DownloadBinary("https://api.github.com/repos/" + a_auther + "/" + a_reposname + "/releases/latest");
				if(t_binary != null){
					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,".*(?<name>\\\"name\\\")\\s*\\:\\s*\\\"(?<value>[a-zA-Z0-9_\\.]*)\\\".*");
					t_text = t_match.Groups["value"].Value;
					if(t_text != null){
						return t_text;
					}else{
						DebugTool.EditorLogError(a_auther + " : " + a_reposname + " : text == null");
						return null;
					}
				}else{
					DebugTool.EditorLogError(a_auther + " : " + a_reposname + " : binary == null");
					return null;
				}
			}catch(System.Exception t_exception){
				DebugTool.EditorLogError(a_auther + " : " + a_reposname + " : " + t_exception.Message + "\n" + t_exception.StackTrace);
				return null;
			}
		}
	}
}
#endif

