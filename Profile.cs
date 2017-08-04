using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;
[Serializable()]
public struct Profile : ISerializable
{
    string name;
    LevelData[] levels;
    int credits;
    int index;
    public Profile(string n, LevelData[] l, int c, int i)
    {
        name = n;
        levels = l;
        credits = c;
        index = i;
    }
    public Profile(SerializationInfo info, StreamingContext ctxt)
    {
        name = (string)info.GetValue("Name", typeof(string));
        levels = (LevelData[])info.GetValue("Levels", typeof(LevelData[]));
        credits = (int)info.GetValue("Credits", typeof(int));
        index = (int)info.GetValue("Index", typeof(int));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
        info.AddValue("Name", (name));
        info.AddValue("Levels", (levels));
        info.AddValue("Credits", (credits));
        info.AddValue("Index", (index));

    }
    public string getName()
    {
        return name;
    }
    public int getIndex()
    {
        return index;
    }
    public void setLevels(LevelData[] ld)
    {
        levels = ld;
    }
    public LevelData[] getLevels()
    {
        return levels;
    }
    public int getCredits()
    {
        return credits;
    }
    public void setCredits(int c)
    {
        credits = c;
    }
}
