using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreList {
    HighScore[] hs1,hs2,hs3,hs4;
    public HighScoreList()
    {
        hs1 = new HighScore[3];        
        hs2 = new HighScore[3];
        hs3 = new HighScore[3];
        hs4 = new HighScore[3];
        createLists();
    }
    private void createLists()
    {
        for(int y = 0; y < 3; y++)
        {
            hs1[y] = new HighScore(0, 0, "No Entry");
            hs2[y] = new HighScore(0, 0, "No Entry");
            hs3[y] = new HighScore(0, 0, "No Entry");
            hs4[y] = new HighScore(0, 0, "No Entry");
        }
    }
    public HighScore[] getHSList(int i)
    {
        HighScore[] temp = hs1;
        if (i == 2)
        {
            temp = hs2;
        }else if(i == 3)
        {
            temp = hs3;
        }else if(i == 4)
        {
            temp = hs4;
        }
        return temp;
    }
    public void setHSList(int i, HighScore[] hs)
    {
        if(i == 1)
        {
            hs1 = hs;
        }
        else if (i == 2)
        {
            hs2 = hs;
        }
        else if (i == 3)
        {
            hs3 = hs;
        }
        else if (i == 4)
        {
            hs4 = hs;
        }
    }
}
