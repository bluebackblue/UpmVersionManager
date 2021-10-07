

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「<<author_name>>.<<package_name>>.asemdef」「<<author_name>>.<<package_name>>.Editor.asemdef」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_UpmAsmdef
	*/
	public class Object_UpmAsmdef
	{
		/** constructor
		*/
		public Object_UpmAsmdef()
		{
		}

		/** Save
		*/
		public static void Save()
		{
			if(Object_Setting.GetInstance() != null){

				//「UPM/Runtime/.../*.asmdef」。
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
							foreach(Object_Setting.Param.AsmdefReferenceItem t_asmdef_reference_item in Object_Setting.GetInstance().param.asmdef_runtime.reference_list){
								if(t_asmdef_reference_item.package_name ==  t_jsonitem.GetItem("name").GetStringData()){
									if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_name) == false){
										string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
										if(t_guid != null){
											t_guid_list.Add(t_asmdef_reference_item.package_name,t_guid);
										}
									}
								}
							}

							//asmdef_editor
							foreach(Object_Setting.Param.AsmdefReferenceItem t_asmdef_reference_item in Object_Setting.GetInstance().param.asmdef_editor.reference_list){
								if(t_asmdef_reference_item.package_name ==  t_jsonitem.GetItem("name").GetStringData()){
									if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_name) == false){
										string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
										if(t_guid != null){
											t_guid_list.Add(t_asmdef_reference_item.package_name,t_guid);
										}
									}
								}
							}

							//asmdef_sample
							foreach(Object_Setting.Param.AsmdefReferenceItem t_asmdef_reference_item in Object_Setting.GetInstance().param.asmdef_sample.reference_list){
								if(t_asmdef_reference_item.package_name ==  t_jsonitem.GetItem("name").GetStringData()){
									if(t_guid_list.ContainsKey(t_asmdef_reference_item.package_name) == false){
										string t_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);
										if(t_guid != null){
											t_guid_list.Add(t_asmdef_reference_item.package_name,t_guid);
										}
									}
								}
							}
						}
					}

					//asmdef_runtime
					{
						string t_name = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name;
						string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/" +  Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".asmdef";
						Inner_CreateAsmdef(t_guid_list,in Object_Setting.GetInstance().param.asmdef_runtime,t_path,t_name);
					}

					//asmdef_editor
					{
						string t_name = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor";
						string t_path = "UPM/Editor/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Editor/" +  Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor.asmdef";
						Inner_CreateAsmdef(t_guid_list,in Object_Setting.GetInstance().param.asmdef_editor,t_path,t_name);
					}

					//asmdef_sample
					{
						string t_name = "Samples." + Object_Setting.GetInstance().param.package_name;
						string t_path = "Samples/" + Object_Setting.GetInstance().param.package_name + "/Samples " + Object_Setting.GetInstance().param.package_name + ".asmdef";
						Inner_CreateAsmdef(t_guid_list,in Object_Setting.GetInstance().param.asmdef_sample,t_path,t_name);
					}
				}

				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Inner_CreateAsmdef
		*/
		private static void Inner_CreateAsmdef(System.Collections.Generic.Dictionary<string,string> a_guid_list,in Object_Setting.Param.AsmdefItem a_asmdef_item,string a_path,string a_name)
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
				t_asmdef.versionDefines =  new AssetLib.Asmdef.VersionDefine[a_asmdef_item.versiondefine_list.Length];
				for(int ii=0;ii<a_asmdef_item.versiondefine_list.Length;ii++){
					t_asmdef.versionDefines[ii].name = a_asmdef_item.versiondefine_list[ii].name;
					t_asmdef.versionDefines[ii].define = a_asmdef_item.versiondefine_list[ii].define;
					t_asmdef.versionDefines[ii].expression = a_asmdef_item.versiondefine_list[ii].expression;
				}
			}

			//references
			{
				t_asmdef.references =  new string[a_asmdef_item.reference_list.Length];
				for(int ii=0;ii<a_asmdef_item.reference_list.Length;ii++){
					if(a_guid_list.TryGetValue(a_asmdef_item.reference_list[ii].package_name,out string t_guid) == true){
						t_asmdef.references[ii] = "GUID:" + t_guid;
					}else{
						DebugTool.EditorLogError(a_asmdef_item.reference_list[ii].package_name);
					}
				}
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

