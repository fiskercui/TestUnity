using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        //MeshRenderer[] meshRenderer = GetComponentsInChildren<MeshRenderer>();  //获取自身和所有子物体中所有MeshRenderer组件
        //Material[] mats = new Material[meshRenderer.Length];                    //新建材质球数组

        //for (int i = 0; i < meshFilters.Length; i++)
        //{
        //    mats[i] = meshRenderer[i].sharedMaterial;                           //获取材质球列表

        //    combine[i].mesh = meshFilters[i].sharedMesh;
        //    combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        //    meshFilters[i].gameObject.SetActive(false);
        //}

        //transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, false);//为mesh.CombineMeshes添加一个 false 参数，表示并不是合并为一个网格，而是一个子网格列表
        //transform.GetComponent<MeshRenderer>().sharedMaterials = mats;          //为合并后的GameObject指定材质

        //transform.gameObject.SetActive(true);


        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        Material[] mats = new Material[meshFilters.Length];
        Matrix4x4 matrix = transform.worldToLocalMatrix;
        for (int i = 0; i < meshFilters.Length; i++)
        {
            MeshFilter mf = meshFilters[i];
            MeshRenderer mr = meshFilters[i].GetComponent<MeshRenderer>();
            if (mr == null)
            {
                continue;
            }
            combine[i].mesh = mf.sharedMesh;
            combine[i].transform = mf.transform.localToWorldMatrix * matrix;
            mr.enabled = false;
            mats[i] = mr.sharedMaterial;
        }
        gameObject.AddComponent<MeshFilter>();
        MeshFilter thisMeshFilter = GetComponent<MeshFilter>();
        //MeshFilter thisMeshFilter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "Combined";
        thisMeshFilter.mesh = mesh;
        mesh.CombineMeshes(combine, false);
        MeshRenderer thisMeshRenderer = GetComponent<MeshRenderer>();
        thisMeshRenderer.sharedMaterials = mats;
        thisMeshRenderer.enabled = true;

        MeshCollider thisMeshCollider = GetComponent<MeshCollider>();
        if (thisMeshCollider != null)
        {
            thisMeshCollider.sharedMesh = mesh;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
