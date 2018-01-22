using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class W_SceneTimer : MonoBehaviour {

    [HideInInspector]
	public float sceneTimer = 99;
    [HideInInspector]
    public Text timerText;
    [HideInInspector]
    public string MessaggioFineTempo;
    public bool PauseTimer;
    Color OrColor;
    public AudioClip LowTimeSound;
    int minutes;
    int seconds;
    string stringTime;
    AudioSource TimerAudioSource;
    public Animator UIAnimator;
    public float TimerAtStart;
    void Awake()
    {

        GetComponent<W_numberAnimation>().enabled = false;
        TimerAudioSource = GetComponent<AudioSource>();
        UIAnimator.SetBool("Low", false);
        UIAnimator.SetBool("Get", false);


    }

    void Start () {
        TimerAtStart= sceneTimer = GameManager.ThisLevelManager.SceneTime;
        timerText = GetComponent<Text> ();
        OrColor = timerText.color;

    }


    void Count()
    {
        if (PauseTimer) return;
        sceneTimer -= Time.deltaTime * GameManager.TimeMultipler;
        timerText.text = ToMinAndSeconds();

        if (minutes==0 && seconds == 10)
        {
            
          if(timerText.color!=Color.red) TimerAudioSource.PlayOneShot(LowTimeSound);
            timerText.color = Color.red;
            UIAnimator.SetBool("Low", true);
        }
        else if (seconds > 10)
        {
            timerText.color = OrColor;
            TimerAudioSource.Stop();
            UIAnimator.SetBool("Low", false);
        }
       
    }


    string ToMinAndSeconds()
    {
        

         minutes = Mathf.FloorToInt(sceneTimer / 60F);
         seconds = Mathf.FloorToInt(sceneTimer - minutes * 60);
         stringTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (sceneTimer <= 0) { stringTime = "0:00"; }

        return stringTime;
    }

    void Update () {
        if (GameManager.LevelComplete) return;
        if (GameManager.Lose) return;

        if (GameManager.PlayerIsDead) return;

        if (sceneTimer > 0)
        {
            Count();
        }
        else
        {
            GameManager.EndTime();
    
        }

        if(TimerAudioSource.isPlaying)
        if (GameManager.Instance.GetGameState().Equals(GameManager.Game_State.Pause))
            TimerAudioSource.mute=true;
        else
            TimerAudioSource.mute = false;


    }
}
