using UnityEngine;
using System.Collections;

public class MainCanvas : MonoBehaviour {
    private GameObject dayTaskCanvas;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void onShowAchieve()
    {
        Debug.Log("on Achieve");
        GameObject prefab = Resources.Load("Prefab/DaytaskCanvas") as GameObject;
        dayTaskCanvas = Instantiate(prefab) as GameObject;
        dayTaskCanvas.SetActive(true);
 

        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

    }
}
