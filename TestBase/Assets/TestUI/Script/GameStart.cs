using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class GameStart : MonoBehaviour {
    //private GameObject MainCanvas;
    // Use this for initialization
    IEnumerator Start () {
        //Debug.Log("on Achieve");
        //GameObject prefab = Resources.Load("Prefab/MainCanvas") as GameObject;
        //MainCanvas = Instantiate(prefab) as GameObject;
        //MainCanvas.SetActive(true);
        //Canvas vas = MainCanvas.GetComponent<Canvas>();
        //vas.renderMode = RenderMode.ScreenSpaceCamera;
        //vas.worldCamera = Camera.main;


        //onStart();


        Debug.Log("onStart");
        ////WWW www = WWW.LoadFromCacheOrDownload("http://127.0.0.1:81/F%3A/httptest/assetbundle.unitypackage", 0);
        WWW www = WWW.LoadFromCacheOrDownload("http://127.0.0.1:81/F%3A/httptest/Android/Android", 0);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield return null;
        }
        else {
            if (www.isDone)
            {
                Debug.Log("已经下载完成");
            }

            AssetBundle mab = www.assetBundle;

            if (mab == null)
            {
                Debug.LogError("mab null");
            }

            AssetBundleManifest  test1 = mab.LoadAsset("AssetBundleManifest") as AssetBundleManifest; 




            WWW www2 = WWW.LoadFromCacheOrDownload("http://127.0.0.1:81/F%3A/httptest/Android/bgm/orchestra12", test1.GetAssetBundleHash("bgm/orchestra12"),0);

            yield return www2;

            if (!string.IsNullOrEmpty(www2.error))
            {
                Debug.LogError(www2.error);
                yield return null;
            }
            else {
                if (www2.isDone)
                {
                    Debug.Log("已经下载完成");
                 }
                AssetBundleManifest test2 = www2.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;


                GameObject obj  = www2.assetBundle.LoadAsset("bgm_maoudamashii_orchestra12",typeof(UnityEngine.AudioClip)) as GameObject;

                int abc = 123;
                abc += 456;

            }

                //http://127.0.0.1:81/F%3A/httptest/Android/bgm/orchestra12
                //AssetBundleManifest mainfest = (AssetBundleManifest)mab.LoadAsset("ABs");

                //if (mainfest == null)
                //{
                //    Debug.LogError("mainfest init null");
                //}

                //int a = 1;
                //a = a + 1;
            }
        //var myLoadedAssetBundle = www.assetBundle
        //var asset = myLoadedAssetBundle.mainAsset
    }


    //IEnumerator onStart()
    //{


    //}



    // Update is called once per frame
    void Update () {



    }


}
