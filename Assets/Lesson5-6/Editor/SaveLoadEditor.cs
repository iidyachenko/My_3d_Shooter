using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveLoadEditor
{
    [MenuItem("Geekbrains/Save level")]
    private static void SaveObj()
    {
        string path = EditorUtility.SaveFilePanel("Chose file", Application.dataPath, "LevelData", "xml");

        var objs = Object.FindObjectsOfType<GameObject>();
        var objList = new List<SerializableGameObject>();

        foreach(var o in objs)
        {
            objList.Add(new SerializableGameObject
            {
                PrefubName = o.name,
                Pos = o.transform.position,
                Scale = o.transform.localScale,
                Rot = o.transform.rotation
            });
        }
        XMLSerializator.Save(objList.ToArray(), path);
    }

    [MenuItem("Geekbrains/Load level")]
    private static void LoadObj()
    {
        string path = EditorUtility.OpenFilePanel("Choose File", Application.dataPath, "xml");
        var objs = XMLSerializator.Load(path);
        foreach(var o in objs)
        {
            GameObject prefab = Resources.Load<GameObject>(o.PrefubName);
            var TempObj = Object.Instantiate(prefab, o.Pos, o.Rot);
            TempObj.transform.localScale = o.Scale;
            TempObj.name = o.PrefubName;
        }
    }
}
