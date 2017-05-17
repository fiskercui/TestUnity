using UnityEngine;
using System.Collections;

/// <summary>
/// 1. 有几个注意。 如果是assetbundle 有依赖。一定要
/// </summary>
public class TestAssetBundle : MonoBehaviour {
    //不同平台下StreamingAssets的路径是不同的，这里需要注意一下。
    public static string PathURL = "";

    public void initPathUrl()
    {
        PathURL = 
#if UNITY_ANDROID
        // comment by weihua.cui 20170515
        // get data path 
        //"jar:file://" + Application.dataPath + "!/assets/";
        "";
#elif UNITY_IPHONE
		    Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        "file://" + Application.dataPath + "/StreamingAssets/assetbundles/";
#else
            string.Empty;
#endif
    }
    // Use this for initialization
    void Start()
    {
        initPathUrl();
    }

    void OnGUI()
    { 
        if (GUILayout.Button("Main Assetbundle"))
        {
            StartCoroutine(LoadMainGameObject(PathURL + "mainui"));
            Debug.Log(PathURL);
        }
        if (GUILayout.Button("ALL Assetbundle"))
        {
            StartCoroutine(LoadALLGameObject(PathURL + "assetbundles"));
            //AssetBundleLoader.getInstance().startMainAssetBundle(PathURL + "assetbundles");
            //startMainAssetBundle(PathURL + "assetbundles");
            Debug.Log(PathURL);
        }
        if (GUILayout.Button("Prefab Assetbundle"))
        {
            StartCoroutine(LoadPrefabAssetBundle(PathURL + "pre_battle_sphere"));

            Debug.Log(PathURL);
        }

        if (GUILayout.Button("Prefab Assetbundle Depencies"))
        {
            StartCoroutine(LoadPrefabAssetBundleDepencies(PathURL + "pre_battleobj"));
            Debug.Log(PathURL);
        }

        if (GUILayout.Button("Test AssetBundleManager"))
        {
            StartCoroutine(testAssetBundleManager(PathURL + "assetbundles"));
            Debug.Log(PathURL);
        }
    }

    private IEnumerator LoadPrefabAssetBundle(string path)
    {
        WWW bundle = new WWW(path);
        yield return bundle;
        if (bundle.error == null)
        {
            AssetBundle mainAB = bundle.assetBundle;
            //AssetBundleManifest abm = (AssetBundleManifest)mainAB.LoadAsset("Assets/TestScript/Prefab/battleObj.prefab");
            GameObject abm = mainAB.LoadAsset("Assets/TestScript/Prefab/battle_sphere.prefab") as GameObject;
            mainAB.Unload(false);
            if (abm == null)
            {
                Debug.Log("abm is null");
                yield return null;
            }
        }
    }

    private IEnumerator LoadMainGameObject(string path)
    {
        WWW bundle = new WWW(path);
        yield return bundle;
        //StartCoroutine(loadResouce(bundle));
        if (bundle.error == null)
        {
            AssetBundle mainAB = bundle.assetBundle;
            Object abm = mainAB.LoadAsset("Assets/TestUI/MainUI/Sprite/chat_btnEmoji.png") as Object;

            mainAB.Unload(false);
            if (abm == null)
            {
                Debug.Log("abm is null");
                yield return null;
            }
        }
        else
        {
            Debug.Log(bundle.error);
        }
        //加载到游戏中
    }

    //读取全部资源
    private IEnumerator LoadALLGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;
        Debug.Log(bundle.error);

        if (bundle.error == null)
        {
            AssetBundle mainAB = bundle.assetBundle;
            //总的才有效果
            AssetBundleManifest abm = (AssetBundleManifest)mainAB.LoadAsset("AssetBundleManifest");

            mainAB.Unload(false);
            if (abm == null)
            {
                Debug.Log("abm is null");
                yield return null;
            }
            else
            {
                string[] depNames = abm.GetAllDependencies("pre_battleobj");
                Debug.Log("depNames length = " + depNames.Length.ToString());
            }
        }
        ////通过Prefab的名称把他们都读取出来
        //Object obj0 = bundle.assetBundle.LoadAsset("Prefab0");
        //Object obj1 = bundle.assetBundle.LoadAsset("Prefab1");

        ////加载到游戏中	
        //yield return Instantiate(obj0);
        //yield return Instantiate(obj1);
        //bundle.assetBundle.Unload(false);
    }


    private IEnumerator LoadPrefabAssetBundleDepencies(string path)
    {
        WWW bundle = new WWW(path);
        yield return bundle;
        if (bundle.error == null)
        {
            AssetBundle mainAB = bundle.assetBundle;
            //AssetBundleManifest abm = (AssetBundleManifest)mainAB.LoadAsset("Assets/TestScript/Prefab/battleObj.prefab");

            GameObject abm = mainAB.LoadAsset("Assets/TestScript/Prefab/battleObj.prefab") as GameObject;
            mainAB.Unload(false);
            if (abm == null)
            {
                Debug.Log("battleObj is null");
                yield return null;
            }
            GameObject obj = Instantiate(abm);

            //父子关系 如果没有设置就往全局方向
            obj.transform.parent = this.transform;
        }
    }
    public IEnumerator testAssetBundleManager(string path)
    {
        
        //AssetBundleManager.LoadAssetAsync(PathURL + "pre_battle_sphere", "battle_sphere.prefab", typeof(GameObject));
        WWW bundle = new WWW(path);

        yield return bundle;
        Debug.Log(bundle.error);

        if (bundle.error == null)
        {
            AssetBundle mainAB = bundle.assetBundle;
            //总的才有效果
            AssetBundleManifest abm = (AssetBundleManifest)mainAB.LoadAsset("AssetBundleManifest");

            mainAB.Unload(false);
            if (abm == null)
            {
                Debug.Log("abm is null");
                yield return null;
            }
            else
            {
                AssetBundleManager.AssetBundleManifestObject = abm;
                AssetBundleManager.LoadAssetAsync(PathURL + "pre_battle_sphere", "Assets/TestScript/Prefab/battle_sphere.prefab", typeof(GameObject));
            }
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
