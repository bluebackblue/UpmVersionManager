

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief バージョン。
*/


/** BlueBack.UpmVersionManager
*/
namespace BlueBack.UpmVersionManager
{
	/** Version
	*/
	public class Version
	{
		/** packagename
		*/
		public const string packagename = "UpmVersionManager";

		/** packageversion
		*/
		public const string packageversion = "0.0.16";

		/** GetPackageVersion
		*/
		public static string GetPackageVersion()
		{
			return packageversion;
		}
	}
}

