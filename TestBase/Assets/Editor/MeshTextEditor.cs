using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MeshText))]
[ExecuteInEditMode]
[CanEditMultipleObjects]
public class MeshTextEditor : Editor
{
    MeshText meshtext;
    public override void OnInspectorGUI()
    {
        //meshtext = target as MeshText;
        //string text = EditorGUILayout.TextField("Text", meshtext.Text);
        //if (meshtext.Text != text)
        //{
        //    meshtext.Text = text;
        //}
        base.DrawDefaultInspector();
    }
}