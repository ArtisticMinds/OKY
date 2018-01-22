using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedItem : MonoBehaviour {


    public static float timer = 10;

    public Text timerText;
    Color OrColor;
    int minutes;
    int seconds;
    string stringTime;
    public static SpeedItem instance;

    void Awake()
    {

        instance = this;
    }

    void Start()
    {
    

        OrColor = timerText.color;

    }


    void Count()
    {
       
        timer -= Time.deltaTime;
        timerText.text = ToMinAndSeconds();

        if (minutes == 0 && seconds == 3)
        {

            timerText.color = Color.red;
          
        }
        else if (seconds > 3)
        {
            timerText.color = OrColor;

        }

    }


    string ToMinAndSeconds()
    {


        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
        stringTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timer <= 0) { stringTime = "0:00"; }

        return stringTime;
    }

    public static void  EndTime()
    {
        GameManager.m_Character.m_AnimSpeedMultiplier = GameManager.m_Character.OrSpeedMultiplier;
        GameManager.m_Character.m_MoveSpeedMultiplier = GameManager.m_Character.OrSpeedMultiplier;
        RemoveScreenIcons();
    }

    public static void RemoveScreenIcons() {

        GameManager.m_Character.SuperSpeedEffect.SetActive(false);
        instance.gameObject.SetActive(false);
    }


    void Update()
    {
        if (GameManager.LevelComplete) return;
        if (GameManager.Lose) return;

        if (GameManager.PlayerIsDead) return;

        if (timer > 0)
        {
            Count();
        }
        else
        {
            EndTime();

        }

    }
}
