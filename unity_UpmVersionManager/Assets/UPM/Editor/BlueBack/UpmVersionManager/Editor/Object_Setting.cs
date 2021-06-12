

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 設定。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_Setting
	*/
	public class Object_Setting
	{
		/** s_instance
		*/
		private static Object_Setting s_instance;

		/** GetInstance
		*/
		public static Object_Setting GetInstance()
		{
			return s_instance;
		}

		/** CreateInstance
		*/
		public static void CreateInstance()
		{
			if(s_instance == null){
				s_instance = new Object_Setting();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Creator_Argument
		*/
		public struct Creator_Argument
		{
			/** constructor
			*/
			public Creator_Argument(string a_version,Object_Setting.Param a_param)
			{
				this.version = a_version;
				this.param = a_param;
			}
			
			/** version
			*/
			public string version;

			/** param
			*/
			public Object_Setting.Param param;
		}

		/** Creator_Type
		*/
		public delegate string[] Creator_Type(in Creator_Argument a_argument);

		/** Param
		*/
		public class Param
		{
			/** author_name
			*/
			public string author_name;

			/** author_url
			*/
			public string author_url;

			/** package_name
			*/
			public string package_name;

			/** getpackageversion
			*/
			public System.Func<string> getpackageversion;

			/** packagejson_unity
			*/
			public string packagejson_unity;

			/** packagejson_discription
			*/
			public string packagejson_discription;

			/** packagejson_keyword
			*/
			public string[] packagejson_keyword;

			/** changelog
			*/
			public string[] changelog;

			/** object_root_readme_md
			*/
			public Creator_Type[] object_root_readme_md;

		}

		/** param
		*/
		public Param param;

		/** constructor
		*/
		private Object_Setting()
		{
		}

		/** Set
		*/
		public void Set(Param a_param)
		{
			UnityEngine.Debug.Log("Object_Setting.Set");
			this.param = a_param;
		}
	}
}
#endif

