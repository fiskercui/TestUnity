using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TestHandler : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick " + eventData);
    }

    public void OnClick()
    {
        Debug.Log("hehehe");
       
    }

    public void OnClickImage()
    {
        Debug.Log("OnClickImage");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
