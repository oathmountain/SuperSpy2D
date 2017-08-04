using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System;


public class SaveLoad : MonoBehaviour
{
    public static string currentFilePath = "SuperSpy2D_Profiles.cjc";
    public static void Save(ProfileData pd)
    {
        Save(currentFilePath, pd);
    }
    public static void Save(string filePath, ProfileData pd)
    {
        File.Delete(filePath);
        ProfileData data = pd;
        Stream stream = File.Open(filePath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        bformatter.Serialize(stream, data);
        stream.Close();
    }
    public static ProfileData Load() { return Load(currentFilePath); }   // Overloaded
    public static ProfileData Load(string filePath)
    {
        ProfileData data = new ProfileData();
        Stream stream = File.Open(filePath, FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        data = (ProfileData)bformatter.Deserialize(stream);
        stream.Close();
        return data;
    }
}

public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));

            return typeToDeserialize;
        }

        return null;
    }
}

