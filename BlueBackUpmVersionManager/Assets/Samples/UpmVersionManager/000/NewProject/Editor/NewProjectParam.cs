

/** Samples.UpmVersionManager.NewProject.Editor
*/
namespace Samples.UpmVersionManager.NewProject.Editor
{
	/** NewProjectParam
	*/
	public struct NewProjectParam
	{
		public struct Asmdef
		{
			public struct ReferenceList
			{
				public string package_fullname;
				public string url;
			};
			public ReferenceList reference_list;
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
		public string discription;

		/** ルート用「README.md」パス。
		*/
		public string root_readmemd_path;

		/** キーワード。
		*/
		public string[] keyword;

		/** 概要。
		*/
		public string[] overview;

		/** asmdef
		*/
		public Asmdef[] asmdef_runtime;
		public Asmdef[] asmdef_editor;
		public Asmdef[] asmdef_sample;

		/** CreateDefault
		*/
		public static NewProjectParam CreateDefault()
		{
			return new NewProjectParam(){
				namespace_author = "xxxxx",
				namespace_package = "xxxxx",
				need_unity_version = "2020.1",
				git_url = "https://github.com/bluebackblue/<<git_repos>>",
				git_api = "https://api.github.com/repos/bluebackblue/<<git_repos>>",
				git_path = "xxxx/Assets/UPM",
				discription = "説明",
				root_readmemd_path = "../../README.md",
				keyword = new string[]{},
				overview = new string[]{
					"xxxxx",
					"* xxxxx",
					"* xxxxx",
				},
				asmdef_runtime = new Asmdef[]{
					new Asmdef(){
						reference_list = new Asmdef.ReferenceList(){
							package_fullname = "xxxxx",
							url = "xxxxx",
						},
					},
				},
				asmdef_editor = new Asmdef[]{
					new Asmdef(){
						reference_list = new Asmdef.ReferenceList(){
							package_fullname = "xxxxx",
							url = "xxxxx",
						},
					},
				},
				asmdef_sample = new Asmdef[]{
					new Asmdef(){
						reference_list = new Asmdef.ReferenceList(){
							package_fullname = "xxxxx",
							url = "xxxxx",
						},
					},
				},
			};
		}
	}
}

