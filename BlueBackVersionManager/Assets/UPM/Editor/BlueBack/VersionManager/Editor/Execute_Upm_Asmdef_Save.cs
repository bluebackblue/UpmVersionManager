

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 実行。「.asemdef」。セーブ。
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
	/** Execute_Upm_Asmdef_Save
	*/
	public sealed class Execute_Upm_Asmdef_Save
	{
		/** Execute
		*/
		public static void Execute()
		{
			#if(ASMDEF_TRUE)

			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			//guid_list
			System.Collections.Generic.Dictionary<string,string> t_guid_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				System.Collections.Generic.List<BlueBack.AssetLib.PathResult<string>> t_list = new System.Collections.Generic.List<AssetLib.PathResult<string>>();
				t_list.AddRange(BlueBack.AssetLib.Editor.CreateGuidListWithAssetsPath.Create(".*","^.*\\.asmdef$"));
				t_list.AddRange(BlueBack.AssetLib.Editor.CreateGuidListWithPackagesPath.Create(".*","^.*\\.asmdef$"));
				foreach(BlueBack.AssetLib.PathResult<string> t_pair in t_list){
					BlueBack.JsonItem.JsonItem t_asmdef_jsonitem = new JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.LoadTextWithFullPath.Load(t_pair.path)));
					string t_asmdef_name = t_asmdef_jsonitem.GetItem("name").GetStringData();
					if(t_guid_list.ContainsKey(t_asmdef_name) == false){
						t_guid_list.Add(t_asmdef_name,t_pair.value);
					}
				}
			}

			//asmdef_runtime
			{
				string t_name = StaticValue.editor_projectparam_json.namespace_author + "." + StaticValue.editor_projectparam_json.namespace_package;
				string t_path = "UPM/Runtime/" + StaticValue.editor_projectparam_json.namespace_author + "/" + StaticValue.editor_projectparam_json.namespace_package + "/" +  t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in StaticValue.editor_projectparam_json.asmdef_runtime,t_path,t_name,false);
			}

			//asmdef_editor
			{
				string t_name = StaticValue.editor_projectparam_json.namespace_author + "." + StaticValue.editor_projectparam_json.namespace_package + ".Editor";
				string t_path = "UPM/Editor/" + StaticValue.editor_projectparam_json.namespace_author + "/" + StaticValue.editor_projectparam_json.namespace_package + "/Editor/" +  t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in StaticValue.editor_projectparam_json.asmdef_editor,t_path,t_name,true);
			}

			//asmdef_sample
			{
				string t_name = StaticValue.editor_projectparam_json.namespace_author + "." + StaticValue.editor_projectparam_json.namespace_package + ".Samples";
				string t_path = "Samples/" + StaticValue.editor_projectparam_json.namespace_author + "." + StaticValue.editor_projectparam_json.namespace_package + "/" + t_name + ".asmdef";
				Inner_CreateAsmdef(t_guid_list,in StaticValue.editor_projectparam_json.asmdef_sample,t_path,t_name,false);
			}

			//Refresh
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#endif
		}

		/** Inner_CreateAsmdef
		*/
		private static void Inner_CreateAsmdef(System.Collections.Generic.Dictionary<string,string> a_guid_list,in File_Editor_ProjectParamJson.Asmdef a_asmdef_item,string a_path,string a_name,bool a_is_editor)
		{
			#if(ASMDEF_TRUE)

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
						ref File_Editor_ProjectParamJson.Asmdef.Reference t_item  = ref a_asmdef_item.reference_list[ii];
						if(t_item.asmdef_version_define == true){
							if(StaticValue.editor_projectparam_json.datalist.TryGetValue(t_item.rootnamespace,out File_Editor_ProjectParamJson.DataItem t_dataitem) == true){
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
				foreach(File_Editor_ProjectParamJson.Asmdef.Reference t_reference in a_asmdef_item.reference_list){
					if(t_reference.asmdef_reference_assembly == true){
						if(StaticValue.editor_projectparam_json.datalist.TryGetValue(t_reference.rootnamespace,out File_Editor_ProjectParamJson.DataItem t_dataitem) == true){
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

			#endif
		}
	}
}
#endif

