

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「UPM/package.json」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** PackageJson
	*/
	public struct PackageJson
	{
		/** Author
		*/
		public struct Author
		{
			/** 名前。
			*/
			public string name;

			/** ＵＲＬ。
			*/
			public string url;
		}

		/** Samples
		*/
		public struct Samples
		{
			/** 表示名。
			*/
			public string displayName;

			/** パス。
			*/
			public string path;
		}

		/** 名前。
		*/
		public string name;

		/** 表示名。
		*/
		public string displayName;

		/** version
		*/
		public string version;

		/** unity
		*/
		public string unity;

		/** 説明。
		*/
		public string discription;

		/** 作者。
		*/
		public Author author;

		/** キーワード。
		*/
		public string[] keyword;

		/** 依存関係。
		*/
		public System.Collections.Generic.Dictionary<string,string> dependencies;

		/** サンプル。
		*/
		public System.Collections.Generic.List<Samples> samples;
	}
}
#endif

