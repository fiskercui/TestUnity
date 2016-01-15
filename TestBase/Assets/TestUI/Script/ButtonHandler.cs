using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();

        //可以添加多个点击
        btn.onClick.AddListener(click);

        btn.onClick.AddListener(
            delegate ()
            {
                for (int i = 0; i < 10; i++)
                {
                    Debug.Log("index" + i);
                }
            });
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void click()
    {
        Debug.Log("button click");
    }
}
