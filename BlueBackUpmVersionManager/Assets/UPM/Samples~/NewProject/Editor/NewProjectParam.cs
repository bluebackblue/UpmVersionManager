

/** Samples.UpmVersionManager.NewProject.Editor
*/
namespace Samples.UpmVersionManager.NewProject.Editor
{
	/** NewProjectParam
	*/
	public struct NewProjectParam
	{
		/** package_name
		*/
		public string package_name;

		/** 対応するユニティーバージョン。
		*/
		public string need_unity_version;

		/** 管理者名。
		*/
		public string author_name;

		/** ＧＩＴ。
		*/
		public string git_url;
		public string git_author;
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

		/** CreateDefault
		*/
		public static NewProjectParam CreateDefault()
		{
			return new NewProjectParam(){
				package_name = "xxxxx",
				need_unity_version = "2020.1",
				author_name = "xxxxx",
				git_url = "https://github.com/",
				git_author = "xxxxx",
				git_path = "xxxx/Assets/UPM",
				discription = "説明",
				root_readmemd_path = "../../README.md",
				keyword = new string[]{},
				overview = new string[]{
					"xxxxx",
					"* xxxxx",
					"* xxxxx",
				},
			};
		}
	}
}

