

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ウィンドウ。
*/


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Window
	*/
	public sealed class Window : UnityEditor.EditorWindow
	{
		/** s_window
		*/
		public static Window s_window = null;

		/** TEMPLATE
		*/
		public const string TEMPLATE_PATH = "Editor/";
		public const string TEMPLATE_USS = "VersionManagerWindow.uss";
		public const string TEMPLATE_UXML = "VersionManagerWindow.uxml";

		/** 開く。
		*/
		[UnityEditor.MenuItem("VersionManager/Open")]
		public static void MenuItem_Open()
		{
			Object_RootUssUxml.Save(true);
			s_window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(s_window != null){
				s_window.Show();
			}
		}

		/** 閉じる。
		*/
		[UnityEditor.MenuItem("VersionManager/Close")]
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
			#if(DEF_BLUEBACK_VERSIONMANAGER_LOG)
			DebugTool.Log("Window.constructor");
			#endif

			//s_window
			s_window = this;

			//タイトル。
			this.titleContent.text = "VersionManager";
		}

		/** OnEnable
		*/
		public void OnEnable()
		{
			#if(DEF_BLUEBACK_VERSIONMANAGER_LOG)
			DebugTool.Log("Window.OnEnable");
			#endif
			
			Object_Setting.s_projectparam = ProjectParam.Load();
			if(Object_RootServerJson.s_status == null){
				Object_RootServerJson.Load();
			}

			{
				UnityEngine.UIElements.VisualElement t_root = s_window.rootVisualElement;
				{
					t_root.Clear();
					UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.UIElements.VisualTreeAsset>(TEMPLATE_PATH + TEMPLATE_UXML);
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
							t_label.text = Object_RootServerJson.s_status.time;
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
						UnityEngine.UIElements.TextField t_textfield = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.TextField>(t_root,"textfield_b_value");
						if(t_textfield != null){
							if(Object_RootReadmeMd.s_version == null){
								Object_RootReadmeMd.Load();
							}
							t_textfield.value = Object_RootReadmeMd.s_version;
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
						UnityEngine.UIElements.TextField t_textfield = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.TextField>(t_root,"textfield_c_value");
						if(t_textfield != null){
							t_textfield.value = Object_Setting.GetPackageVersion();
						}
					}

					//ボタン。
					{
						for(int ii=0;ii<3;ii++){
							Button_UpmPackageJson.Initialize(UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"label_c_button_" + (ii + 1).ToString()),ii);
						}
					}
				}
			}
		}
	}
}
#endif

