using UnityEditor;

public class CreateAssetBundles 
{
   [MenuItem("Assets/Build AssetBundles")]
   private static void BuildAllAssetBundles()
   {
      BuildPipeline.BuildAssetBundles("Assets/AssetBundles/Windows", BuildAssetBundleOptions.None,
         BuildTarget.StandaloneWindows64);
      BuildPipeline.BuildAssetBundles("Assets/AssetBundles/Android", BuildAssetBundleOptions.None,
         BuildTarget.Android);
      BuildPipeline.BuildAssetBundles("Assets/AssetBundles/iOS", BuildAssetBundleOptions.None,
         BuildTarget.iOS);
   }
}
