using UnityEngine;
using System.Collections;
using System;

class TestAsset : MonoBehaviour
{

    //IEnumerator Start()
    //{
    //    Caching.CleanCache();
    //    Debug.Log("onStart");
    //    WWW www = WWW.LoadFromCacheOrDownload("http://10.10.2.28:81/F%3A/httptest/Windows/Windows", 0);

    //    yield return www;

    //    if (!string.IsNullOrEmpty(www.error))
    //    {
    //        Debug.LogError(www.error);
    //        yield return null;
    //    }
    //    else {
    //        if (www.isDone)
    //        {
    //            Debug.Log("Android 已经下载完成");
    //        }

    //        AssetBundle mab = www.assetBundle;

    //        if (mab == null)
    //        {
    //            Debug.LogError("mab null");
    //        }

    //        AssetBundleManifest test1 = mab.LoadAsset("AssetBundleManifest") as AssetBundleManifest;

    //        WWW wwwmonster = WWW.LoadFromCacheOrDownload("http://10.10.2.28:81/F%3A/httptest/Windows/monsters", test1.GetAssetBundleHash("monsters"), 0);

    //        yield return wwwmonster;

    //        if (!string.IsNullOrEmpty(wwwmonster.error))
    //        {
    //            Debug.LogError(wwwmonster.error);
    //            yield return null;
    //        }


    //        else {

    //            while (!wwwmonster.isDone)
    //            {
    //                yield return new WaitForEndOfFrame();
    //            }
    //            if (wwwmonster.isDone)
    //            {
    //                Debug.Log("monsters 已经下载完成");
    //            }
    //            //AssetBundleLoadAssetOperation request = AssetBundleManager.LoadAssetAsync("bgm/orchestra12", "bgm_maoudamashii_orchestra12", typeof(AudioClip));

    //            AssetBundleRequest request27Sprite = wwwmonster.assetBundle.LoadAssetAsync("asad", typeof(Material));
    //            if (request27Sprite == null)
    //            {
    //                yield break;

    //            }
    //            while (!request27Sprite.isDone)
    //            {
    //                yield return new WaitForEndOfFrame();
    //            }
    //            if (request27Sprite.isDone)
    //            {
    //                Debug.Log("request27Sprite isDone ok");


    //                AssetBundleRequest requestCube = wwwmonster.assetBundle.LoadAssetAsync("cube2", typeof(GameObject));
    //                if (requestCube == null)
    //                {
    //                    yield break;
    //                }

    //                while (!requestCube.isDone)
    //                {
    //                    yield return new WaitForEndOfFrame();
    //                }

    //                GameObject prefab = requestCube.asset as GameObject;

    //                if (prefab != null)
    //                    GameObject.Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);

    //            }


    //            GameObject object2 = new GameObject();

    //            int abc = 123;
    //            abc += 456;

    //        }

    //    }

    //}
    void Start()
    {
        StartCoroutine(StartCon());
    }

    IEnumerator StartCon()
    {
        Caching.CleanCache();
        Debug.Log("onStart StartCon");
        WWW www = WWW.LoadFromCacheOrDownload("http://10.10.2.28:81/F%3A/httptest/Windows/prefab", 0);

        if (!www.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield return null;
        }
        WWW www1 = WWW.LoadFromCacheOrDownload("http://10.10.2.28:81/F%3A/httptest/Windows/monsters", 0);

        if (!www1.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (!string.IsNullOrEmpty(www1.error))
        {
            Debug.LogError(www1.error);
            yield return null;
        }
        Debug.Log("hehehehe");
        AssetBundle assetBunder = www1.assetBundle;

        //UnityEngine.Object prefab = assetBunder.LoadAsset("Assets/AssetBundleBuilder/Sample/Sprites/cube2");

        //if (prefab != null)
        //{
        //    GameObject.Instantiate(prefab);
        //}

        UnityEngine.Object prefab1 = assetBunder.LoadAsset("cube2");

        if (prefab1 != null)
        {
            GameObject.Instantiate(prefab1);
        }

    }

}
