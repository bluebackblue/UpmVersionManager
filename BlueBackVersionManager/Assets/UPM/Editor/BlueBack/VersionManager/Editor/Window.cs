

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ウィンドウ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_ASSETLIB||USERDEF_BLUEBACK_ASSETLIB))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.VersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VersionManager.Editor
{
	/** Window
	*/
	public sealed class Window : UnityEditor.EditorWindow
	{
		/** window
		*/
		public static Window window = null;

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
			Execute_Root_UssUxml_Save.Execute(true);
			Window.window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(Window.window != null){
				Window.window.Show();
			}
		}

		/** 閉じる。
		*/
		[UnityEditor.MenuItem("VersionManager/Close")]
		public static void MenuItem_Close()
		{
			if(Window.window != null){
				Window.window.Close();
				Window.window = null;
			}
		}

		/** constructor
		*/
		public Window()
		{
			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("Window.constructor");
			#endif

			//window
			Window.window = this;

			//タイトル。
			this.titleContent.text = "VersionManager";
		}

		/** OnEnable
		*/
		public void OnEnable()
		{
			#if(ASMDEF_TRUE)

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("Window.OnEnable");
			#endif

			//Execute_Editor_ProjectParamJson_Load
			if(StaticValue.editor_projectparam_json == null){
				Execute_Editor_ProjectParamJson_Load.Execute();
			}

			//Execute_Root_ServerJson_Load
			if(StaticValue.root_server_json == null){
				Execute_Root_ServerJson_Load.Execute();
			}

			{
				UnityEngine.UIElements.VisualElement t_root = Window.window.rootVisualElement;
				{
					t_root.Clear();
					UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.UIElements.VisualTreeAsset>(TEMPLATE_PATH + TEMPLATE_UXML);
					if(t_visualtree == null){
						return;
					}
					UnityEngine.UIElements.VisualElement t_root_element = t_visualtree.CloneTree();
					t_root.Add(t_root_element);
				}

				//バージョン。
				new Button(t_root,"label_1",BlueBack.VersionManager.Version.packageversion,null,new Execute_RestartWindow());

				//ＵＲＬを開く。
				new Button(t_root,"label_2_1","[Open URL]",null,new Execute_Run_OpenURL());

				//ディレクトリを開く。
				new Button(t_root,"label_2_2","[Open Directory]",null,new Execute_Run_OpenDirectory());

				//パッケージロックを削除。
				new Button(t_root,"label_2_3","[Del PackagesLock]",null,new Execute_Delete_PackagesLockJson());

				//コミット。
				new Button(t_root,"label_3_1","[Commit]",null,new Execute_Git_Commit());

				//タグ作成。
				new Button(t_root,"label_3_2","[CreateTag]",null,new Execute_Git_CreateTag());

				//プッシュ。
				new Button(t_root,"label_3_3","[Push]",null,new Execute_Git_Push());

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
							t_label.text = StaticValue.root_server_json.time;
						}
					}

					new Button(t_root,"label_a_button",StaticValue.root_server_json.lasttag,"red",new Execute_Root_ServerJson_Update());
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
							if(StaticValue.root_readme_md == null){
								Execute_Root_ReadmeMd_Load.Execute();
							}
							t_textfield.value = StaticValue.root_readme_md.version;
						}
					}

					//ボタン。
					{
						if(StaticValue.root_server_json == null){
							Execute_Root_ServerJson_Load.Execute();
						}

						if(StaticValue.root_readme_md == null){
							Execute_Root_ReadmeMd_Load.Execute();
						}

						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 - 1);

							string t_class = null;
							if(t_version == StaticValue.root_readme_md.version){
								t_class = "red";
							}

							new Button(t_root,"label_b_button_1",t_version,t_class,new Execute_VersionApply_RootReadmeMd(t_version));
						}

						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2);

							string t_class = null;
							if(t_version == StaticValue.root_readme_md.version){
								t_class = "red";
							}

							new Button(t_root,"label_b_button_2",t_version,t_class,new Execute_VersionApply_RootReadmeMd(t_version));
						}

						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 + 1);

							string t_class = null;
							if(t_version == StaticValue.root_readme_md.version){
								t_class = "red";
							}

							new Button(t_root,"label_b_button_3",t_version,t_class,new Execute_VersionApply_RootReadmeMd(t_version));
						}
					}
				}

				//「package.json」。
				{
					if(StaticValue.root_server_json == null){
						Execute_Root_ServerJson_Load.Execute();
					}

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
							t_textfield.value = Tool.GetPackageVersion();
						}
					}

					//ボタン。
					{
						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 - 1);

							string t_class = null;
							if(t_version == Tool.GetPackageVersion()){
								t_class = "red";
							}

							new Button(t_root,"label_c_button_1",t_version,t_class,new Execute_VersionApply_UpmPackageJson(t_version));
						}

						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2);

							string t_class = null;
							if(t_version == Tool.GetPackageVersion()){
								t_class = "red";
							}

							new Button(t_root,"label_c_button_2",t_version,t_class,new Execute_VersionApply_UpmPackageJson(t_version));
						}

						{
							string[] t_version_split = StaticValue.root_server_json.lasttag.Split('.');
							int t_version_split_item2 = int.Parse(t_version_split[2]);
							string t_version = string.Format("{0}.{1}.{2}",t_version_split[0],t_version_split[1],t_version_split_item2 + 1);

							string t_class = null;
							if(t_version == Tool.GetPackageVersion()){
								t_class = "red";
							}

							new Button(t_root,"label_c_button_3",t_version,t_class,new Execute_VersionApply_UpmPackageJson(t_version));
						}
					}
				}
			}

			#endif
		}
	}
}
#endif

