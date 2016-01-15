using UnityEngine;
using System.Collections;

public class AchievementDialog : MonoBehaviour {

    private GameObject achievementDialogObject;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

	}

    //三种方法
    public void onClose()
    {
        achievementDialogObject = GameObject.Find("DaytaskCanvas(Clone)");
    }


    private void onRenderFalse()
    {

    }

    private void onActiveFalse()
    {
        //SetActiveRecursively(false);
        //achievementDialogObject.setA
    }

    private void onDestroy()
    {
        //De
    }

    
}
