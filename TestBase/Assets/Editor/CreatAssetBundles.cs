using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    //需要打包的路径
    private static string assetPath = "AllAssets";
    //导出包路径
    private static string AssetBundleOutPsth = "Assets/StreamingAssets";
    //保存需要打包的资源路径
    private static List<string> assetPathList = new List<string>();
    //需要打包的资源后缀
    private static Dictionary<string, string> asExtensionDic = new Dictionary<string, string>();

    //遍历制定文件夹获取需要打包的资源路径
    private static void GetDirs(string dirPath)
    {
        foreach (string path in Directory.GetFiles(dirPath))
        {
            // 通过资源后缀判断资源是否为需要打包的资源
            if (asExtensionDic.ContainsKey(System.IO.Path.GetExtension(path)))
            {
                string pathReplace = "";

                // Windows 平台分隔符为 '/', OS 平台 路径分隔符为 '\'， 此处是一个大坑
                if (Application.platform == RuntimePlatform.WindowsEditor)
                {
                    pathReplace = path.Replace('\\', '/');
                }

                //将需要打包的资源路径添加到打包路劲中
                assetPathList.Add(pathReplace);
            }
        }

        if (Directory.GetDirectories(dirPath).Length > 0)  //遍历所有文件夹
        {
            foreach (string path in Directory.GetDirectories(dirPath))
            {
                //使用递归方法遍历所有文件夹
                GetDirs(path);
            }
        }
    }

    //添加需要打包资源的后缀
    private static void SetASExtensionDic()
    {
        asExtensionDic.Clear();

        asExtensionDic.Add(".prefab", ".unity3d");
        asExtensionDic.Add(".mat", ".unity3d");
        asExtensionDic.Add(".png", ".unity3d");
    }

    //清除已经打包的资源 AssetBundleNames
    private static void ClearAssetBundlesName()
    {
        int length = AssetDatabase.GetAllAssetBundleNames().Length;
        Debug.Log(length);
        string[] oldAssetBundleNames = new string[length];
        for (int i = 0; i < length; i++)
        {
            oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
        }

        for (int j = 0; j < oldAssetBundleNames.Length; j++)
        {
            AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[j], true);
        }
    }

   //根据切换的平台返回相应的导出路径
    public class Plathform
    {
        public static string GetPlatformFolder(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:   //Android平台导出到 Android文件夹中
                    return "Android";
                case BuildTarget.iOS:
                    return "IOS";
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "Windows";
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                case BuildTarget.StandaloneOSXUniversal:
                    return "OSX";
                default:
                    return null;
            }
        }

    }
    [MenuItem("Custom/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        //BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/assetbundles");
        string path =  Application.streamingAssetsPath + "/assetbundles/";
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        //刷新编辑器  
        AssetDatabase.Refresh();
        //Debug.Log("AssetBundle打包完毕");

    }
}