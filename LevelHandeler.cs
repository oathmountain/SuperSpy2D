using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandeler : MonoBehaviour
{
    LevelData[] levels;
    ProfileData pd = new ProfileData(0);
    Profile activeProfile;
    HighScoreList hsl = new HighScoreList();
    int activelevel;
    string playerName;
    public int amountoflevels = 12;
    private bool scorechanged, showhs;
    public bool testbool1, testbool2;
    private int credits, currentProfile=-1;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        levels = new LevelData[amountoflevels];
        try
        {
            pd = SaveLoad.Load();
        }
        catch
        {
            print("no saved file");
        }
        
        //levels[1] = new global::LevelData(1, 2, 200);
        //startingLevel(1);

        SceneManager.LoadScene(1);
    }
    public ProfileData getProfileData()
    {
        return pd;
    }
    public HighScoreList getHighscores()
    {
        updateHighScore();
        return hsl;
    }
    public void loadProfile(int i)
    {
        Profile p = pd.getProfile(i);
        activeProfile = p;        
        levels = p.getLevels();
        this.credits = p.getCredits();
        currentProfile = i;
        playerName = p.getName();
        //pd.setProfile(i, p);
    }
    public void loadProfile(string s)
    {
        Profile p = pd.getProfile(s);
        activeProfile = p;
        levels = p.getLevels();
        this.credits = p.getCredits();
        print(p.getCredits());
        print(this.credits);
        currentProfile = p.getIndex();
        playerName = p.getName();
    }
    public void saveProfile()
    {
        Profile p = pd.getProfile(currentProfile);
        p.setLevels(levels);
        p.setCredits(this.credits);
        pd.setProfile(currentProfile, p);
        //pd.getProfile(currentProfile).setLevels(levels);
        //pd.getProfile(currentProfile).setCredits(credits);

    }
    public void createProfile(string n)
    {
        pd.addData(n, new LevelData[amountoflevels], 0);
        loadProfile(pd.getProfileCount() - 1);
    }    

    public void startingLevel(int l) //måste köras innan man laddar in en level
    {
        levels[l].tries++;
        levels[l].level = l;
        activelevel = l;
    }
    public int getLevel()
    {
        return activelevel;
    }

    public int getCredits()
    {
        return this.credits;
    }
    public Profile getActiveProfile()
    {
        return activeProfile;
    }
    public void setCredits(int c)
    {
        this.credits = c;
        activeProfile.setCredits(c);
    }

    public LevelData getLevelData(int l)
    {
        return levels[l];
    }

    public void resetLevels()
    {
        levels = new LevelData[amountoflevels];
        this.credits = 0;
    }

    public void setOldCredits(int a, int b)
    {
        levels[b].oldCredits = a;
    }

    public void setLocked(int a, bool b)
    {
        levels[a].unlocked = b;
    }

    public bool getLocked(int a)
    {
        return levels[a].unlocked;
    }
    public void showHighScore()
    {
        showhs = !showhs;

    }
    private void updateHighScore()
    {
        foreach (Profile p in pd.getAllProfiles())
        {
            for (int i = 4; i < 8; i++)
            {
                LevelData[] ld = p.getLevels();
                LevelData l = ld[i];
                HighScore[] hs = hsl.getHSList(i-3);
                HighScore temp = new HighScore(0,0, "");
                bool wasHigher = false;
                bool wasInList = false;
                for (int y = 0; y < 3; y++)
                {                    
                    HighScore s = hs[y];
                    if(s.getName().Equals(p.getName()) && s.getScore() == l.score){
                        wasInList = true;
                    }
                    if(temp.getScore() > s.getScore() && s.getScore() != 0 && !wasInList)
                    {
                        hs[y] = temp;
                        temp = s;
                    }else if(l.score > s.getScore() && !wasHigher && !wasInList)
                    {
                        wasHigher = true;
                        temp = s;
                        hs[y] = new HighScore(y, l.score, p.getName());
                    }
                }
                hsl.setHSList(i-3, hs);
            }            
        }
    }

    public void updateLevel(LevelData temp)
    {
        LevelData LD = levels[activelevel];
        if (LD.level != temp.level)
        {
            print("level number not a match");
        }
        else
        {
            LD.tries += temp.tries;
            if (LD.score <= temp.score)
            {
                LD.remainingCredits = temp.remainingCredits;
                LD.score = temp.score;
                LD.credits = temp.credits;
                LD.grade = temp.grade;
                scorechanged = true;
            }
            levels[activelevel] = LD;
        }
    }
    public void save()
    {
        saveProfile();
        SaveLoad.Save(pd);
    }
    void Update()
    {
        if (testbool1)
        {
            SceneManager.LoadScene(0);
            testbool1 = false;
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            updateHighScore();
            for (int i = 1; i < 5; i++)
            {
                print("Level " + i + " HighScores");
                foreach (HighScore hs in hsl.getHSList(i))
                {
                    print(hs.getScore() + " " + hs.getName());
                }
            }
        }
        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            saveProfile();
            SaveLoad.Save(pd);
        }*/
        /*if(testbool1)
        {
            updateLevel(new global::LevelData(1,2,500));
            testbool1 = false;
        }
        if (testbool2)
        {

            print(""+levels[activelevel].score);
            testbool2 = false;
        }*/
    }
}
