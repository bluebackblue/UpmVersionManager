

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 「Root/*.UpmVersionManagerWindow.uss」/「Root/*.UpmVersionManagerWindow.uxml」。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Object_RootUssUxml
	*/
	public static class Object_RootUssUxml
	{
		/** CreateFile
		*/
		public static void Save(bool a_must)	
		{
			//path
			string t_uss_path = "UpmVersionManagerWindow.uss";
			string t_uxml_path = "UpmVersionManagerWindow.uxml";

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
				"  <Style src=\"UpmVersionManagerWindow.uss\" />",
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

			//uss
			{
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_uss_path) == false)){
					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in t_uss_template){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_uss_path,false,AssetLib.LineFeedOption.CRLF);
					
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_uss_path);
					#endif
				}
			}

			//uxml
			{
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_uxml_path) == false)){
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in t_uxml_template){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_uxml_path,false,AssetLib.LineFeedOption.CRLF);

					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.Log("save : " + t_uxml_path);
					#endif
				}
			}

			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	}
}
#endif
