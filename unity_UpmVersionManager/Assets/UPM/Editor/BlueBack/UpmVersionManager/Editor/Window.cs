

/** Editor.VersionManager
*/
#if(UNITY_EDITOR) && false
namespace Editor.VersionManager
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
		public static void OpenWindow()
		{
			Window t_window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(t_window != null){
				t_window.Show();
			}
		}

		/** 閉じる。
		*/
		public static void CloseWindow()
		{
			if(s_window != null){
				s_window.Close();
				s_window = null;
			}
		}

		/** server_json
		*/
		private Creator_ServerJson server_json;

		/** upm_package_json
		*/
		private Creator_UpmPackageJson upm_package_json;

		/** readme_md
		*/
		private Creator_ReadmeMd readme_md;

		/** upm_changelog_md
		*/
		private Creator_UpmChangeLogMd upm_changelog_md; 

		/** upm_documentation
		*/
		private Creator_UpmDocumentation upm_documentation; 

		/** upm_readme_md
		*/
		private Creator_UpmReadmeMd upm_readme_md; 

		/** constructor
		*/
		public Window()
		{
			s_window = this;

			//server_json
			this.server_json = null;

			//upm_package_json
			this.upm_package_json = null;

			//readme_md
			this.readme_md = null;

			//upm_changelog_md
			this.upm_changelog_md = null;

			//upm_documentation
			this.upm_documentation = null;

			//upm_readme_md
			this.upm_readme_md = null;

			//タイトル。
			this.titleContent.text = "VersionManager";
		}

		/** OnEnable
		*/
		private void OnEnable()
		{
			try{
				//server_json
				this.server_json = new Creator_ServerJson();

				//upm_package_json
				this.upm_package_json = new Creator_UpmPackageJson();

				//readme_md
				this.readme_md = new Creator_ReadmeMd();

				//upm_changelog_md
				this.upm_changelog_md = new Creator_UpmChangeLogMd();

				//upm_documentation
				this.upm_documentation = new Creator_UpmDocumentation();

				//upm_readme_md
				this.upm_readme_md = new Creator_UpmReadmeMd();

				//ルート。
				UnityEngine.UIElements.VisualElement t_root = this.rootVisualElement;
				t_root.Clear();

				//UXMLのロード。
				UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.VisualTreeAsset>("Editor/VersionManager/window.uxml");
				if(t_visualtree == null){
					return;
				}
				UnityEngine.UIElements.VisualElement t_root_element = t_visualtree.CloneTree();
				t_root.Add(t_root_element);

				//リロードボタン。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"reload");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							this.OnEnable();
						};
					}
				}

				//サンプルコピー。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"samplecopy");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							SampleCopy.Copy();
							this.OnEnable();
						};
					}
				}

				//ブラウザを開く。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"openbrowser");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							UnityEngine.Application.OpenURL(Setting.AUTHOR_URL + "/" + Setting.PACKAGE_NAME);
							this.OnEnable();
						};
					}
				}

				//ＵＴＦ８にコンバート。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"converttoutf8");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							BlueBack.AssetLib.Editor.ConvertText.ConvertTextToUtf8FromAssetsPath("",".*","^.*\\.cs$",false,BlueBack.AssetLib.LineFeedOption.CRLF);
							this.OnEnable();
						};
					}
				}

				//「UPM/CAHGELOG.md」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_changelog_md");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							this.upm_changelog_md.Save();
							this.OnEnable();
						};
					}
				}

				//「UPM/Documentation~」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_documentation");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							this.upm_documentation.Save();
							this.OnEnable();
						};
					}
				}

				//「UPM/Documentation~」。
				{
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"upm_readme_md");
					if(t_button != null){
						t_button.clickable.clicked += () => {
							this.upm_readme_md.Save();
							this.OnEnable();
						};
					}
				}

				//「server.json」。
				{
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_server");
						if(t_label != null){
							t_label.text = this.server_json.status.time;
						}
					}

					{
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_server");
						if(t_button != null){
							t_button.text = this.server_json.status.lasttag;
							t_button.AddToClassList("red");

							t_button.clickable.clicked += () => {
								this.server_json.Download();
								this.OnEnable();
							};
						}
					}
				}

				//「readme.md」。
				{
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_readme");
						if(t_label != null){
							t_label.text = this.readme_md.version;
						}
					}

					for(int ii=0;ii<3;ii++){
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_readme_" + ii.ToString());
						if(t_button != null){

							string[] t_version_split = this.server_json.status.lasttag.Split('.');
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
							if(t_version == this.readme_md.version){
								t_button.AddToClassList("red");
							}

							//「package.json」作成。
							t_button.clickable.clicked += () => {
								this.readme_md.Save(t_version);
								this.OnEnable();
							};
						}
					}
				}

				//「package.json」。
				{
					{
						UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"label_package");
						if(t_label != null){
							t_label.text = Setting.GetPackageVersion();
						}
					}

					for(int ii=0;ii<3;ii++){
						UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_package_" + ii.ToString());
						if(t_button != null){

							string[] t_version_split = this.server_json.status.lasttag.Split('.');
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
							if(t_version == Setting.GetPackageVersion()){
								t_button.AddToClassList("red");
							}

							//「package.json」作成。
							t_button.clickable.clicked += () => {
								this.upm_package_json.Save(t_version);
								this.OnEnable();
							};
						}
					}
				}
			}catch(System.Exception t_exception){
				#if(UNITY_EDITOR)
				UnityEngine.Debug.Log(t_exception.Message);
				#endif
			}
		}
	}
}
#endif

