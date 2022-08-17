

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「UPM/package.json」。
*/


/** BlueBack.VersionManager.Editor

	https://docs.unity3d.com/ja/2022.1/Manual/upm-manifestPkg.html

*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
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

			/** メール。
			*/
			public string email;

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

			/** 説明。
			*/
			public string description;

			/** パス。
			*/
			public string path;
		}

		/** 名前。

			The officially registered package name.

		*/
		public string name;

		/** version

			パッケージのバージョン番号 (MAJOR.MINOR.PATCH)。

		*/
		public string version;

		/** description

			パッケージの簡単な説明(UTF8)。

		*/
		public string description;

		/** 表示名。
		*/
		public string displayName;

		/** unity

			パッケージが互換性のある最も低いUnityのバージョン。

		*/
		public string unity;

		/** author

			The author of the package.

		*/
		public Author author;

		/** changelogUrl

			Custom location for this package’s changelog specified as a URL. For example:

			例："documentationUrl" : "https://github.com/xxx/xxx/commits/main"

		*/
		public string changelogUrl;

		/** 依存関係。
		*/
		public System.Collections.Generic.Dictionary<string,string> dependencies;

		/** documentationUrl

			Custom location for this package’s documentation specified as a URL. For example:

			例 : "documentationUrl" : "https://github.com/xxx/xxx/blob/main/README.md"

		*/
		public string documentationUrl;

		/** hideInEditor
		*/
		public bool hideInEditor;

		/** 検索キーワード。
		*/
		public string[] keywords;

		/** license

			https://spdx.org/licenses/

			例 : "license" : "MIT License"

		*/
		public string license;

		/** licensesUrl

			Custom location for this package’s license information specified as a URL. For example:

			"licensesUrl": "https://github.com/xxx/xxx/blob/main/LICENSE"

		*/
		public string licensesUrl;

		/** サンプル。
		*/
		public System.Collections.Generic.List<Samples> samples;

		/** type

			内部使用のために予約されています。

		*/
		public string type;

		/** unityRelease

			The expected format is “<UPDATE><RELEASE>” (for example, 0b4).

		*/
		public string unityRelease;
	}
}
#endif

