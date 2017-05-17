using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

//自定义Tset脚本
[CustomEditor(typeof(Test))]
//在编辑模式下执行脚本，这里用处不大可以删除。
[ExecuteInEditMode]
[CanEditMultipleObjects]
//请继承Editor
public class TestEditor : Editor
{

    //[MenuItem("Custom/TestEditor")]
    //static void AddWindow()
    //{
    //    Rect wr = new Rect(0, 0, 500, 500);
    //    TestEditor window = (TestEditor)EditorWindow.GetWindowWithRect(typeof(TestEditor), wr, true, "widow name");
    //    window.Show();
    //}
    //在这里方法中就可以绘制面板。
    public override void OnInspectorGUI()
    {
        //得到Test对象
        Test test = (Test)target;
        //绘制一个窗口
        test.mRectValue = EditorGUILayout.RectField("窗口坐标",
                test.mRectValue);
        //绘制一个贴图槽
        test.texture = EditorGUILayout.ObjectField("增加一个贴图", test.texture, typeof(Texture), true) as Texture;

    }
}