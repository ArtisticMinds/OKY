

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpItem : MonoBehaviour
{


    public static float timer = 10;

    public Text timerText;
    Color OrColor;
    public float normalJumpPower;
    int minutes;
    int seconds;
    string stringTime;
    public static JumpItem Instance;


    void Awake()
    {
        Instance = this;

    }

    void Start()
    {
         
       
        OrColor = timerText.color;

    }


    void Count()
    {

        timer -= Time.deltaTime * GameManager.TimeMultipler;
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

    public static void EndTime()
    {
        GameManager.m_Character.m_JumpPower = Instance.normalJumpPower;
        RemoveScreenIcons();
    }

    public static void RemoveScreenIcons()
    {

        Instance.gameObject.SetActive(false);
        GameManager.m_Character.SuperJumpEffect.SetActive(false);
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
