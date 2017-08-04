using System;
using System.Runtime.Serialization;
using UnityEngine;
[Serializable()]
public struct ProfileData : ISerializable
{
    Profile[] profiles;
    int pcount;
   /* public ProfileData(int i)
    {
        profiles = new Profile[i];
    }*/
    public ProfileData(int i)
    {
        profiles = new Profile[0];
        pcount = 0;
    }
    public ProfileData(SerializationInfo info, StreamingContext ctxt)
    {
        profiles = (Profile[])info.GetValue("Profile", typeof(Profile[]));
        pcount = (int)info.GetValue("Pcount", typeof(int));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
        info.AddValue("Profile", (profiles));
        info.AddValue("Pcount", (pcount));
    }
    public void addData(string n, LevelData[] l, int c)
    {
        pcount ++;
        Profile[] tempP = new Profile[pcount];
        for(int i = 0; i < pcount-1; i++)
        {
            tempP[i] = profiles[i];
        }
        //tempP = profiles;
        tempP[pcount-1] = new Profile(n, l, c, pcount-1);
        profiles = new Profile[pcount];
        profiles = tempP;        
           /* Profile p = profiles[];
            if(p.getName() == null)
            {
                profiles[i] = new Profile(n, l);
                return;
            }*/        
    }
    public Profile getProfile(int i)
    {
        return profiles[i];
    }
    public int getProfileCount()
    {
        return pcount;
    }
    public Profile[] getAllProfiles()
    {
        return profiles;
    }
    public Profile getProfile(String s)
    {
        foreach(Profile p in profiles)
        {
            if(p.getName().Equals(s))
            {
                return p;
            }
        }
        return new Profile();
    }
    public void setProfile(int i, Profile p)
    {
        profiles[i] = p;
    }
}

