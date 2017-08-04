using System;
using UnityEngine;
using System.Runtime.Serialization;
[Serializable()]
public struct LevelData : ISerializable
{
    public int level { get; set; }
    public int tries { get; set; }
    public int credits { get; set; }
    public int remainingCredits { get; set; }
    public int score { get; set; }
    public int grade { get; set; }
    public int oldCredits { get; set; }
    public bool unlocked { get; set; }

    public LevelData(int l, int t, int s, int c, int rc, int g)
    {
        level = l;
        tries = t;
        score = s;
        credits = c;
        remainingCredits = rc;
        grade = g;
        oldCredits = 0;
        unlocked = false;
    }
    public LevelData(SerializationInfo info, StreamingContext ctxt)
    {
        level = (int)info.GetValue("Level", typeof(int));
        tries = (int)info.GetValue("Tries", typeof(int));
        score = (int)info.GetValue("Score", typeof(int));
        credits = (int)info.GetValue("Credits", typeof(int));
        remainingCredits = (int)info.GetValue("RemainingCredits", typeof(int));
        grade = (int)info.GetValue("Grade", typeof(int));
        oldCredits = (int)info.GetValue("OldCredits", typeof(int));
        unlocked = (bool)info.GetValue("Unlocked", typeof(bool));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
        info.AddValue("Level", (level));
        info.AddValue("Tries", (tries));
        info.AddValue("Score", (score));
        info.AddValue("Credits", (credits));
        info.AddValue("RemainingCredits", (remainingCredits));
        info.AddValue("Grade", (grade));
        info.AddValue("OldCredits", (oldCredits));
        info.AddValue("Unlocked", (unlocked));
    }
}
