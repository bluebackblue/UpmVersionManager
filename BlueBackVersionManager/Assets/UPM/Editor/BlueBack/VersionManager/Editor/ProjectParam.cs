

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ProjectParam。
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
	/** ProjectParam
	*/
	public sealed class ProjectParam
	{
		/** Asmdef
		*/
		public struct Asmdef
		{
			/** Reference
			*/
			public struct Reference
			{
				/** rootnamespace

					例 : "BlueBack.VersionManager"

				*/
				public string rootnamespace;

				/** 「README.MD」。依存関係ＵＲＬを追加。
				*/
				public bool readmemd_dependence_url;

				/** 「ASMDEF」。依存関係アセンブリーを追加。
				*/
				public bool asmdef_reference_assembly;

				/**「ASMDEF」。バージョンデファインを追加。
				*/
				public bool asmdef_version_define;

				/** 「package.json」。依存を追加。
				*/
				public bool package_dependence;
			};

			/** VersionDefine
			*/
			public struct VersionDefine
			{
				public string domain;
				public string define;
				public string expression;
			};

			/** define_constraint_list
			*/
			public string[] define_constraint_list;

			/** reference_list
			*/
			public Reference[] reference_list;

			/** version_define_list
			*/
			public VersionDefine[] version_define_list;
		};

		/** DataItem
		*/
		public struct DataItem
		{
			public string rootnamespace;
			public string domain;
			public string url;
			public string dependence;
		}

		/** ネームスペース。
		*/
		public string namespace_author;
		public string namespace_package;

		/** ＧＩＴ。
		*/
		public string git_url;
		public string git_api;
		public string git_path;

		/** changelog_url
		*/
		public string changelog_url;

		/** 説明。
		*/
		public string description_simple;
		public string[] description_detal;

		/** キーワード。
		*/
		public string[] keyword;

		/** changelog
		*/
		public string[] changelog;

		/** ルート用「README.md」パス。
		*/
		public string root_readmemd_path;

		/** 対応するユニティーバージョン。
		*/
		public string need_unity_version;

		/** デバッグツール生成。
		*/
		public bool debugtool_generate;

		/** license
		*/
		public string license;

		/** asmdef
		*/
		public Asmdef asmdef_runtime;
		public Asmdef asmdef_editor;
		public Asmdef asmdef_sample;

		/** datalist
		*/
		public System.Collections.Generic.Dictionary<string,DataItem> datalist;

		/** constructor
		*/
		public ProjectParam()
		{
			this.namespace_author = "xxxxx";
			this.namespace_package = "xxxxx";
			this.git_url = "https://github.com/xxxxx/xxxxx";
			this.git_api = "https://api.github.com/repos/xxxxx/xxxxx";
			this.git_path = "xxxxx/Assets/UPM";
			this.description_simple = "xxxxx";
			this.description_detal = new string[]{
				"xxxxx",
				"* xxxxx",
				"* xxxxx",
			};
			this.keyword = new string[]{"xxxxx"};
			this.changelog = new string[]{
				"# Changelog",
				"",
				"## [0.0.0] - " + System.DateTime.Today.ToString("yyyy-MM-dd"),
				"### Changes",
				"- Init",
				"",
			};
			this.root_readmemd_path = "";
			this.need_unity_version = "2020.1";
			this.debugtool_generate = true;
			this.license = "MIT License";
			this.datalist = new System.Collections.Generic.Dictionary<string,DataItem>();
			this.asmdef_runtime = new Asmdef(){
				define_constraint_list = new string[]{},
				reference_list = new Asmdef.Reference[]{},
				version_define_list = new Asmdef.VersionDefine[]{},
			};
			this.asmdef_editor = new Asmdef(){
				define_constraint_list = new string[]{},
				reference_list = new Asmdef.Reference[]{
					new Asmdef.Reference(){
						rootnamespace = "xxxxx.xxxxx",
						//TODO:url = "https://xxxxx",
					}
				},
				version_define_list = new Asmdef.VersionDefine[]{},
			};
			this.asmdef_sample = new Asmdef(){
				define_constraint_list = new string[]{},
				reference_list = new Asmdef.Reference[]{},
				version_define_list = new Asmdef.VersionDefine[]{},
			};
		}

		/** Load
		*/
		public static ProjectParam Load()
		#if(ASMDEF_TRUE)
		{
			//path
			string t_path = "Editor/ProejctParam.json.txt";

			//LoadTextWithAssetsPath
			{
				BlueBack.AssetLib.MultiResult<bool,string> t_result = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoad(t_path);
				if(t_result.result == true){
					return BlueBack.JsonItem.Convert.JsonStringToObject<BlueBack.VersionManager.Editor.ProjectParam>(BlueBack.JsonItem.Normalize.Convert(t_result.value));
				}
			}

			//SaveTextWithAssetsPath
			{
				ProjectParam t_projectparam = new ProjectParam();
				string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString<ProjectParam>(t_projectparam);
				t_jsonstring = BlueBack.JsonItem.Pretty.Convert(t_jsonstring,"    ");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_jsonstring,t_path,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				return t_projectparam;
			}
		}
		#else
		{
			#warning "ASMDEF_TRUE"
			return null;
		}
		#endif
	}
}
#endif

