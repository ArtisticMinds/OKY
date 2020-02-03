using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_numberAnimation : MonoBehaviour {

    public int FromNumber;
    public int TargetNumber;
    public bool Active;
    public int Number;
    public int NumberStep = 1;
    public float StartDelay = 0;
    public float GapSpeed = 0.3f;
    float MyTimer;
    Text UItext;
    public string AddTextAtEnd;

    void Start () {

        UItext = GetComponent<Text>();
        UItext.text = "";

    }

    public  void SetCount(int startN,int endN, float startDelay)
    {
        StartDelay = startDelay;
        FromNumber = startN;
        TargetNumber = endN;
        if(UItext)StartCount();

    }

     void StartCount()
    {
        UItext.text = FromNumber.ToString();
        Invoke("ResetAndStart", StartDelay);
    }

     void ResetAndStart()
    {
        Number = FromNumber;

        Active = true;
    }

    void AddNumber()
    {
        Number += NumberStep;
       // print("Add " + Number);
    }

    void RemoveNumber()
    {
        Number -= NumberStep;
      //  print("Remove " + Number);
    }

    void Stop() { Active = false; MyTimer = 0; Number = TargetNumber; }

    void Update () {
        if (Active) {

            MyTimer += Time.deltaTime * GameManager.TimeMultipler;

            if (MyTimer < GapSpeed) return;

            if (Number != TargetNumber)
            {

                if (FromNumber < TargetNumber)
                    if (TargetNumber > Number)
                        AddNumber();
                    else
                        Stop();


                if (FromNumber > TargetNumber)
                    if (TargetNumber < Number)
                        RemoveNumber();
                    else
                        Stop();

                MyTimer = 0;


                UItext.text = Number.ToString()+ AddTextAtEnd;
            }
            else
                Stop();

        }

	}
}
