

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 「Root/*.VersionManagerWindow.uss」/「Root/*.UpmVersionManagerWindow.uxml」。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Object_RootUssUxml
	*/
	public static class Object_RootUssUxml
	{
		/** Save
		*/
		public static void Save(bool a_must)
		#if(ASMDEF_TRUE)
		{
			//template
			string[] t_uss_template = {
				"Button",
				"{",
				"	font-size: 20px;",
				"	color: rgb(255,255,255);",
				"}",
				"",
				"Label",
				"{",
				"	font-size: 20px;",
				"	color: rgb(255,255,255);",
				"}",
				"",
				".row",
				"{",
				"	flex-direction: row ",
				"}",
				"",
				".way3",
				"{",
				"	width: 33%;",
				"}",
				"",
				".way2",
				"{",
				"	width: 50%;",
				"}",
				"",
				".red",
				"{",
				"	color: rgb(222,66,66);",
				"}",
			};

			string[] t_uxml_template = {
				"<?xml version=\"1.0\" encoding=\"utf-8\"?>",
				"<UXML",
				"	xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"",
				"	xmlns=\"UnityEngine.UIElements\"",
				"	xsi:noNamespaceSchemaLocation=\"../UIElementsSchema/UIElements.xsd\"",
				"	xsi:schemaLocation=\"UnityEngine.UIElements ../UIElementsSchema/UnityEngine.UIElements.xsd\">",
				"",
				"",
				"  <Style src=\"" + Window.TEMPLATE_USS + "\" />",
				"",
				"  <!-- label_1 -->",
				"  <Box>",
				"	<Button name=\"label_1\" text=\"----\" />",
				"	<Label text=\" \"/>",
				"	<Label text=\" \"/>",
				"  </Box>",
				"",
				"",
				"  <Box>",
    			"",
				"	<!-- label_2 -->",
				"	<Box class=\"row\">",
				"	  <Button class=\"way3\" name=\"label_2_1\" text=\"----\" />",
				"	  <Button class=\"way3\" name=\"label_2_2\" text=\"----\" />",
				"	  <Button class=\"way3\" name=\"label_2_3\" text=\"----\" />",
				"	</Box>",
    			"",
				"	<!-- label_3 -->",
				"	<Box class=\"row\">",
				"	  <Button class=\"way3\"  name=\"label_3_1\" text=\"----\" />",
				"	  <Button class=\"way3\"  name=\"label_3_2\" text=\"----\" />",
				"	  <Button class=\"way3\"  name=\"label_3_3\" text=\"----\" />",
				"	</Box>",
    			"",
				"  </Box>",
 				"",
				"  <!-- label_a -->",
				"  <Box>",
				"	<Label text=\" \"/>",
				"	<Label text=\" \"/>",
				"",
				"	<Box class=\"row\">",
				"	  <Label class=\"way3\" name=\"label_a_title\" text=\"----\" />",
				"	  <Label class=\"way3\" name=\"label_a_value\" text=\"----\" />",
				"	</Box>",
				"	<Button name=\"label_a_button\" text=\"---\" />",
				"  </Box>",
				"",
				"  <!-- label_b -->",
				"  <Box>",
				"	<Label text=\" \"/>",
				"	<Label text=\" \"/>",
				"",
				"	<Box class=\"row\">",
				"	  <Label class=\"way3\" name=\"label_b_title\" text=\"----\" />",
				"	  <TextField class=\"way3\" name=\"textfield_b_value\" text=\"----\" />",
				"	</Box>",
				"	<Box class=\"row\">",
				"	  <Button class=\"way3\" name=\"label_b_button_1\" text=\"--\" />",
				"	  <Button class=\"way3\" name=\"label_b_button_2\" text=\"--\" />",
				"	  <Button class=\"way3\" name=\"label_b_button_3\" text=\"--\" />",
				"	</Box>",
				"  </Box>",
				"",
				"  <!-- label_c -->",
				"  <Box>",
				"	<Label text=\" \"/>",
				"	<Label text=\" \"/>",
				"",
				"	<Box class=\"row\">",
				"	  <Label class=\"way3\" name=\"label_c_title\" text=\"----\" />",
				"	  <TextField class=\"way3\" name=\"textfield_c_value\" text=\"----\" />",
				"	</Box>",
				"	<Box class=\"row\">",
				"	  <Button class=\"way3\" name=\"label_c_button_1\" text=\"----\" />",
				"	  <Button class=\"way3\" name=\"label_c_button_2\" text=\"----\" />",
				"	  <Button class=\"way3\" name=\"label_c_button_3\" text=\"----\" />",
				"	</Box>",
				"  </Box>",
				"",
				"</UXML>",
			};

			//SaveTextWithAssetsPath
			{
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check(Window.TEMPLATE_PATH + Window.TEMPLATE_USS) == false)){
					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in t_uss_template){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),Window.TEMPLATE_PATH + Window.TEMPLATE_USS,AssetLib.LineFeedOption.CRLF);		
					BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				}
			}

			//SaveTextWithAssetsPath
			{
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check(Window.TEMPLATE_PATH + Window.TEMPLATE_UXML) == false)){
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in t_uxml_template){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_stringbuilder.ToString(),Window.TEMPLATE_PATH + Window.TEMPLATE_UXML,AssetLib.LineFeedOption.CRLF);
					BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
				}
			}
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

