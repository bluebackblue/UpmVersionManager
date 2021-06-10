

/** Samples.AssetLib.CreatePackage.Editor
*/
namespace Samples.AssetLib.CreatePackage.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** パッケージ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/CreatePackage/CreatePackageFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_CreatePackage_CreatePackageFromAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreatePackage.CreatePackageFromAssetsPath("Samples/AssetLib","sample.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
		}
	}
	#endif
}

