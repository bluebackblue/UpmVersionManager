

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「.asemdef」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_JSONITEM||USERDEF_BLUEBACK_JSONITEM))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_UpmAsmdef
	*/
	public static class Object_UpmAsmdef
	{
		/** Save
		*/
		public static void Save()
		#if(ASMDEF_TRUE)
		{
			//guid_list
			System.Collections.Generic.Dictionary<string,string> t_guid_list = Inner_CreateGuidList();

			//asmdef_runtime
			{
				string t_name = Object_Setting.projectparam.namespace_author + "." + Object_Setting.projectparam.namespace_package;
				string t_path = "UPM/Runtime/" + Object_Setting.projectparam.namespace_author + "/" + Object_Setting.projectparam.namespace_package + "/" +  t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.projectparam.asmdef_runtime,t_path,t_name,false);
			}

			//asmdef_editor
			{
				string t_name = Object_Setting.projectparam.namespace_author + "." + Object_Setting.projectparam.namespace_package + ".Editor";
				string t_path = "UPM/Editor/" + Object_Setting.projectparam.namespace_author + "/" + Object_Setting.projectparam.namespace_package + "/Editor/" +  t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.projectparam.asmdef_editor,t_path,t_name,true);
			}

			//asmdef_sample
			{
				string t_name = Object_Setting.projectparam.namespace_author + "." + Object_Setting.projectparam.namespace_package + ".Samples";
				string t_path = "Samples/" + Object_Setting.projectparam.namespace_author + "." + Object_Setting.projectparam.namespace_package + "/" + t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in Object_Setting.projectparam.asmdef_sample,t_path,t_name,false);
			}

			//Refresh
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif

		/** Inner_CreateGuidList
		*/
		#if(ASMDEF_TRUE)
		private static System.Collections.Generic.Dictionary<string,string> Inner_CreateGuidList()
		{
			//ＧＵＩＤを列挙。
			System.Collections.Generic.Dictionary<string,string> t_guid_list = new System.Collections.Generic.Dictionary<string,string>();

			//「*.asmdef」を列挙。
			System.Collections.Generic.List<string> t_asmdef_filename_list = new System.Collections.Generic.List<string>();
			{
				t_asmdef_filename_list.AddRange(BlueBack.AssetLib.FindFileWithFullPath.FindAll(UnityEngine.Application.dataPath,".*","^.*\\.asmdef$"));
				System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.CreatePackageList.Create(true,false);
				foreach(UnityEditor.PackageManager.PackageInfo t_pacakge in t_packagelist){
					t_asmdef_filename_list.AddRange(BlueBack.AssetLib.FindFileWithFullPath.FindAll(t_pacakge.resolvedPath,".*","^.*\\.asmdef$"));
				}
			}

			//guid_list
			foreach(string t_asmdef_filename in t_asmdef_filename_list){
				BlueBack.JsonItem.JsonItem t_asmdef_jsonitem = new JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.LoadTextWithFullPath.Load(t_asmdef_filename)));
				string t_asmdef_name = t_asmdef_jsonitem.GetItem("name").GetStringData();
				if(t_guid_list.ContainsKey(t_asmdef_name) == false){
					string t_guid = BlueBack.AssetLib.LoadGuidWithFullPath.Load(t_asmdef_filename + ".meta");
					if(t_guid != null){
						t_guid_list.Add(t_asmdef_name,t_guid);
					}
				}
			}

			return t_guid_list;
		}
		#endif

		/** Inner_CreateAsmdef
		*/
		#if(ASMDEF_TRUE)
		private static void Inner_CreateAsmdef(System.Collections.Generic.Dictionary<string,string> a_guid_list,in ProjectParam.Asmdef a_asmdef_item,string a_path,string a_name,bool a_is_editor)
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

			//includeplatforms
			{
				System.Collections.Generic.List<string> t_includeplatforms_list = new System.Collections.Generic.List<string>();

				if(a_is_editor == true){
					t_includeplatforms_list.Add("Editor");
				}

				t_asmdef.includePlatforms = t_includeplatforms_list.ToArray();
			}

			//version_define_list
			{
				System.Collections.Generic.List<string> t_version_define_list = new System.Collections.Generic.List<string>();

				{
					for(int ii=0;ii<a_asmdef_item.define_constraint_list.Length;ii++){
						t_version_define_list.Add(a_asmdef_item.define_constraint_list[ii]);
					}
				}

				t_asmdef.defineConstraints = t_version_define_list.ToArray();
			}

			//version_define_list
			{
				System.Collections.Generic.List<AssetLib.Asmdef.VersionDefine> t_version_define_list = new System.Collections.Generic.List<AssetLib.Asmdef.VersionDefine>();

				{
					for(int ii=0;ii<a_asmdef_item.reference_list.Length;ii++){
						ref ProjectParam.Asmdef.Reference t_item  = ref a_asmdef_item.reference_list[ii];
						if(t_item.asmdef_version_define == true){
							if(Object_Setting.projectparam.datalist.TryGetValue(t_item.rootnamespace,out ProjectParam.DataItem t_dataitem) == true){
								if(string.IsNullOrEmpty(t_dataitem.domain) == false){
									string t_define = "ASMDEF_" + t_dataitem.domain.Replace('.','_').ToUpper();

									if(t_version_define_list.FindIndex((AssetLib.Asmdef.VersionDefine a_a_item)=>{
										return (t_dataitem.domain == a_a_item.name)||(t_define == a_a_item.define);
									}) < 0){
										t_version_define_list.Add(new AssetLib.Asmdef.VersionDefine(){
											name = t_dataitem.domain,
											define = t_define,
											expression = null,
										});
									}
								}							
							}else{
								#if(UNITY_EDITOR)
								DebugTool.EditorErrorLog(t_item.rootnamespace);
								#endif
							}
						}
					}
				}

				{
					for(int ii=0;ii<a_asmdef_item.version_define_list.Length;ii++){
						t_version_define_list.Add(new AssetLib.Asmdef.VersionDefine(){
							name = a_asmdef_item.version_define_list[ii].domain,
							define = a_asmdef_item.version_define_list[ii].define,
							expression = a_asmdef_item.version_define_list[ii].expression,
						});
					}
				}

				t_asmdef.versionDefines = t_version_define_list.ToArray();
			}

			//reference_list
			{
				System.Collections.Generic.List<string> t_reference_list = new System.Collections.Generic.List<string>();
				foreach(ProjectParam.Asmdef.Reference t_reference in a_asmdef_item.reference_list){
					if(t_reference.asmdef_reference_assembly == true){
						if(Object_Setting.projectparam.datalist.TryGetValue(t_reference.rootnamespace,out ProjectParam.DataItem t_dataitem) == true){
							if(a_guid_list.TryGetValue(t_reference.rootnamespace,out string t_guid) == true){
								t_reference_list.Add("GUID:" + t_guid);
							}else{
								#if(DEF_BLUEBACK_DEBUG_ASSERT)
								DebugTool.EditorErrorLog(t_reference.rootnamespace);
								#endif
							}
						}
					}
				}
				t_asmdef.references = t_reference_list.ToArray();
			}

			string t_jsonitem_string = BlueBack.JsonItem.Convert.ObjectToJsonString(t_asmdef);
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(a_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_jsonitem_string,a_path,BlueBack.AssetLib.LineFeedOption.CRLF);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			if(a_guid_list.ContainsKey(a_name) == false){
				a_guid_list.Add(a_name,BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load(a_path + ".meta"));
			}
		}
		#endif
	}
}
#endif

