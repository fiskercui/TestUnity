
using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

/// <summary>
/// 自定义的编辑器窗口
/// </summary>
public class AutoSaveWindow : EditorWindow
{

    private bool autoSaveScene = false;
    private bool showMessage = true;
    private bool isStarted = false;
    private int intervalScene;
    private DateTime lastSaveTimeScene = DateTime.Now;

    private string projectPath = "";
    private string scenePath;


    ////[MenuItem("Window/AutoSave")]
    //[MenuItem("Window/TestEditWindow")]
    //public static void ShowWindow()
    //{
    //    // 显示某个编辑器窗口。传参即是要显示的窗口类型（类名）
    //    EditorWindow.GetWindow(typeof(TestEditWindow));
    //}
    [MenuItem("Window/AutoSaveWindow")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        AutoSaveWindow window = (AutoSaveWindow)EditorWindow.GetWindowWithRect(typeof(AutoSaveWindow), wr, true, "autoSaveWindow");
        window.Show();

    }


    void OnGUI()
    {
        projectPath = Application.dataPath;

        GUILayout.Label("Info:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Saving to:", "" + projectPath);
        EditorGUILayout.LabelField("Saving scene:", "" + scenePath);
        GUILayout.Label("Options:", EditorStyles.boldLabel);
        autoSaveScene = EditorGUILayout.BeginToggleGroup("Auto save", autoSaveScene);
        intervalScene = EditorGUILayout.IntSlider("Interval (minutes)", intervalScene, 1, 10);
        if (isStarted)
        {
            EditorGUILayout.LabelField("Last save:", "" + lastSaveTimeScene);
        }
        EditorGUILayout.EndToggleGroup();
        showMessage = EditorGUILayout.BeginToggleGroup("Show Message", showMessage);
        EditorGUILayout.EndToggleGroup();
    }


    void Update()
    {
        scenePath = EditorApplication.currentScene;
        if (autoSaveScene)
        {
            if (DateTime.Now.Minute >= (lastSaveTimeScene.Minute + intervalScene) || DateTime.Now.Minute == 59 && DateTime.Now.Second == 59)
            {
                saveScene();
            }
        }
        else
        {
            isStarted = false;
        }

    }

    void saveScene()
    {
        EditorApplication.SaveScene(scenePath);
        lastSaveTimeScene = DateTime.Now;
        isStarted = true;
        if (showMessage)
        {
            Debug.Log("AutoSave saved: " + scenePath + " on " + lastSaveTimeScene);
        }
        AutoSave repaintSaveWindow = (AutoSave)EditorWindow.GetWindow(typeof(AutoSave));
        repaintSaveWindow.Repaint();
    }
}