using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using UnityEngine.Profiling;

using LitJson;
using Newtonsoft.Json;
using FullSerializer;

[Serializable]
public class SaveGame
{
    public string Name;
    public int HighScore;
    public List<InventoryItem> Inventory;
}

[Serializable]
public class InventoryItem
{
    public int Id;
    public int Quantity;
}

class TestJsonCompare : MonoBehaviour
{
    string report = "";

    void Start()
    {
        var saveGame = new SaveGame
        {
            Name = "Speed Run",
            HighScore = 10000,
            Inventory = new List<InventoryItem> {
                    new InventoryItem {
                        Id = 100,
                        Quantity = 5
                    },
                    new InventoryItem {
                        Id = 200,
                        Quantity = 20
                    }
                }
        };

        // Warm up reflection
        JsonUtility.ToJson(saveGame);
        JsonMapper.ToJson(saveGame);
        JsonConvert.SerializeObject(saveGame);

        var fsSerializer = new fsSerializer();
        fsData fsData;
        fsSerializer.TrySerialize(saveGame, out fsData);
        fsJsonPrinter.CompressedJson(fsData);

        if (Profiler.enabled)
        {
            var tempSaveGame = new SaveGame();
            TestGarbage(saveGame, tempSaveGame, fsSerializer);
        }
        else
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            const int reps = 10000;
            string unityJson = null;
            string litJsonJson = null;
            string jsonDotNetJson = null;
            string fullSerializerJson = null;
            SaveGame unitySaveGame = null;
            SaveGame litJsonSaveGame = null;
            SaveGame jsonDotNetSaveGame = null;
            SaveGame fullSerializerSaveGame = null;

            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                unityJson = JsonUtility.ToJson(saveGame);
            }
            var unitySerializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                litJsonJson = JsonMapper.ToJson(saveGame);
            }
            var litJsonSerializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                jsonDotNetJson = JsonConvert.SerializeObject(saveGame);
            }
            var jsonDotNetSerializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                fsSerializer.TrySerialize(saveGame, out fsData);
                fullSerializerJson = fsJsonPrinter.CompressedJson(fsData);
            }
            var fullSerializerSerializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                unitySaveGame = JsonUtility.FromJson<SaveGame>(unityJson);
            }
            var unityDeserializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                litJsonSaveGame = JsonMapper.ToObject<SaveGame>(litJsonJson);
            }
            var litJsonDeserializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                jsonDotNetSaveGame = JsonConvert.DeserializeObject<SaveGame>(jsonDotNetJson);
            }
            var jsonDotNetDeserializeTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < reps; ++i)
            {
                fsData = fsJsonParser.Parse(fullSerializerJson);
                fsSerializer.TryDeserialize<SaveGame>(fsData, ref fullSerializerSaveGame);
            }
            var fullSerializerDeserializeTime = stopwatch.ElapsedMilliseconds;

            report += "Unity: " + unityJson + "\n";
            report += "LitJSON: " + litJsonJson + "\n";
            report += "Json.NET: " + jsonDotNetJson + "\n";
            report += "FullSerializer: " + fullSerializerJson + "\n";
            PrintSaveGame("Unity", unitySaveGame);
            PrintSaveGame("LitJSON", litJsonSaveGame);
            PrintSaveGame("Json.NET", jsonDotNetSaveGame);
            PrintSaveGame("FullSerializer", fullSerializerSaveGame);

            var unitySize = Encoding.UTF8.GetBytes(unityJson).Length;
            var litJsonSize = Encoding.UTF8.GetBytes(litJsonJson).Length;
            var jsonDotNetSize = Encoding.UTF8.GetBytes(jsonDotNetJson).Length;
            var fullSerializerSize = Encoding.UTF8.GetBytes(fullSerializerJson).Length;
            report += string.Format(
                "Library,Size,SerializeTime,Deserialize Time\n" +
                "Unity,{0},{1},{2}\n" +
                "LitJSON,{3},{4},{5}\n" +
                "Json.NET,{6},{7},{8}\n" +
                "FullSerializer,{9},{10},{11}\n",
                unitySize, unitySerializeTime, unityDeserializeTime,
                litJsonSize, litJsonSerializeTime, litJsonDeserializeTime,
                jsonDotNetSize, jsonDotNetSerializeTime, jsonDotNetDeserializeTime,
                fullSerializerSize, fullSerializerSerializeTime, fullSerializerDeserializeTime
            );
        }
    }

    void PrintSaveGame(string title, SaveGame saveGame)
    {
        var builder = new StringBuilder(title);
        builder.Append(":\n\tName=");
        builder.Append(saveGame.Name);
        builder.Append('\n');
        builder.Append("\tHighScore=");
        builder.Append(saveGame.HighScore);
        builder.Append("\n");
        builder.Append("\tInventory=\n");
        foreach (var item in saveGame.Inventory)
        {
            builder.Append("\t\t");
            builder.Append("Id=");
            builder.Append(item.Id);
            builder.Append(", Quantity=");
            builder.Append(item.Quantity);
            builder.Append('\n');
        }
        report += builder.ToString() + "\n";
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, Screen.width, Screen.height), report);
    }

    void TestGarbage(SaveGame saveGame, SaveGame tempSaveGame, fsSerializer fsSerializer)
    {
        var json = TestUnitySerialize(saveGame);
        TestUnityDeserialize(json);

        json = TestLitJsonSerialize(saveGame);
        TestLitJsonDeserialize(json);

        json = TestJsonDotNetSerialize(saveGame);
        TestJsonDotNetDeserialize(json);

        json = TestFullSerializerSerialize(saveGame, fsSerializer);
        TestFullSerializerDeserialize(json, fsSerializer, tempSaveGame);
    }

    string TestUnitySerialize(SaveGame saveGame)
    {
        return JsonUtility.ToJson(saveGame);
    }

    SaveGame TestUnityDeserialize(string json)
    {
        return JsonUtility.FromJson<SaveGame>(json);
    }

    string TestLitJsonSerialize(SaveGame saveGame)
    {
        return JsonMapper.ToJson(saveGame);
    }

    SaveGame TestLitJsonDeserialize(string json)
    {
        return JsonMapper.ToObject<SaveGame>(json);
    }

    string TestJsonDotNetSerialize(SaveGame saveGame)
    {
        return JsonConvert.SerializeObject(saveGame);
    }

    SaveGame TestJsonDotNetDeserialize(string json)
    {
        return JsonConvert.DeserializeObject<SaveGame>(json);
    }

    string TestFullSerializerSerialize(SaveGame saveGame, fsSerializer serializer)
    {
        fsData fsData;
        serializer.TrySerialize(saveGame, out fsData);
        return fsJsonPrinter.CompressedJson(fsData);
    }

    SaveGame TestFullSerializerDeserialize(string json, fsSerializer serializer, SaveGame saveGame)
    {
        var fsData = fsJsonParser.Parse(json);
        serializer.TryDeserialize<SaveGame>(fsData, ref saveGame);
        return saveGame;
    }
}