

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
	public static class Object_UpmSamples
	{
		/** Copy
		*/
		public static void Copy()
		{
			//path
			string t_from_path = Object_Setting.Reprece("Samples\\<<NameSpace_Package>>\\000");
			string t_to_path = "UPM\\Samples~";

			//DeleteDirectory
			BlueBack.AssetLib.Editor.DeleteDirectory.TryDeleteDirectoryFromAssetsPath(t_to_path);

			//CreateDirectory
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_from_path);

			//構成コピー。
			{
				System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateAllDirectoryNameListFromAssetsPath(t_from_path);
				for(int ii=0;ii<t_path_list.Count;ii++){
					if(t_path_list[ii].StartsWith(t_from_path) == true){
						string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);
						BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(t_path);
					}
				}
			}

			//ファイルコピー。
			{
				//FileNameList
				System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.FileNameList.CreateAllFileNameListFromAssetsPath(t_from_path);
				for(int ii=0;ii<t_path_list.Count;ii++){
					string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);

					byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath(t_path_list[ii]);
					BlueBack.AssetLib.Editor.SaveBinary.SaveBinaryToAssetsPath(t_binary,t_path);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("copy : " + t_path);
					#endif
				}
			}

			//Refresh
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif

