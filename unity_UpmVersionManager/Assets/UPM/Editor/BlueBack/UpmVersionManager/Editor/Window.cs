

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ウィンドウ。
*/


/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
	/** Window
	*/
	public class Window : UnityEditor.EditorWindow
	{
		/** s_window
		*/
		private static Window s_window = null;

		/** 開く。
		*/
		[UnityEditor.MenuItem("UpmVersionManager/Open")]
		public static void MenuItem_Open()
		{
			UnityEngine.Debug.Log("Window.MenuItem_Open");
			s_window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(s_window != null){
				UnityEngine.Debug.Log("Window.Show");
				s_window.Show();
			}
		}

		/** 閉じる。
		*/
		[UnityEditor.MenuItem("UpmVersionManager/Close")]
		public static void MenuItem_Close()
		{
			UnityEngine.Debug.Log("Window.MenuItem_Close");

			if(s_window != null){
				s_window.Close();
				s_window = null;
			}
		}

		/** constructor
		*/
		public Window()
		{
			UnityEngine.Debug.Log("Window.constructor");

			//s_window
			s_window = this;

			//タイトル。
			this.titleContent.text = "VersionManager";
		}

		/** ボタン。リロード。
		*/
		public void Button_Reload()
		{
			s_window.OnEnable();
		}

		/** ボタン。サンプルコピー。
		*/
		public void Button_SampleCopy()
		{
			Object_UpmSamples.Copy();
			s_window.OnEnable();
		}

		/** ボタン。オープンブラウザー。
		*/
		public void Button_OpenBrowser()
		{
			if(Object_Setting.GetInstance() != null){
				UnityEngine.Application.OpenURL(Object_Setting.GetInstance().param.author_url + "/" + Object_Setting.GetInstance().param.package_name);
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** ボタン。コンバート。ＵＴＦ８。
		*/
		public void Button_ConvertToUtf8()
		{
			BlueBack.AssetLib.Editor.ConvertText.ConvertTextToUtf8FromAssetsPath("",".*","^.*\\.cs$",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			s_window.OnEnable();
		}

		/** ボタン。「UPM/CHANGELOG.md」。
		*/
		public void Button_Upm_ChangeLog_Md()
		{
			Object_UpmChangeLogMd.Save();
			s_window.OnEnable();
		}

		/** ボタン。「UPM/Documentation」。
		*/
		public void Button_Upm_Documentation()
		{
			Object_UpmDocumentation.Save();
			s_window.OnEnable();
		}

		/** ボタン。「UPM/README.md」。
		*/
		public void Button_Upm_Readme_Md()
		{
			Object_UpmReadmeMd.Save();
			s_window.OnEnable();
		}

		/** ボタン。「server.json」。
		*/
		public void Button_Server_Json()
		{
			Object_RootServerJson.CreateInstance();
			if(Object_RootServerJson.GetInstance() != null){
				Object_RootServerJson.GetInstance().DownloadAndSave();
				s_window.OnEnable();
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** Button_Readme_Md
		*/
		public void Button_Readme_Md(string a_version)
		{
			Object_RootReadmeMd.Save(a_version);
			s_window.OnEnable();
		}

		/** Button_Upm_Package_Json
		*/
		public void Button_Upm_Package_Json(string a_version)
		{
			Object_UpmVersionCs.Save(a_version);
			Object_UpmPackageJson.Save(a_version);
			s_window.OnEnable();
		}

		/** OnEnable
		*/
		private void OnEnable()
		{
			UnityEngine.Debug.Log("Window.OnEnable");

			//「readme.md」。
			if(Object_RootReadmeMd.GetInstance() == null){
				Object_RootReadmeMd.CreateInstance();
				Object_RootReadmeMd.GetInstance().Load();
			}

			//「Root/server.json」。
			if(Object_RootServerJson.GetInstance() == null){
				Object_RootServerJson.CreateInstance();
				Object_RootServerJson.GetInstance().Load();
			}

			/*try*/{
				UnityEngine.UIElements.VisualElement t_root = s_window.rootVisualElement;
				{
					t_root.Clear();
					UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.VisualTreeAsset>("UpmVersionManagerWindow.uxml");
					if(t_visualtree == null){
						return;
					}
					UnityEngine.UIElements.VisualElement t_root_element = t_visualtree.CloneTree();
					t_root.Add(t_root_element);
				}

				//リロードボタン。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"reload");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_Reload();
						};
					}
				}

				//サンプルコピー。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"samplecopy");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_SampleCopy();
						};
					}
				}

				//ブラウザを開く。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"openbrowser");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_OpenBrowser();
						};
					}
				}

				//ＵＴＦ８にコンバート。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"converttoutf8");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_ConvertToUtf8();
						};
					}
				}

				//「UPM/CAHGELOG.md」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_changelog_md");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_Upm_ChangeLog_Md();
						};
					}
				}

				//「UPM/Documentation~」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_documentation");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_Upm_Documentation();
						};
					}
				}

				//「UPM/README.md」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_readme_md");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							s_window.Button_Upm_Readme_Md();
						};
					}
				}

				//「server.json」。
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_server");
					if(t_label != null){
						t_label.text = Object_RootServerJson.GetInstance().status.time;
					}
				}

				//「server.json」。
				{
					{
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_server");
						if(t_button != null){
							t_button.text = Object_RootServerJson.GetInstance().status.lasttag;
							t_button.AddToClassList("red");

							t_button.clickable.clicked += () => {
								s_window.Button_Server_Json();
							};
						}
					}
				}

				//「readme.md」。
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_readme");
					if(t_label != null){
						t_label.text = Object_RootReadmeMd.GetInstance().version;
					}
				}

				//「readme.md」。
				{
					for(int ii=0;ii<3;ii++){
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_readme_" + ii.ToString());
						if(t_button != null){

							string[] t_version_split = Object_RootServerJson.GetInstance().status.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);

							string t_version;

							switch(ii){
							case 0:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 - 1);
								}break;
							case 1:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2);
								}break;
							case 2:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 + 1);
								}break;
							default:
								{
									t_version = "";
									UnityEngine.Debug.Assert(false);
								}break;
							}

							t_button.text = t_version;
							if(t_version == Object_RootReadmeMd.GetInstance().version){
								t_button.AddToClassList("red");
							}

							//「readme.md」作成。
							t_button.clickable.clicked += () => {
								s_window.Button_Readme_Md(t_version);
							};
						}
					}
				}

				//「package.json」。
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_package");
					if(t_label != null){
						if(Object_Setting.GetInstance().param.getpackageversion != null){
							t_label.text = Object_Setting.GetInstance().param.getpackageversion();
						}else{
							t_label.text = "null";
						}
					}
				}

				//「package.json」。
				{
					for(int ii=0;ii<3;ii++){
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_package_" + ii.ToString());
						if(t_button != null){

							string[] t_version_split = Object_RootServerJson.GetInstance().status.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);

							string t_version;

							switch(ii){
							case 0:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 - 1);
								}break;
							case 1:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2);
								}break;
							case 2:
								{
									t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 + 1);
								}break;
							default:
								{
									t_version = "";
									UnityEngine.Debug.Assert(false);
								}break;
							}

							t_button.text = t_version;
							if(Object_Setting.GetInstance().param.getpackageversion != null){
								if(t_version == Object_Setting.GetInstance().param.getpackageversion()){
									t_button.AddToClassList("red");
								}
							}else{
								UnityEngine.Debug.LogError("null");
							}

							//「package.json」作成。
							t_button.clickable.clicked += () => {
								s_window.Button_Upm_Package_Json(t_version);
							};
						}
					}
				}
				#endif
			}/*catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false,t_exception.Message);
				#endif
			}*/
		}
	}
}

