using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static AudioSource MusicAudioSource;
    public static float MusicAmplifer=1;
    public static float MusicSourceVolume = 1;
    public static bool fade;
    public static bool Out;

    void Awake () {
        MusicAudioSource = GetComponent<AudioSource>();
        MusicAmplifer=1;
        MusicSourceVolume = 1;
    }

    void Start() {
        if (GameManager.TimeMultipler <= 0)
            MusicAudioSource.Pause();
    }

   public static void MusicFade()
    {
        if (Out)
        {
           
            MusicSourceVolume -= 0.6f * Time.deltaTime*GameManager.TimeMultipler;
        }
        else
        {
            MusicSourceVolume += 0.6f * Time.deltaTime * GameManager.TimeMultipler;
        }


            MusicAudioSource.volume = Mathf.Clamp01(MusicSourceVolume);

            if (MusicAudioSource.volume == 1 || MusicAudioSource.volume == 0) fade = false;
        }



    public static void MusicFadeOut()
    {
        fade=true;
        Out = true;
        MusicSourceVolume = 0.99f;
    }

    public static void MusicFadeIn()
    {
        fade = true;
        Out = false;
        MusicSourceVolume = 0.01f;
    }

    public static void StopFade()
    {
        fade = false;
        Out = false;
        MusicSourceVolume = 1f;
    }

    public static void PauseMusic() {
        MusicAudioSource.Pause();
    }

    public static void UnPauseMusic()
    {
        MusicAudioSource.UnPause();
    }

    void Update () {



        if (fade)
        MusicFade();

    }
}
