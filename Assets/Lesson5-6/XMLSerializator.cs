﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public static class XMLSerializator  
{
    private static XmlSerializer serializer;

    static XMLSerializator()
    {
        serializer = new XmlSerializer(typeof(SerializableGameObject[]));
    }

    public static void Save(SerializableGameObject[] objs, string path)
    {
        if (objs == null || objs.Length == 0 || string.IsNullOrEmpty(path)) return;
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(fs, objs);
        }
    }

    public static SerializableGameObject[] Load(string path)
    {
       if(!File.Exists(path)) return null;

        SerializableGameObject[] result;

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            result = (SerializableGameObject[])serializer.Deserialize(fs);
        }
        return result;
    }

}
