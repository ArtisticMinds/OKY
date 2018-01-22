using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {

    public GameObject Fumetto01;
    public GameObject Fumetto02;
    public GameObject Fumetto03;
    public GameObject Fumetto04;
    public GameObject Fumetto05;
    public GameObject Fumetto06;
    public GameObject Fumetto07;
    public GameObject Fumetto08;
    public GameObject Fumetto09;
    public GameObject Fumetto10;
    public GameObject Fumetto11;
    public GameObject Fumetto12;

    public bool Fumetto01Showed;
    public bool Fumetto02Showed;
    public bool Fumetto03Showed;
    public bool Fumetto04Showed;
    public bool Fumetto05Showed;
    public bool Fumetto06Showed;
    public bool Fumetto07Showed;
    public bool Fumetto08Showed;
    public bool Fumetto09Showed;
    public bool Fumetto10Showed;
    public bool Fumetto11Showed;
    public bool Fumetto12Showed;

    public static Guide Istance;

    void Start () {
      //  if (GameManager.ThisLevelManager.LevelNumber != "1" && GameManager.ThisLevelManager.LevelNumber != "2"&& GameManager.ThisLevelManager.LevelNumber != "3") Destroy(gameObject);
        Istance = this;

        HideFumetti();
        if (GameManager.ThisLevelManager.LevelNumber == "1")
        {
            ShowFumetto01();
            Invoke("ShowFumetto03", 20);
        }
        else if (GameManager.ThisLevelManager.LevelNumber == "3")
        {
            Invoke("ShowFumetto07", 2);
            Invoke("ShowFumetto08", 12);
        }
        else if (GameManager.ThisLevelManager.LevelNumber == "5")
            Invoke("ShowFumetto08", 15);
    }
    public void HideFumetti()
    {
        Fumetto01.SetActive(false);
        Fumetto02.SetActive(false);
        Fumetto03.SetActive(false);
        Fumetto04.SetActive(false);
        Fumetto05.SetActive(false);
        Fumetto06.SetActive(false);
        Fumetto07.SetActive(false);
        Fumetto08.SetActive(false);
        Fumetto09.SetActive(false);
        Fumetto10.SetActive(false);
        Fumetto11.SetActive(false);
        Fumetto12.SetActive(false);
    }

    public void ShowFumetto01() {

        if(!Fumetto01Showed)
        Fumetto01.SetActive(true);

        Fumetto01Showed = true;

    }

    public void ShowFumetto02()
    {
        if (!Fumetto02Showed)
            Fumetto02.SetActive(true);

        Fumetto02Showed = true;

    }

    public void ShowFumetto03()
    {
        if (!Fumetto03Showed)
            Fumetto03.SetActive(true);

        Fumetto03Showed = true;

    }

    public void ShowFumetto04()
    {
        if (!Fumetto04Showed)
            Fumetto04.SetActive(true);

        Fumetto04Showed = true;
    }

    public void ShowFumetto05()
    {
        if (!Fumetto05Showed)
            Fumetto05.SetActive(true);

        Fumetto05Showed = true;

    }

    public void ShowFumetto06()
    {
        if (!Fumetto06Showed)
            Fumetto06.SetActive(true);

        Fumetto06Showed = true;

    }
    public void ShowFumetto07()
    {
        if (!Fumetto07Showed)
            Fumetto07.SetActive(true);

        Fumetto07Showed = true;

    }
    public void ShowFumetto08()
    {
        if (!Fumetto08Showed)
            Fumetto08.SetActive(true);

        Fumetto08Showed = true;

    }

    public void ShowFumetto09()
    {
        if (!Fumetto09Showed)
            Fumetto09.SetActive(true);

        Fumetto09Showed = true;

    }
    public void ShowFumetto10()
    {
        if (!Fumetto10Showed)
            Fumetto10.SetActive(true);

        Fumetto10Showed = true;

    }

    public void ShowFumetto11()
    {
        if (!Fumetto11Showed)
            Fumetto11.SetActive(true);

        Fumetto11Showed = true;

    }
    public void ShowFumetto12()
    {
        if(GameManager.m_Character.m_JumpPower<14)
        if (!Fumetto12Showed)
            Fumetto12.SetActive(true);

        Fumetto12Showed = true;

    }
    public void HideFumetto01()
    {
        Fumetto01.SetActive(false);

    }

    public void HideFumetto02()
    {
        Fumetto02.SetActive(false);

    }


    public void HideFumetto03()
    {
        Fumetto03.SetActive(false);

    }

    public void HideFumetto04()
    {
        Fumetto04.SetActive(false);

    }


    public void HideFumetto05()
    {
        Fumetto05.SetActive(false);

    }


    public void HideFumetto06()
    {
        Fumetto06.SetActive(false);

    }

    public void HideFumetto07()
    {
        Fumetto07.SetActive(false);

    }

    public void HideFumetto08()
    {
        Fumetto08.SetActive(false);

    }
    public void HideFumetto09()
    {
        Fumetto09.SetActive(false);

    }
    public void HideFumetto10()
    {
        Fumetto10.SetActive(false);

    }

    public void HideFumetto11()
    {
        Fumetto11.SetActive(false);

    }
    public void HideFumetto12()
    {
        Fumetto11.SetActive(false);

    }
}
