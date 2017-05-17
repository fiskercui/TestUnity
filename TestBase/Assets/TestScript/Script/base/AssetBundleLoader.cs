using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader:MonoBehaviour
{
    private AssetBundleManifest mainAb;
    public void loadAssetBundle(string assetName)
    {

    }

    private static  AssetBundleLoader m_instance;
    public static AssetBundleLoader getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new AssetBundleLoader();
        }
        return m_instance;
    }
   
    public  void startMainAssetBundle(string mainAssetName)
    {
        StartCoroutine(loadMainAssetBundle(mainAssetName));
    }

    private  IEnumerator loadMainAssetBundle(string mainAssetName)
    {
        WWW bundle = new WWW(mainAssetName);
        yield return bundle;
        Debug.Log(bundle.error);

        if (bundle.error == null)
        {
            AssetBundle ab = bundle.assetBundle;
            //总的才有效果
            mainAb = (AssetBundleManifest)ab.LoadAsset("AssetBundleManifest");
            ab.Unload(false);
            if (mainAb == null)
            {
                Debug.Log("main asset bundle  is null");
                yield return null;
            }
            else
            {
                string[] depNames = mainAb.GetAllDependencies("pre_battleobj");
                Debug.Log("depNames length = " + depNames.Length.ToString());
            }
        }
    }

    void Update()
    {
        //Debug.Log("update");
    }
}
