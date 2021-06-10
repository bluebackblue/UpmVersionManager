

/** Samples.AssetLib.Asset.Editor
*/
namespace Samples.AssetLib.Asset.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** テキストのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadTextFromAssetsPath")]
		private static void MenuItem_LoadTextFromAssetsPath()
		{
			//テキストの保存。
			{
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("xxxBBBxxx\nxxxBBBxxx","Samples/AssetLib/xxx.txt",true,BlueBack.AssetLib.LineFeedOption.LF);
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			string t_text = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromAssetsPath("Samples/AssetLib/xxx.txt",null);
			UnityEngine.Debug.Log(t_text);
		}

		/** バイナリのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadBinaryFromAssetsPath")]
		private static void MenuItem_LoadBinaryFromAssetsPath()
		{
			//バイナリのセーブ。
			{
				BlueBack.AssetLib.Editor.SaveBinary.SaveBinaryToAssetsPath(new byte[]{0x01,0x02,0x03},"Samples/AssetLib/binary.dat");
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath("Samples/AssetLib/binary.dat");
			for(int ii=0;ii<t_binary.Length;ii++){
				UnityEngine.Debug.Log(t_binary[ii].ToString("X2"));
			}
		}

		/** アセットのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadAllAssetsFromAssetsPath")]
		private static void MenuItem_LoadAllAssetsFromAssetsPath()
		{
			//プレハブのセーブ。
			{
				BlueBack.AssetLib.Result<UnityEngine.GameObject> t_prefab = BlueBack.AssetLib.Editor.SavePrefab.CreatePrefabToAssetsPath("Samples/AssetLib/ab.prefab");
				if(t_prefab.value != null){
					t_prefab.value.AddComponent<A_MonoBehaviour>().value = 11;
					t_prefab.value.AddComponent<B_MonoBehaviour>().value = 22;
				}
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			//全部。
			{
				UnityEngine.Object[] t_list = BlueBack.AssetLib.Editor.LoadAsset.LoadAllAssetsFromAssetsPath("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Length.ToString());
				for(int ii=0;ii<t_list.Length;ii++){
					UnityEngine.Debug.Log("LoadAllAssetsFromAssetsPath : " + t_list[ii].GetType().Name);
				}
			}

			//指定型。
			{
				System.Collections.Generic.List<UnityEngine.MonoBehaviour> t_list = BlueBack.AssetLib.Editor.LoadAsset.LoadAllSpecifiedAssetsFromAssetsPath<UnityEngine.MonoBehaviour>("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Count.ToString());
				for(int ii=0;ii<t_list.Count;ii++){
					int  t_value = 0;

					A_MonoBehaviour t_a = t_list[ii] as A_MonoBehaviour;
					if(t_a != null){
						t_value = t_a.value;
					}

					B_MonoBehaviour t_b = t_list[ii] as B_MonoBehaviour;
					if(t_b != null){
						t_value = t_b.value;
					}

					UnityEngine.Debug.Log("LoadAllSpecifiedAssetsFromAssetsPath : " + t_list[ii].GetType().Name + " : value = " + t_value.ToString());
				}
			}
		}

		/** アニメーションクリップのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsAnimationClipToAssetsPath")]
		private static void MenuItem_SaveAsAnimationClipToAssetsPath()
		{
			UnityEngine.AnimationClip t_animationclip = new UnityEngine.AnimationClip();
			t_animationclip.wrapMode = UnityEngine.WrapMode.Loop;

			BlueBack.AssetLib.Editor.SaveAnimationClip.SaveAsAnimationClipToAssetsPath(t_animationclip,"Samples/AssetLib/anim.anim","xxx");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveMeshToAssetsPath")]
		private static void MenuItem_SaveMeshToAssetsPath()
		{
			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			t_mesh.vertices = new UnityEngine.Vector3[]{new UnityEngine.Vector3(0,0,0),new UnityEngine.Vector3(1,0,0),new UnityEngine.Vector3(0,1,0)};
			t_mesh.triangles = new int[]{0,1,2};

			BlueBack.AssetLib.Editor.SaveMesh.SaveAsMeshToAssetsPath(t_mesh,"Samples/AssetLib/mesh.mesh");
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsMeshToAssetsPath")]
		private static void MenuItem_SaveAsMeshToAssetsPath()
		{
			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			t_mesh.vertices = new UnityEngine.Vector3[]{new UnityEngine.Vector3(0,0,0),new UnityEngine.Vector3(1,0,0),new UnityEngine.Vector3(0,1,0)};
			t_mesh.triangles = new int[]{0,1,2};

			BlueBack.AssetLib.Editor.SaveMesh.SaveAsMeshToAssetsPath(t_mesh,"Samples/AssetLib/mesh.mesh");
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsStlMeshToAssetsPath")]
		private static void MenuItem_CreateStl()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFile.FindFileFistFromAssetsPath("Samples/AssetLib",".*","^cylinder\\.mesh$");
			UnityEngine.Mesh t_mesh = BlueBack.AssetLib.Editor.LoadMesh.LoadMeshFromAssetsPath(t_path);
			BlueBack.AssetLib.Editor.SaveMesh.SaveAsStlMeshToAssetsPath(t_mesh,"Samples/AssetLib/cylinder.stl",new UnityEngine.Vector3(100.0f,100.0f,100.0f));
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** ＰＮＧのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsPngTexture2DToAssetsPath")]
		private static void MenuItem_CreatePng()
		{
			UnityEngine.Texture2D t_texture = new UnityEngine.Texture2D(16,16);
			for(int xx=0;xx<t_texture.width;xx++){
				for(int yy=0;yy<t_texture.height;yy++){
					t_texture.SetPixel(xx,yy,new UnityEngine.Color(1.0f,0.0f,0.0f,1.0f));
				}
			}
			BlueBack.AssetLib.Editor.SaveTexture.SaveAsPngTexture2DToAssetsPath(t_texture,"Samples/AssetLib/red.png");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}


		/** ダウンロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/Download")]
		private static void MenuItem_Download()
		{
			byte[] t_data = BlueBack.AssetLib.Editor.LoadBinary.TryLoadBinaryFromUrl("https://raw.githubusercontent.com/bluebackblue/AssetLib/main/unity_AssetLib/Assets/UPM/package.json",null);
			string t_text = BlueBack.AssetLib.EncodeCheck.GetEncoding(t_data).encoding.GetString(t_data);

			UnityEngine.Debug.Log(t_text);
		}
	}
	#endif
}

