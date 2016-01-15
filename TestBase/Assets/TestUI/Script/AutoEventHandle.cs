using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class AutoEventHandle : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("auto on point click");
        //throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {

        Button btn = gameObject.GetComponent<Button>();
        ExecuteEvents.Execute<IPointerClickHandler>(btn.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
