using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "testJson"))
        {

        }

        if (GUI.Button(new Rect(0, 50, 100, 50), "testProtobuf"))
        {

        }
    }
}
