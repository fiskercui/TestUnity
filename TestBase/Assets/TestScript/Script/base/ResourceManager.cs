using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ResourceManager:  SysModule
{
    public static ResourceManager Instance { get { return SysModuleManager.Instance.GetSysModule<ResourceManager>(); } }
    public string GetLocalFileDirectory()
    {
#if UNITY_EDITOR
        return Path.Combine(Path.GetDirectoryName(Application.dataPath), GameDefines.assetBundleFolder);
#elif UNITY_IPHONE || UNITY_ANDROID
		return Path.Combine(Application.temporaryCachePath, GameDefines.assetBundleFolder);
#else
		return GameDefines.assetBundleFolder;
#endif
    }
    public string GetLocalFilePath(string file)
    {
        return System.IO.Path.Combine(GetLocalFileDirectory(), file);
    }

    public string GetLocalFileUrl(string file)
    {
        return "file://" + GetLocalFilePath(file);
    }

    public Object LoadAsset(string assetName, bool noCache)
    {
#if ENABLE_RESOURCE_MANAGER_METRICS
		totalLoadCount++;
#endif

        // Convert to lowercase name
        //assetName = KodGames.PathUtility.UnifyPath(assetName);

        // Check if Need load from cache
        //        if (ConfigDatabase.DefaultCfg.ClientManifest != null)
        //        {
        //            ClientManifest.FileInfo fileInfo = ConfigDatabase.DefaultCfg.ClientManifest.GetFileByName(assetName);
        //            if (fileInfo != null)
        //            {
        //#if ENABLE_RESOURCE_MANAGER_METRICS
        //				assetBundleLoadCount++;
        //#endif

        //                // Try to load from resource cache
        //                ResourceCache resCache = ResourceCache.Instance;
        //                if (resCache != null && resCache.Contains(assetName))
        //                {
        //                    return resCache.GetAsset(assetName);
        //                }

        //                // Load from asset bundle and add to resource cache				
        //                string abPath = GetLocalFilePath(fileInfo.fileName);
        //#if ENABLE_RESOURCE_MANAGER_LOG
        //				Debug.Log("[ResourceManager] Load asset from AB : " + abPath);
        //#endif

        //                AssetBundle ab = AssetBundle.LoadFromFile(abPath);
        //                if (ab == null)
        //                {
        //                    Debug.LogError("Load AB failed : " + abPath);
        //                    return null;
        //                }

        //                // Load object from AB
        //                Object obj = ab.mainAsset;
        //                ab.Unload(false);
        //                ab = null;

        //                // Add to resource cache
        //                if (resCache != null && noCache == false)
        //                {
        //                    resCache.AddAsset(assetName, obj);
        //                    return resCache.GetAsset(assetName);
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }


     
#if ENABLE_RESOURCE_MANAGER_METRICS
		resourceLoadCount++;
#endif

        // Load from resources folder
        return ResourcesWrapper.Load(assetName);
    }
    public Object LoadAsset(string assetName)
    {
        return LoadAsset(assetName, false);
    }

    public T LoadAsset<T>(string assetName, bool noCache) where T : Object
    {
        return LoadAsset(assetName, noCache) as T;
    }

    public T LoadAsset<T>(string assetName) where T : Object
    {
        return LoadAsset<T>(assetName, false);
    }

    public T InstantiateAsset<T>(string assetName) where T : Object
    {
        T t = LoadAsset<T>(assetName);
        if (t == null)
            return null;

        return Object.Instantiate(t) as T;
    }
}
