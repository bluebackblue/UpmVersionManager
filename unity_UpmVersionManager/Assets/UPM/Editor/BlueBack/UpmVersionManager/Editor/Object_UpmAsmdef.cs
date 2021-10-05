

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

		/** Asmdef
		*/
		public class Asmdef
		{
			public string name;
			public string rootNamespace;
			public string[] references;
			public string[] includePlatforms;
			public string[] excludePlatforms;
			public bool allowUnsafeCode;
			public bool overrideReferences;
			public string[] precompiledReferences;
			public bool autoReferenced;
			public string[] defineConstraints;
			public string[] versionDefines;
			public bool noEngineReferences;
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
							System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.PackageList.CreatePackageList(false,false);
							foreach(UnityEditor.PackageManager.PackageInfo t_pacakge in t_packagelist){
								t_filename_list.AddRange(BlueBack.AssetLib.Editor.FindFile.FindFileListFromFullPath(t_pacakge.resolvedPath,".*","^.*\\.asmdef$"));
							}
						}

						foreach(string t_filename in t_filename_list){
							BlueBack.JsonItem.JsonItem t_jsonitem = new JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename,System.Text.Encoding.UTF8)));
							
							//asmdef_reference
							foreach(string t_reference_name in Object_Setting.GetInstance().param.asmdef_reference){
								if(t_reference_name ==  t_jsonitem.GetItem("name").GetStringData()){
									if(t_guid_list.ContainsKey(t_reference_name) == false){
										string t_guid = System.Text.RegularExpressions.Regex.Replace(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8),"^(?<before>[\\d\\D\\n]*\nguid\\: )(?<guid>[a-zA-Z0-9]*)(?<after>[\\d\\D\\n]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
											return a_a_match.Groups["guid"].Value;
										},System.Text.RegularExpressions.RegexOptions.Multiline);
										t_guid_list.Add(t_reference_name,t_guid);
									}
								}
							}

							//editorasmdef_reference
							foreach(string t_reference_name in Object_Setting.GetInstance().param.editorasmdef_reference){
								if(t_reference_name ==  t_jsonitem.GetItem("name").GetStringData()){
									if(t_guid_list.ContainsKey(t_reference_name) == false){
										string t_guid = System.Text.RegularExpressions.Regex.Replace(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8),"^(?<before>[\\d\\D\\n]*\nguid\\: )(?<guid>[a-zA-Z0-9]*)(?<after>[\\d\\D\\n]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
											return a_a_match.Groups["guid"].Value;
										},System.Text.RegularExpressions.RegexOptions.Multiline);
										t_guid_list.Add(t_reference_name,t_guid);
									}
								}
							}
						}
					}

					//「xxx.xxx.asmdef」。
					{
						Asmdef t_asmdef = new Asmdef(){
							name = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name,
							rootNamespace = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name,
							references =  new string[Object_Setting.GetInstance().param.asmdef_reference.Length],
							includePlatforms = new string[0],
							excludePlatforms = new string[0],
							allowUnsafeCode = false,
							overrideReferences = false,
							precompiledReferences = new string[0],
							autoReferenced = true,
							defineConstraints = new string[0],
							versionDefines = new string[0],
							noEngineReferences =  false,
						};

						for(int ii=0;ii<t_asmdef.references.Length;ii++){
							if(t_guid_list.TryGetValue(Object_Setting.GetInstance().param.asmdef_reference[ii],out string t_guid) == true){
								t_asmdef.references[ii] = "GUID:" + t_guid;
							}else{
								DebugTool.EditorLogError(Object_Setting.GetInstance().param.asmdef_reference[ii]);
							}
						}

						string t_jsonitem_string = BlueBack.JsonItem.Convert.ObjectToJsonString(t_asmdef);
						string t_path = "UPM/Runtime/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/" +  Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".asmdef";
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonitem_string,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
						#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
						DebugTool.Log("save : " + t_path);
						#endif
					}

					//「xxx.xxx.Editor.asmdef」。
					{
						Asmdef t_asmdef = new Asmdef(){
							name = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor",
							rootNamespace = Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor",
							references =  new string[Object_Setting.GetInstance().param.editorasmdef_reference.Length],
							includePlatforms = new string[]{"Editor"},
							excludePlatforms = new string[0],
							allowUnsafeCode = false,
							overrideReferences = false,
							precompiledReferences = new string[0],
							autoReferenced = true,
							defineConstraints = new string[0],
							versionDefines = new string[0],
							noEngineReferences =  false,
						};

						for(int ii=0;ii<t_asmdef.references.Length;ii++){
							if(t_guid_list.TryGetValue(Object_Setting.GetInstance().param.editorasmdef_reference[ii],out string t_guid) == true){
								t_asmdef.references[ii] = "GUID:" + t_guid;
							}else{
								DebugTool.EditorLogError(Object_Setting.GetInstance().param.editorasmdef_reference[ii]);
							}
						}

						string t_jsonitem_string = BlueBack.JsonItem.Convert.ObjectToJsonString(t_asmdef);
						string t_path = "UPM/Editor/" + Object_Setting.GetInstance().param.author_name + "/" + Object_Setting.GetInstance().param.package_name + "/Editor/" +  Object_Setting.GetInstance().param.author_name + "." + Object_Setting.GetInstance().param.package_name + ".Editor.asmdef";
						BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonitem_string,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
						#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
						DebugTool.Log("save : " + t_path);
						#endif
					}
				}

				//UnityEngine.Object[] t_objlist = BlueBack.AssetLib.Editor.LoadAsset.LoadAllAssetsFromPackagesPath("blueback.assetlib/Runtime/BlueBack/AssetLib/Version.cs");
				//UnityEngine.Object[] t_objlist = BlueBack.AssetLib.Editor.LoadAsset.LoadAllAssetsFromAssetsPath("UPM/README.md");
				//UnityEngine.Debug.Log(t_objlist.Length);
				//UnityEditor.GUID t_guid = UnityEditor.AssetDatabase.GUIDFromAssetPath("Packages/blueback.assetlib/Runtime/BlueBack/BlueBack.AssetLib.asmdef");
				//UnityEngine.Debug.Log(t_guid.ToString());

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

