

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「Root/server.json」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB)&&((ASMDEF_BLUEBACK_JSONITEM||USERDEF_BLUEBACK_JSONITEM)))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_RootServerJson
	*/
	public static class Object_RootServerJson
	{
		/** Status
		*/
		public sealed class Status
		{
			/** lasttag
			*/
			public string lasttag;

			/** time
			*/
			public string time;
		}

		/** status
		*/
		public static Status status = null;
	}
}
#endif

