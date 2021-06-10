

/** Samples.AssetLib.Script.Editor
*/
namespace Samples.AssetLib.Script.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** 「Enum.cs」を作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Script/CreateEnumToAssetsPath")]
		private static void MenuItem_CreateEnumToAssetsPath()
		{
			System.Collections.Generic.List<BlueBack.AssetLib.Editor.SaveScriptItem> t_list = new System.Collections.Generic.List<BlueBack.AssetLib.Editor.SaveScriptItem>();
			{
				t_list.Add(new BlueBack.AssetLib.Editor.SaveScriptItem("TypeA","タイプＡ"));
				t_list.Add(new BlueBack.AssetLib.Editor.SaveScriptItem("TypeB","タイプＢ"));
				t_list.Add(new BlueBack.AssetLib.Editor.SaveScriptItem("TypeC","タイプＣ"));
				t_list.Add(new BlueBack.AssetLib.Editor.SaveScriptItem("None",-1,"なし"));
			}

			string[] t_template_header = new string[]{
				"",
				"",
				"/** <<file_comment>>",
				"*/",
				"",
				"",
				"/** <<namespace_comment>>",
				"*/",
				"namespace <<namespace_name>>",
				"{",
				"	/** <<enum_comment>>",
				"	*/",
				"	public enum <<enum_name>>",
				"	{",
			};

			string[] t_template_loop = new string[]{
				"		/** <<COMMENT>>。",
				"		*/",
				"		<<VALUE>>,",
				"",
			};

			string[] t_template_loopend = new string[]{
				"		/** <<COMMENT>>。",
				"		*/",
				"		<<VALUE>>,",
			};

			string[] t_template_footer = new string[]{
				"	}",
				"}",
				"",
			};

			System.Collections.Generic.Dictionary<string,string> t_replace_list = new System.Collections.Generic.Dictionary<string,string>();
			{
				t_replace_list.Add("<<file_comment>>","自動生成");

				t_replace_list.Add("<<namespace_comment>>","TestNameSpace");
				t_replace_list.Add("<<namespace_name>>","TestNameSpace");

				t_replace_list.Add("<<enum_comment>>","TestEnum");
				t_replace_list.Add("<<enum_name>>","TestEnum");
			}

			BlueBack.AssetLib.Editor.SaveScript.SaveScriptToAssetsPath(t_list,"Samples/AssetLib/TestEnum.cs",t_template_header,t_template_loop,t_template_loopend,t_template_footer,t_replace_list,false,BlueBack.AssetLib.LineFeedOption.CRLF);
		}
	}
	#endif
}

