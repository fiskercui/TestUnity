using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class ManualEventSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {


        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        trigger.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback = new EventTrigger.TriggerEvent();

        UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(OnScriptControll);

        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);

    }

    // Update is called once per frame
    void Update () {
	
	}


    public void OnScriptControll(BaseEventData arg0)
    {
        Debug.Log("Manual Event System OnScriptControll");
    }


}
