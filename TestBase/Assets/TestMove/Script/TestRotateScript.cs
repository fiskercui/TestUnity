using UnityEngine;
using System.Collections;

public class TestRotateScript : MonoBehaviour {
    public GameObject TargetObject;
    private Vector3 direction;



	// Use this for initialization
	void Start () {
      }


    public void onChangeVec3()
    {

    }

    public void onChangeRotate()
    {

    }
	// Update is called once per frame
	void Update () {

        //方法1
        //if (TargetObject != null)
        //{
        //    direction = TargetObject.transform.position - transform.position;
        //    //this.transform.Rotate(0, 0, 90);
        //    //Debug.Log("Direction " + direction);
        //    //Debug.Log(this.transform.rotation);

        //    Quaternion TargetRotation = Quaternion.LookRotation(direction, Vector3.forward);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * 2.5f);
        //}
        ////方法2
        {

            //Vector3 currentPosition = this.transform.position;
            //Quaternion currentRoattion = this.transform.rotation;
            //Vector3 direction = (TargetObject.transform.position - currentPosition).normalized;
            //Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            //Debug.Log(currentRoattion);
            //Debug.Log(targetRotation);
            //this.transform.rotation = Quaternion.RotateTowards(currentRoattion, targetRotation, 45 * Time.deltaTime);
        }

        if (RotateSystem.RotateMethod == RotateSystem.eRotateMethod.eVec3RotateTowards)
        {

            Vector3 currentPosition = this.transform.position;
            float speed = 1.0f;
            float step = speed * Time.deltaTime;
            Debug.Log("currentPosition:" + currentPosition + "target position:" + TargetObject.transform.position);
            this.transform.position = Vector3.RotateTowards(currentPosition, TargetObject.transform.position, step, 20);
        }
        else if (RotateSystem.RotateMethod == RotateSystem.eRotateMethod.eQuaternionRotateTowards)
        {

            //LookRotation
            //在xoz平面上有效
            //Vector3 currentPosition = this.transform.position;
            //Quaternion currentRoattion = this.transform.rotation;
            //Vector3 direction = (TargetObject.transform.position - currentPosition).normalized;
            //Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            //Debug.Log(currentRoattion);
            //Debug.Log(targetRotation);
            //this.transform.rotation = Quaternion.RotateTowards(currentRoattion, targetRotation, 45 * Time.deltaTime);


            if (TargetObject != null)
            {
                direction = TargetObject.transform.position - transform.position;
                //this.transform.Rotate(0, 0, 90);
                //Debug.Log("Direction " + direction);
                //Debug.Log(this.transform.rotation);

                Quaternion TargetRotation = Quaternion.LookRotation(direction, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * 2.5f);
            }
        }

    }
}
