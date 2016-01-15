using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GetAssetBundleNames
{
    [MenuItem("Custom/Get AssetBundle names")]
    static void GetNames()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
            Debug.Log("AssetBundle: " + name);
    }
}