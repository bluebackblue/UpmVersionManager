

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Creator_Argument
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** ReadmeMdCreator
	*/
	public static class ReadmeMdCreator
	{
		/** Argument
		*/
		public struct Argument
		{
			/** constructor
			*/
			public Argument(string a_version)
			{
				this.version = a_version;
			}

			/** version
			*/
			public string version;
		}

		/** CallBackType
		*/
		public delegate string[] CallBackType(in ReadmeMdCreator.Argument a_argument);

		/** 「object_root_readme_md」。概要。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Overview(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				for(int ii=0;ii<StaticValue.editor_projectparam_json.description_detal.Length;ii++){
					t_list.Add(StaticValue.editor_projectparam_json.description_detal[ii]);
				}
			}
			return t_list;
		}

		/** 「object_root_readme_md」。依存。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Asmdef_Dependence(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();

			t_list.Add("### ランタイム");

			//asmdef_runtime
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<StaticValue.editor_projectparam_json.asmdef_runtime.reference_list.Length;ii++){
					ref File_Editor_ProjectParamJson.Asmdef.Reference t_reference = ref StaticValue.editor_projectparam_json.asmdef_runtime.reference_list[ii];
					if(t_reference.readmemd_dependence_url == true){
						if(StaticValue.editor_projectparam_json.datalist.TryGetValue(t_reference.rootnamespace,out File_Editor_ProjectParamJson.DataItem t_dataitem) == true){
							t_url_list.Add("* " + t_dataitem.url);
						}else{
							#if(UNITY_EDITOR)
							DebugTool.EditorErrorLog(t_reference.rootnamespace);
							#endif
						}
					}
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### エディター");

			//asmdef_editor
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<StaticValue.editor_projectparam_json.asmdef_editor.reference_list.Length;ii++){
					ref File_Editor_ProjectParamJson.Asmdef.Reference t_reference = ref StaticValue.editor_projectparam_json.asmdef_editor.reference_list[ii];
					if(t_reference.readmemd_dependence_url == true){
						if(StaticValue.editor_projectparam_json.datalist.TryGetValue(t_reference.rootnamespace,out File_Editor_ProjectParamJson.DataItem t_dataitem) == true){
							t_url_list.Add("* " + t_dataitem.url);
						}else{
							#if(UNITY_EDITOR)
							DebugTool.EditorErrorLog(t_reference.rootnamespace);
							#endif
						}
					}
				}
				t_list.AddRange(t_url_list);
			}

			t_list.Add("### サンプル");

			//asmdef_sample
			{
				System.Collections.Generic.HashSet<string> t_url_list = new System.Collections.Generic.HashSet<string>();
				for(int ii=0;ii<StaticValue.editor_projectparam_json.asmdef_sample.reference_list.Length;ii++){
					ref File_Editor_ProjectParamJson.Asmdef.Reference t_reference = ref StaticValue.editor_projectparam_json.asmdef_sample.reference_list[ii];
					if(t_reference.readmemd_dependence_url == true){
						if(StaticValue.editor_projectparam_json.datalist.TryGetValue(t_reference.rootnamespace,out File_Editor_ProjectParamJson.DataItem t_dataitem) == true){
							t_url_list.Add("* " + t_dataitem.url);
						}else{
							#if(UNITY_EDITOR)
							DebugTool.EditorErrorLog(t_reference.rootnamespace);
							#endif
						}
					}
				}
				t_list.AddRange(t_url_list);
			}

			return t_list;
		}

		/** 「object_root_readme_md」。例。
		*/
		public static System.Collections.Generic.List<string> Create_RootReadMd_Exsample(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();

			#if(ASMDEF_TRUE)

			//path
			string t_path = "Editor/Exsample.cs";

			System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex("^(?<nest>\\t*)\\/\\/(?<command>\\<\\<[a-zA-Z0-9_\\.]*\\>\\>)(?<argument>.*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
			bool t_blocknow = false;
			int t_nest = 0;

			//LoadTextWithAssetsPath
			BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
			if(t_result.result == true){
				string[] t_line_list = t_result.value.Replace("\r","").Split('\n');
				for(int ii=0;ii<t_line_list.Length;ii++){
					System.Text.RegularExpressions.Match t_match = t_regex.Match(t_line_list[ii]);
					if(t_match.Success == true){

						#pragma warning disable 0162
						switch(t_match.Groups["command"].Value){
						case "<<COMMENT>>":
							{
								t_list.Add(t_match.Groups["argument"].Value);
								continue;
							}break;
						case "<<CS_BLOCK_START>>":
							{
								t_list.Add("```cs");
								t_blocknow = true;
								t_nest = t_match.Groups["nest"].Value.Length;
								continue;
							}break;
						case "<<CS_BLOCK_END>>":
							{
								t_list.Add("```");
								t_blocknow = false;
								continue;
							}break;
						case "<<BLOCK_START>>":
							{
								t_list.Add("```");
								t_blocknow = true;
								t_nest = t_match.Groups["nest"].Value.Length;
								continue;
							}break;
						case "<<BLOCK_END>>":
							{
								t_list.Add("```");
								t_blocknow = false;
								continue;
							}break;
						}
						#pragma warning restore
					}

					if(t_blocknow == true){
						if(t_line_list[ii].Length >= t_nest){
							string t_line = t_line_list[ii].Substring(t_nest);
							t_list.Add(t_line);
						}
					}
				}
			}

			#endif

			return t_list;
		}
	}
}
#endif

