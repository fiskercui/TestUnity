/*
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -quit \
  -projectPath $PROJECT_PATH \
  -executeMethod CommandBuild.BuildAndroid
*/

// Assets/Editor/CommandBuile.cs
using UnityEngine;
using UnityEditor;

public class CommandBuild
{
    [MenuItem("Custom/Build Android QQ")]
    public static void BuildAndroid()
    {
        string[] levels = { "Assets/ArtUI.unity" };
        Debug.Log("xxx");
        BuildPipeline.BuildPlayer(levels, "Sample.apk", BuildTarget.Android, BuildOptions.None);
    }
}