using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour {

    public GameObject objPrefab;
    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 1000; i++)
        {
            int zIndex = i / 100;
            int iIndex = i % 100;
            GameObject obj = Instantiate(objPrefab, transform);
            obj.transform.localPosition = new Vector3(iIndex * 0.5f - 100 * 0.5f * 0.5f, 0, -zIndex * 1);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
