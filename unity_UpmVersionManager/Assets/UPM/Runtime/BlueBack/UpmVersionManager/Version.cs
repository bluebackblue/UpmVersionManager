

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
		/** version
		*/
		public const string packageversion = "0.0.3";

		/** GetPackageVersion
		*/
		public static string GetPackageVersion()
		{
			return packageversion;
		}
	}
}

