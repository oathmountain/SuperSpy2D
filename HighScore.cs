using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HighScore{
    int level;
    int score;
    string name;
    public HighScore(int l, int s, string n)
    {
        level = l;
        score = s;
        name = n;
    }
    public int getScore()
    {
        return score;
    }
    public string getName()
    {
        return name;
    }
    public int getLevel()
    {
        return level;
    }
}
