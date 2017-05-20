using UnityEngine;
using System.Collections;

public class ChangeMethodBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onChangeToQuaternion()
    {
        RotateSystem.RotateMethod = RotateSystem.eRotateMethod.eQuaternionRotateTowards;
    }

    public void onChangeToVec3()
    {
        RotateSystem.RotateMethod = RotateSystem.eRotateMethod.eVec3RotateTowards;
    }
}
