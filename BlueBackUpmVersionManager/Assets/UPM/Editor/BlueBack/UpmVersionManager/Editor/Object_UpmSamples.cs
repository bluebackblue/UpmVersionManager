

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

			//DeleteDirectoryWithAssetsPath
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete(t_to_path);

			//CreateDirectoryWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(t_from_path);

			//CreateDirectoryWithAssetsPath
			{
				System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.CreateDirectoryNameListWithAssetsPath.CreateAll(t_from_path);
				for(int ii=0;ii<t_path_list.Count;ii++){
					if(t_path_list[ii].StartsWith(t_from_path) == true){
						string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);
						BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(t_path);
					}
				}
			}

			//SaveBinaryWithAssetsPath
			{
				//FileNameList
				System.Collections.Generic.List<string> t_path_list = BlueBack.AssetLib.Editor.CreateFileNameListWithAssetsPath.CreateAll(t_from_path);
				for(int ii=0;ii<t_path_list.Count;ii++){
					string t_path = t_to_path + t_path_list[ii].Substring(t_from_path.Length);

					byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load(t_path_list[ii]);
					BlueBack.AssetLib.Editor.SaveBinaryWithAssetsPath.Save(t_binary,t_path);
				}
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}
		}
	}
}
#endif

