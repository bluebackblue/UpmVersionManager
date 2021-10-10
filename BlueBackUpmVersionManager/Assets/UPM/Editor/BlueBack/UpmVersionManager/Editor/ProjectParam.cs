

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ProjectParam。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** ProjectParam
	*/
	public class ProjectParam
	{
		/** Asmdef
		*/
		public struct Asmdef
		{
			/** Reference
			*/
			public struct Reference
			{
				public string package_fullname;
				public string url;
			};
			public struct Define
			{
				public string package_pathname;
				public string define;
				public string expression;
			};
			public Reference[] reference_list;
			public Define[] define_list;
		};

		/** ネームスペース。
		*/
		public string namespace_author;
		public string namespace_package;

		/** 対応するユニティーバージョン。
		*/
		public string need_unity_version;

		/** ＧＩＴ。
		*/
		public string git_url;
		public string git_api;
		public string git_path;

		/** 説明。
		*/
		public string discription_package;
		public string[] discription_readme;

		/** ルート用「README.md」パス。
		*/
		public string root_readmemd_path;

		/** キーワード。
		*/
		public string[] keyword;

		/** 概要。
		*/
		public string[] overview;

		/** changelog
		*/
		public string[] changelog;

		/** asmdef
		*/
		public Asmdef asmdef_runtime;
		public Asmdef asmdef_editor;
		public Asmdef asmdef_sample;

		/** constructor
		*/
		public ProjectParam()
		{
			this.namespace_author = "";
			this.namespace_package = "";
			this.need_unity_version = "";
			this.git_url = "";
			this.git_api = "";
			this.git_path = "";
			this.discription_package = "";
			this.discription_readme = new string[]{
				"xxxxx",
				"* xxxxx",
				"* xxxxx",
			};
			this.root_readmemd_path = "";
			this.keyword = new string[]{"xxxxx"};
			this.overview = new string[]{"xxxxx"};
			this.changelog = new string[]{
				"# Changelog",
				"",
				"## [0.0.1] - " + System.DateTime.Today.ToString("yyyy-MM-dd"),
				"### Changes",
				"- Init",
				"",
			};
			this.asmdef_runtime = new Asmdef(){
				reference_list = new Asmdef.Reference[]{},
				define_list = new Asmdef.Define[]{},
			};
			this.asmdef_editor = new Asmdef(){
				reference_list = new Asmdef.Reference[]{
					new Asmdef.Reference(){
						package_fullname = "xxxxx.xxxxx",
						url = "https://xxxxx",
					}
				},
				define_list = new Asmdef.Define[]{},
			};
			this.asmdef_sample = new Asmdef(){
				reference_list = new Asmdef.Reference[]{},
				define_list = new Asmdef.Define[]{},
			};
		}

		/** Load
		*/
		public static ProjectParam Load()
		{
			string t_path = "Editor/ProejctParam.json.txt";
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log(t_path);
			#endif

			{
				string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromAssetsPath(t_path,System.Text.Encoding.UTF8);
				if(t_jsonstring != null){
					return BlueBack.JsonItem.Convert.JsonStringToObject<BlueBack.UpmVersionManager.Editor.ProjectParam>(BlueBack.JsonItem.Normalize.Convert(t_jsonstring));
				}
			}

			{
				ProjectParam t_projectparam = new ProjectParam();
				string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString<ProjectParam>(t_projectparam);
				t_jsonstring = BlueBack.JsonItem.Pretty.Convert(t_jsonstring,"    ");
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring,t_path,false,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
				return t_projectparam;
			}
		}
	}
}
#endif

