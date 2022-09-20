

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
	/** File_Editor_ProjectParamJson_DataList
	*/
	public sealed class File_Editor_ProjectParamJson_DataList
	{
		/** datalist
		*/
		public System.Collections.Generic.Dictionary<string,File_Editor_ProjectParamJson.DataItem> datalist;
	}
}
#endif

