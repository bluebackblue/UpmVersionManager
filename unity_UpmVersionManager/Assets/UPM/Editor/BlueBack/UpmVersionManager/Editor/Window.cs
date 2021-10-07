

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
		public static Window s_window = null;

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
			DebugTool.Log("Window.constructor");
			#endif

			//s_window
			s_window = this;

			//タイトル。
			this.titleContent.text = "UpmVersionManager";
		}

		/** OnEnable
		*/
		public void OnEnable()
		{
			#if(DEF_BLUEBACK_UPMVERSIONMANAGER_LOG)
			DebugTool.Log("Window.OnEnable");
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
			Object_RootServerJson.GetInstance().Check();
				
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
				Button_CreateUssUxml.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_1"));

				//ＵＴＦ８にコンバート。
				Button_ConvertToUtf8.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_1"));

				//ブラウザを開く。
				Button_OpenBrowser.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_2"));

				//ディレクトリを開く。
				Button_OpenDirectory.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_2_3"));

				//パッケージロックを削除。
				Button_DeletePacakgeLock.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_1"));

				//ダミー。
				Button_Dummy.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_2"));

				//ダミー。
				Button_Dummy.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_3_3"));

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
					Button_ServerJson.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_a_button"));
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
							Button_RootReadmeMd.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_b_button_" + (ii + 1).ToString()),ii);
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
							Button_UpmPackageJson.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_c_button_" + (ii + 1).ToString()),ii);
						}
					}
				}

				#endif
			}
		}
	}
}

