

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
	/** File_Editor_ProjectParamJson
	*/
	public sealed class File_Editor_ProjectParamJson
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
	}
}
#endif

