

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
	public class Object_RootUssUxml
	{
		/** USS
		*/
		public readonly static string[] USS = {
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

		/** USS
		*/
		public readonly static string[] UXML = {
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
			"  <!-- リロード -->",
			"  <Box>",
			"	<Button name=\"reload\" text=\"ReLoad\" />",
			"	<Label text=\" \"/>",
			"	<Label text=\" \"/>",
			"  </Box>",
			"",
			"",
			"  <Box>",
    		"",
			"	<Box class=\"row\">",
			"	  <Button class=\"way3\" name=\"upm_changelog_md\" text=\"UPM/CHANGELOG.md\" />",
			"	  <Button class=\"way3\" name=\"upm_documentation\" text=\"UPM/Documentation~\" />",
			"	  <Button class=\"way3\" name=\"upm_readme_md\" text=\"UPM/README.md\" />",
			"	</Box>",
    		"",
			"	<Box class=\"row\">",
			"	  <Button class=\"way3\"  name=\"samplecopy\" text=\"SampleCopy\" />",
			"	  <Button class=\"way3\"  name=\"converttoutf8\" text=\"ConvertToUtf8\" />",
			"	  <Button class=\"way3\"  name=\"openbrowser\" text=\"OpenBrowser\" />",
			"	</Box>",
    		"",
			"  </Box>",
 			"",
			"  <!-- server.json -->",
			"  <Box>",
			"	<Label text=\" \"/>",
			"	<Label text=\" \"/>",
			"",
			"	<Box class=\"row\">",
			"	  <Label class=\"way3\" text=\"server.json\" />",
			"	  <Label class=\"way3\" name=\"label_server\" text=\"---\" />",
			"	</Box>",
			"	<Button name=\"button_server\" text=\"---\" />",
			"  </Box>",
			"",
			"  <!-- readme.md -->",
			"  <Box>",
			"	<Label text=\" \"/>",
			"	<Label text=\" \"/>",
			"",
			"	<Box class=\"row\">",
			"	  <Label class=\"way3\" text=\"Root/README.md\"/>",
			"	  <Label class=\"way3\" name=\"label_readme\" text=\"---\" />",
			"	</Box>",
			"	<Box class=\"row\">",
			"	  <Button class=\"way3\" name=\"button_readme_0\" text=\"---\" />",
			"	  <Button class=\"way3\" name=\"button_readme_1\" text=\"---\" />",
			"	  <Button class=\"way3\" name=\"button_readme_2\" text=\"---\" />",
			"	</Box>",
			"  </Box>",
			"",
			"  <!-- UPM/package.json -->",
			"  <Box>",
			"	<Label text=\" \"/>",
			"	<Label text=\" \"/>",
			"",
			"	<Box class=\"row\">",
			"	  <Label class=\"way3\" text=\"UPM/package.json\"/>",
			"	  <Label class=\"way3\" name=\"label_package\" text=\"---\" />",
			"	</Box>",
			"	<Box class=\"row\">",
			"	  <Button class=\"way3\" name=\"button_package_0\" text=\"---\" />",
			"	  <Button class=\"way3\" name=\"button_package_1\" text=\"---\" />",
			"	  <Button class=\"way3\" name=\"button_package_2\" text=\"---\" />",
			"	</Box>",
			"  </Box>",
			"",
			"</UXML>",
		};

		/** CreateFile
		*/
		public static void CreateFile(bool a_must)	
		{
			//uss
			{
				string t_path = "UpmVersionManagerWindow.uss";
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path) == false)){
					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in USS){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("save : " + t_path);
					#endif
				}
			}

			//uxml
			{
				string t_path = "UpmVersionManagerWindow.uxml";
				if((a_must == true)||(BlueBack.AssetLib.Editor.ExistFile.IsExistFileFromAssetsPath(t_path) == false)){
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
					foreach(string t_item in UXML){
						t_stringbuilder.Append(t_item);
						t_stringbuilder.Append("\n");
					}

					BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),t_path,false,AssetLib.LineFeedOption.CRLF);
					#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
					DebugTool.LogProc("save : " + t_path);
					#endif
				}
			}
		}
	}
}
#endif

