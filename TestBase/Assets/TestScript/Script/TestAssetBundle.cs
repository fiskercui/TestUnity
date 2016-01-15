using UnityEngine;
using System.Collections;

public class TestAssetBundle : MonoBehaviour {
    //不同平台下StreamingAssets的路径是不同的，这里需要注意一下。
    public static readonly string PathURL =
#if UNITY_ANDROID
		    "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
		    Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        "file://" + Application.dataPath + "/StreamingAssets/assetbundles/";
#else
            string.Empty;
#endif

    // Use this for initialization
    void Start()
    {

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
            Debug.Log(PathURL);
        }

    }

    //读取一个资源

    private IEnumerator LoadMainGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        //加载到游戏中
        yield return Instantiate(bundle.assetBundle.mainAsset);

        bundle.assetBundle.Unload(false);
    }

    //读取全部资源

    private IEnumerator LoadALLGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        //通过Prefab的名称把他们都读取出来
        Object obj0 = bundle.assetBundle.LoadAsset("Prefab0");
        Object obj1 = bundle.assetBundle.LoadAsset("Prefab1");

        //加载到游戏中	
        yield return Instantiate(obj0);
        yield return Instantiate(obj1);
        bundle.assetBundle.Unload(false);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
