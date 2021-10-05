

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/Samples~」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmSamples
	*/
	public class Object_UpmSamples
	{
		/** Copy
		*/
		public static void Copy()
		{
			if(Object_Setting.GetInstance() != null){
				string t_from_path = "Samples\\" + Object_Setting.GetInstance().param.package_name + "\\000";
				string t_to_path = "UPM\\Samples~";

				//DeleteDirectory
				BlueBack.AssetLib.Editor.DeleteDirectory.TryDeleteDirectoryFromAssetsPath(t_to_path);

				{
					//DirectoryNameList
					System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateAllDirectoryNameListFromAssetsPath(t_from_path);
					for(int ii=0;ii<t_path_list.Count;ii++){
						if(t_path_list[ii].StartsWith(t_from_path) == true){
							//CreateDirectory
							string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);
							BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
						}
					}
				}

				{
					//FileNameList
					System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.FileNameList.CreateAllFileNameListFromAssetsPath(t_from_path);
					for(int ii=0;ii<t_path_list.Count;ii++){
						//LoadBinary
						byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath(t_path_list[ii]);

						//SaveBinary
						string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);
						BlueBack.AssetLib.Editor.SaveBinary.SaveBinaryToAssetsPath(t_binary,t_path);
						#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
						DebugTool.Log("copy : " + t_path);
						#endif
					}
				}
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}
	}
}
#endif

