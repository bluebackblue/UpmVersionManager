

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
			Object_RootUssUxml.CreateFile(true);
			s_window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(s_window != null){
				s_window.Show();
			}
		}

		/** 閉じる。
		*/
		[UnityEditor.MenuItem("UpmVersionManager/Close")]
		public static void MenuItem_Close()
		{
			if(s_window != null){
				s_window.Close();
				s_window = null;
			}
		}

		/** constructor
		*/
		public Window()
		{
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.LogProc("Window.constructor");
			#endif

			//s_window
			s_window = this;

			//タイトル。
			this.titleContent.text = "UpmVersionManager";
		}

		/** ボタン。ＵＳＳＵＸＭＬ作成。
		*/
		public void Button_CreateUssUxmll()
		{
			Object_RootUssUxml.CreateFile(true);
			s_window.OnEnable();
		}

		/** ボタン。ディレクトリを開く。
		*/
		public void Button_OpenDirectory()
		{
			if(Object_Setting.GetInstance() != null){
				UnityEditor.CommandExecuteContext t_xe = new UnityEditor.CommandExecuteContext();

				System.Diagnostics.Process.Start(UnityEngine.Application.dataPath + "/../../");
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
		}

		/** ボタン。パッケージロック削除。
		*/
		public void Button_DeletePackageLock()
		{
			if(Object_Setting.GetInstance() != null){
				BlueBack.AssetLib.Editor.DeleteFile.TryDeleteFileFromAssetsPath("../Packages/packages-lock.json");
			}else{
				#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
				DebugTool.Assert(false);
				#endif
			}
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
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.LogProc("ConvertToUtf8");
			#endif
			BlueBack.AssetLib.Editor.ConvertText.ConvertTextToUtf8FromAssetsPath("",".*","^.*\\.(cs|meta|mesh|prefab|json|asmdef)$",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			s_window.OnEnable();
		}

		/** ボタン。「server.json」。
		*/
		public void Button_Server_Json()
		{
			if(Object_RootServerJson.GetInstance() == null){
				Object_RootServerJson.CreateInstance();
			}

			Object_RootServerJson.GetInstance().DownloadAndSave();
			Object_RootServerJson.GetInstance().Load();
			s_window.OnEnable();
		}

		/** Button_Readme_Md
		*/
		public void Button_Readme_Md(string a_version)
		{
			Object_RootReadmeMd.Save(a_version);
			Object_RootReadmeMd.GetInstance().Load();
			s_window.OnEnable();
		}

		/** Button_Upm_Package_Json
		*/
		public void Button_Upm_Package_Json(string a_version)
		{
			Object_UpmSamples.Copy();
			
			Object_UpmChangeLogMd.Save();

			Object_UpmDocumentation.Save(a_version);
			Object_UpmReadmeMd.Save(a_version);
			Object_UpmVersionCs.Save(a_version);
			Object_UpmPackageJson.Save(a_version);
			s_window.OnEnable();
		}

		/** OnEnable
		*/
		private void OnEnable()
		{
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.LogProc("Window.OnEnable");
			#endif

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

			{
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

				//ＵＳＳＵＸＭＬ。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_1");
					if(t_button != null){
						t_button.text = "[CreateUssUxml]";
						t_button.clickable.clicked += () => {
							s_window.Button_CreateUssUxmll();
						};
					}
				}

				//ＵＴＦ８にコンバート。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_1");
					if(t_button != null){
						t_button.text = "[ConvertToUtf8]";
						t_button.clickable.clicked += () => {
							s_window.Button_ConvertToUtf8();
						};
					}
				}

				//ブラウザを開く。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_2");
					if(t_button != null){
						t_button.text = "[OpenBrowser]";
						t_button.clickable.clicked += () => {
							s_window.Button_OpenBrowser();
						};
					}
				}

				//パッケージロックを削除。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_3");
					if(t_button != null){
						t_button.text = "[DeletePacakgeLock]";
						t_button.clickable.clicked += () => {
							s_window.Button_DeletePackageLock();
						};
					}
				}

				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_1");
					if(t_button != null){
						t_button.text = "[OpenDirectory]";
						t_button.clickable.clicked += () => {
							s_window.Button_OpenDirectory();
						};
					}
				}

				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_2");
					if(t_button != null){
						/*
						t_button.text = "[]";
						t_button.clickable.clicked += () => {
							s_window.Button_SampleCopy();
						};
						*/
					}
				}

				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_3");
					if(t_button != null){
						/*
						t_button.text = "[]";
						t_button.clickable.clicked += () => {
							s_window.Button_SampleCopy();
						};
						*/
					}
				}

				//「server.json」。
				{
					//タイトル。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_a_title");
						if(t_label != null){
							t_label.text = "[server.json]";
						}
					}

					//値。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_a_value");
						if(t_label != null){
							t_label.text = Object_RootServerJson.GetInstance().status.time;
						}
					}

					//ボタン。
					{
						{
							UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_a_button");
							if(t_button != null){
								t_button.text = Object_RootServerJson.GetInstance().status.lasttag;
								t_button.AddToClassList("red");
								t_button.clickable.clicked += () => {
									s_window.Button_Server_Json();
								};
							}
						}
					}
				}

				//「readme.md」。
				{
					//タイトル。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_b_title");
						if(t_label != null){
							t_label.text ="[Root/README.md]";
						}
					}

					//値。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_b_value");
						if(t_label != null){
							t_label.text = Object_RootReadmeMd.GetInstance().version;
						}
					}

					//ボタン。
					{
						for(int ii=0;ii<3;ii++){
							UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_b_button_" + (ii + 1).ToString());
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
				}

				//「package.json」。
				{
					//タイトル。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_c_title");
						if(t_label != null){
							t_label.text = "[UPM/package.json]";
						}
					}

					//値。
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_c_value");
						if(t_label != null){
							t_label.text = Object_Setting.GetInstance().param.getpackageversion();
						}
					}

					//ボタン。
					{
						for(int ii=0;ii<3;ii++){
							UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_c_button_" + (ii + 1).ToString());
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
									#if(DEF_BLUEBACK_UPMVERSIONMANAGER_ASSERT)
									DebugTool.Assert(false);
									#endif
								}

								//「package.json」作成。
								t_button.clickable.clicked += () => {
									s_window.Button_Upm_Package_Json(t_version);
								};
							}
						}
					}
				}

				#endif
			}
		}
	}
}

