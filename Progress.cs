using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{

    private int initialscore, alarmscore, triesscore, timescore, score, killscore,
        kills, alarms, tries,
        minutes, oldtime,
        totalkills, totalalarms;
    private float time, fadetimer, fadetime = 0.1f, totaltime;
    private Texture guard, alarm, player;
    private bool scoreChanged = false;
    public Text ScoreText;
    public Text TimeText;


    //gui setup data
    private Color regular, faded;

    // Use this for initialization
    void Start()
    {
        //score variables   
        initialscore = 2000;
        score = initialscore;
        killscore = 250;
        alarmscore = 450;
        triesscore = 500;
        timescore = 25;

        //textures
        guard = Resources.Load<Texture>("guard 1");
        alarm = Resources.Load<Texture>("alarmicon");
        player = Resources.Load<Texture>("Player-male");

        //gui elements
        
       
        regular = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1);
        faded = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 0.5f);
    }

    public int getKills()
    {
        return kills;
    }
    public int getAlarms()
    {
        return alarms;
    }
    public int getTries()
    {
        return tries;
    }
    public int getScore()
    {
        return score;
    }
    public int getMaxScore()
    {
        return initialscore;
    }


    public void addKill()
    {
        kills++;
        totalkills++;
        if (score != 0)
        {
            calculateScore(killscore);
        }
    }
    public void addAlarmCount()
    {
        alarms++;
        totalalarms++;
        if (score != 0)
        {
            calculateScore(alarmscore);
        }
    }
    public void addTryCount()
    {
        tries++;
        calculateScore(triesscore);
    }

    void calculateScore(int change)
    {
        if (score - change >= 0)
        {
            score = score - change;
            scoreChanged = true;
        }
        else
        {
            score = 0;
        }
    }

    public void resetScore()
    {
        time = 0;
        kills = 0;
        alarms = 0;
        time = 0;
        oldtime = 0;
        minutes = 0;
        score = initialscore;
        //    calculateScore((tries) * triesscore);
    }

    void OnGUI()
    {
        int seconds = (int)time;
        TimeText.text = minutes.ToString() + ":" + seconds.ToString(); //gui timer

        //scorestart
        if (scoreChanged)//fadeout of color (only of score), that gives feedback that scorechanged
        {
            GUI.contentColor = faded;
            if (fadetimer > fadetime) //fadein after fadetime seconds
            {
                scoreChanged = false;
                fadetimer = 0;
                GUI.contentColor = regular;
            }
        }
        ScoreText.text = score.ToString();
        //score end

        if (scoreChanged)//reset of color for rest of ui, if score is faded
        {
            GUI.contentColor = regular;
        }

        //representation of amount of killed guards this run, triggered alarms this run, and total amount of tries
        int x = 1000;
        for (int i = 0; i < kills; i++)
        {
            GUI.Label(new Rect(x, 10, 40, 40), guard);
            x = x + 13;
        }
        x = 1010;
        for (int i = 0; i < alarms; i++)
        {
            GUI.Label(new Rect(x, 45, 20, 20), alarm);
            x = x + 13;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        int newtime = (int)time / 10;//saves a new int every 10 seconds
        if (time >= 60)//resets seconds to 0 when it reaches 60, adds a minute count
        {
            minutes++;
            time = 0;
            oldtime = 0;
            newtime = 0;
            if(score != 0) { 
            calculateScore(timescore);
            }
        }
        if (newtime > oldtime && newtime > 0)//when the newtime int changes every 10 seconds, subtract timescore
        {
            oldtime = newtime;
            if (score != 0)
            {
                calculateScore(timescore);
            }
        }

        if (scoreChanged)//updates the timer of the fade, when score changes
        {
            fadetimer += Time.deltaTime;
        }
    }
}
