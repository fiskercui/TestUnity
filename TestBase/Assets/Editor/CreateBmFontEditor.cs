using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;




[CustomEditor(typeof(MyFont))]
[ExecuteInEditMode]
[CanEditMultipleObjects]
public class CreateBmFontEditor: Editor
{

    public override void OnInspectorGUI()
    {
        bool showBtn = false;
        showBtn = EditorGUILayout.Toggle("Show Button", showBtn);
        if (showBtn)
        {
            if (GUILayout.Button("Close"))
            {
                Debug.Log("Close");
            }
        }
    }
}