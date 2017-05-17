using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GetAssetBundleNames
{
    public static readonly string PathURL =
#if UNITY_ANDROID
        "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
        Application.dataPath + "/Raw/";    
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        "file://" + Application.dataPath + "/StreamingAssets/";    
#else
        string.Empty;    
#endif

    [MenuItem("Custom/Get AssetBundle names")]
    static void GetNames()
    {
        //string mainPath = "file://" + Application.streamingAssetsPath + "/AssetBundle/" + "AssetBundle";

        //var names = AssetDatabase.GetAllAssetBundleNames();
        //foreach (var name in names)
        //{
        //    Debug.Log("AssetBundle: " + name);
        //    AssetDatabase.GetDependencies(name);
        //    //WWW.assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //    //string[] fullnames = AssetDatabase.GetDirectDependencies(fullname);
        //    //string[] fullnames = AssetBundle.GetAllDependencies(fullname);
        //}
    }


    //IEnumerator loadScene(string sceneName)
    //{
    //    string mainPath = Application.streamingAssetsPath + "/assetbundles/";
    //    WWW www1 = new WWW(mainPath);
    //    yield return www1;
    //    if (www1.error == null)
    //    {
    //        AssetBundle mainAB = www1.assetBundle;
    //        AssetBundleManifest abm = (AssetBundleManifest)mainAB.LoadAsset("AssetBundleManifest");
    //        mainAB.Unload(false);
    //        if (abm == null)
    //        {
    //            Debug.Log("abm is null");
    //            yield return null;
    //        }
    //        else
    //        {
    //            string[] depNames = abm.GetAllDependencies("a.assetbundle");
    //            Debug.Log("depNames length = " + depNames.Length.ToString());
    //        }
    //    }
    //}
}