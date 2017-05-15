using UnityEngine;
using System.Collections;
using System;

public class TestCoroutine : MonoBehaviour {

    IEnumerator MyCoroutine()
    {
        //This is a coroutine  
        yield return "123";
    }

    public int testCase1 = 0;
    IEnumerator DelayCoroutine()
    {
        // work before 
        yield return new WaitForSeconds(2);
        Debug.Log("WaitAndPrint 1:" + Time.time);
        // work after 
        yield return new WaitForSeconds(5);
        Debug.Log("WaitAndPrint 2:" + Time.time);


        Debug.Log("----");

    }



    class AssetBundleLoadOperation : IEnumerator
    {
        public object Current
        {
            get
            {
                return null;
            }
        }
        public bool MoveNext()
        {
            return !IsDone();
        }

        public void Reset()
        {
        }

        public bool Update()
        {
            Debug.Log("update");
            return true;
        }

        public bool IsDone()
        {
            Debug.Log("IsDone" + Time.time);
            //yield new WaitForSeconds(2);
            //Debug.Log("IsDone end" + Time.time);
            return false;
        }
    }



    // Use this for initialization
    IEnumerator Start () {
        Debug.Log("heheheh start");
        if (testCase1 == 0)
        {
            Debug.Log("test cast 0 start：" + Time.time);
            StartCoroutine(DelayCoroutine());
            Debug.Log("test cast 0 end：" + Time.time);
            //StartCoroutine(DelayCoroutine());
            //Debug.Log("test cast 0 end2：" + Time.time);
        }
        else if (testCase1 == 1)
        {
            Debug.Log("test case 1 start" + Time.time);
            yield return StartCoroutine(DelayCoroutine());
            Debug.Log("test cast 1 end：" + Time.time);
        }

        else if (testCase1 == 2)
        {
            StartCoroutine(new AssetBundleLoadOperation());
            Debug.Log("test cast 2 end：" + Time.time);

        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
