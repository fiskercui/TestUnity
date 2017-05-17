
using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 自定义的编辑器窗口
/// </summary>
public class TestEditWindow : EditorWindow
{

    string myString = "Hello World !"; // 文本内容
    bool groupEnabled;     // 选项组是否可用
    bool myBool = true;    // 复选框状态
    float myFloat = 2.33f; // 滑动条的值

    ////[MenuItem("Window/AutoSave")]
    //[MenuItem("Window/TestEditWindow")]
    //public static void ShowWindow()
    //{
    //    // 显示某个编辑器窗口。传参即是要显示的窗口类型（类名）
    //    EditorWindow.GetWindow(typeof(TestEditWindow));
    //}
    [MenuItem("Window/TestEditWindow")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        TestEditWindow window = (TestEditWindow)EditorWindow.GetWindowWithRect(typeof(TestEditWindow), wr, true, "widow name");
        window.Show();

    }


    void OnGUI()
    {
        // 文本
        GUILayout.Label("Base Setting");
        // 可以编辑，编辑后用同一个变量保存结果
        myString = EditorGUILayout.TextField("这是文本", myString);

        // 开启一组选项
        groupEnabled = EditorGUILayout.BeginToggleGroup("Options setting", groupEnabled);
        // 复选框
        myBool = EditorGUILayout.Toggle("这是复选框", myBool);
        // 滑动条
        EditorGUILayout.Slider("这是滑动条", myFloat, 0, 5);
        // 结束这组选项
        EditorGUILayout.EndToggleGroup();
    }
}