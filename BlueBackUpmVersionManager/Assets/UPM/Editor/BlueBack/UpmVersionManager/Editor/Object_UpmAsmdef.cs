

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「.asemdef」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmAsmdef
	*/
	public static class Object_UpmAsmdef
	{
		/** Save
		*/
		public static void Save()
		{
			//guid_list
			System.Collections.Generic.Dictionary<string,string> t_guid_list = Inner_CreateGuidList();

			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("namespace_author = " + Object_Setting.s_projectparam.namespace_author);
			#endif

			//asmdef_runtime
			{
				string t_name = Object_Setting.s_projectparam.namespace_author + "." + Object_Setting.s_projectparam.namespace_package;
				string t_path = "UPM/Runtime/" + Object_Setting.s_projectparam.namespace_author + "/" + Object_Setting.s_projectparam.namespace_package + "/" +  Object_Setting.s_projectparam.namespace_author + "." + Object_Setting.s_projectparam.namespace_package + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.s_projectparam.asmdef_runtime,t_path,t_name);
			}

			//asmdef_editor
			{
				string t_name = Object_Setting.s_projectparam.namespace_author + "." + Object_Setting.s_projectparam.namespace_package + ".Editor";
				string t_path = "UPM/Editor/" + Object_Setting.s_projectparam.namespace_author + "/" + Object_Setting.s_projectparam.namespace_package + "/Editor/" +  Object_Setting.s_projectparam.namespace_author + "." + Object_Setting.s_projectparam.namespace_package + ".Editor.asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.s_projectparam.asmdef_editor,t_path,t_name);
			}

			//asmdef_sample
			{
				string t_name = "Samples." + Object_Setting.s_projectparam.namespace_package;
				string t_path = "Samples/" + Object_Setting.s_projectparam.namespace_package + "/Samples." + Object_Setting.s_projectparam.namespace_package + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.s_projectparam.asmdef_sample,t_path,t_name);
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** Inner_CreateGuidList
		*/
		private static System.Collections.Generic.Dictionary<string,string> Inner_CreateGuidList()
		{
			//ＧＵＩＤを列挙。
			System.Collections.Generic.Dictionary<string,string> t_guid_list = new System.Collections.Generic.Dictionary<string,string>();

			{
				//「*.asmdef」を列挙。
				System.Collections.Generic.List<string> t_filename_list = new System.Collections.Generic.List<string>();
				{
					t_filename_list.AddRange(BlueBack.AssetLib.Editor.FindFile.FindFileListFromFullPath(UnityEngine.Application.dataPath,".*","^.*\\.asmdef$"));
					System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.PackageList.CreatePackageList(true,false);
					foreach(UnityEditor.PackageManager.PackageInfo t_pacakge in t_packagelist){
						t_filename_list.AddRange(BlueBack.AssetLib.Editor.FindFile.FindFileListFromFullPath(t_pacakge.resolvedPath,".*","^.*\\.asmdef$"));
					}
				}

				foreach(string t_filename in t_filename_list){
					BlueBack.JsonItem.JsonItem t_jsonitem = new JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename,System.Text.Encoding.UTF8)));
							
					//asmdef_runtime
					foreach(ProjectParam.Asmdef.Reference t_asmdef_reference_item in Object_Setting.s_projectparam.asmdef_runtime.reference_list){
						if(t_asmdef_reference_item.use != null){
							if(t_asmdef_reference_item.package_fullname ==  t_jsonitem.GetItem("name").GetStringData()){
								if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_fullname) == false){
									string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
									if(t_guid != null){
										t_guid_list.Add(t_asmdef_reference_item.package_fullname,t_guid);
									}
								}
							}
						}
					}

					//asmdef_editor
					foreach(ProjectParam.Asmdef.Reference t_asmdef_reference_item in Object_Setting.s_projectparam.asmdef_editor.reference_list){
						if(t_asmdef_reference_item.use != null){
							if(t_asmdef_reference_item.package_fullname ==  t_jsonitem.GetItem("name").GetStringData()){
								if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_fullname) == false){
									string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
									if(t_guid != null){
										t_guid_list.Add(t_asmdef_reference_item.package_fullname,t_guid);
									}
								}
							}
						}
					}

					//asmdef_sample
					foreach(ProjectParam.Asmdef.Reference t_asmdef_reference_item in Object_Setting.s_projectparam.asmdef_sample.reference_list){
						if(t_asmdef_reference_item.use != null){
							if(t_asmdef_reference_item.package_fullname ==  t_jsonitem.GetItem("name").GetStringData()){
								if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_fullname) == false){
									string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
									if(t_guid != null){
										t_guid_list.Add(t_asmdef_reference_item.package_fullname,t_guid);
									}
								}
							}
						}
					}
				}
			}

			return t_guid_list;
		}

		/** Inner_CreateAsmdef
		*/
		private static void Inner_CreateAsmdef(System.Collections.Generic.Dictionary<string,string> a_guid_list,in ProjectParam.Asmdef a_asmdef_item,string a_path,string a_name)
		{
			AssetLib.Asmdef t_asmdef = new AssetLib.Asmdef(){
				name = a_name,
				rootNamespace = a_name,
				references =  null,
				includePlatforms = new string[0],
				excludePlatforms = new string[0],
				allowUnsafeCode = false,
				overrideReferences = false,
				precompiledReferences = new string[0],
				autoReferenced = true,
				defineConstraints = new string[0],
				versionDefines = null,
				noEngineReferences =  false,
			};

			//versionDefines
			{
				System.Collections.Generic.List<AssetLib.Asmdef.VersionDefine> t_define_list = new System.Collections.Generic.List<AssetLib.Asmdef.VersionDefine>();
				for(int ii=0;ii<a_asmdef_item.define_list.Length;ii++){
					if(a_asmdef_item.define_list[ii].use != null){
						t_define_list.Add(new AssetLib.Asmdef.VersionDefine(){
							name = a_asmdef_item.define_list[ii].package_pathname,
							define = a_asmdef_item.define_list[ii].define,
							expression = a_asmdef_item.define_list[ii].expression,
						});
					}
				}
				t_asmdef.versionDefines = t_define_list.ToArray();
			}

			//references
			{
				System.Collections.Generic.List<string> t_reference_list = new System.Collections.Generic.List<string>();
				for(int ii=0;ii<a_asmdef_item.reference_list.Length;ii++){
					if(a_asmdef_item.reference_list[ii].use != null){
						if(a_guid_list.TryGetValue(a_asmdef_item.reference_list[ii].package_fullname,out string t_guid) == true){
							t_reference_list.Add("GUID:" + t_guid);
						}else{
							#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
							DebugTool.EditorLogError(a_asmdef_item.reference_list[ii].package_fullname);
							#endif
						}
					}
				}
				t_asmdef.references = t_reference_list.ToArray();
			}

			string t_jsonitem_string = BlueBack.JsonItem.Convert.ObjectToJsonString(t_asmdef);
			BlueBack.AssetLib.Editor.CreateDirectory.CreateDirectoryToAssetsPath(System.IO.Path.GetDirectoryName(a_path));
			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonitem_string,a_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("save : " + a_path);
			#endif

			if(a_guid_list.ContainsKey(a_name) == false){
				string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromAssetsPath(a_path + ".meta",System.Text.Encoding.UTF8);
				a_guid_list.Add(a_name,t_guid);
			}
		}
	}
}
#endif

