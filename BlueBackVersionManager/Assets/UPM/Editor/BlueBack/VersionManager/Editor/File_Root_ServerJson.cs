

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
	/** File_Root_ServerJson
	*/
	public sealed class File_Root_ServerJson
	{
		/** lasttag
		*/
		public string lasttag;

		/** time
		*/
		public string time;
	}
}
#endif

