

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ProjectParam。
*/


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
				/** mode

					"package"	: 参照の追加。
					"url"		: リンクのみ追加。

				*/
				public string mode;

				/** package_fullname

					例 : "BlueBack.VersionManager"

				*/
				public string package_fullname;

				/** url

					例 : "https://xxx"

				*/
				public string url;

				/** define_package_pathname
				*/
				public string define_package_pathname;
			};

			/** Define
			*/
			public struct Define
			{
				public string mode;
				public string package_pathname;
				public string define;
				public string expression;
			};
			
			/** reference_list
			*/
			public Reference[] reference_list;

			/** define_list
			*/
			public Define[] define_list;
		};

		/** ネームスペース。
		*/
		public string namespace_author;
		public string namespace_package;

		/** ＧＩＴ。
		*/
		public string git_url;
		public string git_api;
		public string git_path;

		/** 説明。
		*/
		public string discription_simple;
		public string[] discription_detal;

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

		/** asmdef
		*/
		public Asmdef asmdef_runtime;
		public Asmdef asmdef_editor;
		public Asmdef asmdef_sample;

		/** constructor
		*/
		public ProjectParam()
		{
			this.namespace_author = "xxxxx";
			this.namespace_package = "xxxxx";
			this.git_url = "https://github.com/xxxxx/xxxxx";
			this.git_api = "https://api.github.com/repos/xxxxx/xxxxx";
			this.git_path = "xxxxx/Assets/UPM";
			this.discription_simple = "xxxxx";
			this.discription_detal = new string[]{
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
			#if((ASMDEF_BLUEBACK_ASSETLIB)&&(ASMDEF_BLUEBACK_JSONITEM))
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
				return null;
			}
			#endif
		}
	}
}
#endif

