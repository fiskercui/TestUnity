using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Mesh Layer bit mask
//walkable 0
//not walkable 1
// jump 2
// red 3
//blue 4


public class NavmeshController : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent agent;


    private int redMask = 1 << 3;
    private int blueMask = 1 << 4;

    public bool setAgentWalkMask;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();		
	}

    // Update is called once per frame
    void Update()
    {
        //鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            //摄像机到点击位置的的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //判断点击的是否地形
                if (!hit.collider.tag.Equals("Plane"))
                {
                    return;
                }
                //点击位置坐标
                Vector3 point = hit.point;
                //转向
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
                //设置寻路的目标点
                agent.SetDestination(point);
            }
        }
    }


    void OnGUI()
    {
        if (!setAgentWalkMask)
        {
            return;
        }
        if (GUI.Button(new Rect(0, 0, 100, 50), "走上层"))
        {
            Debug.Log("走上层");
            agent.areaMask = redMask + 1;
        }

        if (GUI.Button(new Rect(0, 100, 100, 50), "走下层"))
        {
            Debug.Log("走下层");
            agent.areaMask = blueMask + 1;
        }
    }
}
