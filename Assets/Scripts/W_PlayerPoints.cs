using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_PlayerPoints : MonoBehaviour
{

    static public W_PlayerPoints _istance;
    public  int GamePlayerPoints { get; protected set; }

    public  Text _PlayerStars; ////Il Text dove scrivere le stelle raccolte dal player durante la partita
    public  Text _StarsNeeded; //Text dove scrivere le stelle necessarie
    public  int _StarsGeted;//Testo in alto aggiornato in realtime

    public  Text _TotalStars;//Il Text Dove scrivere le stelle totali che erano nel livello
    public  Text _GetedStars;//Text alla fine del livello
    public  Text _GetedPoints;//Text alla fine del livello
    public  Text _TimeSummary;//Text alla fine del livello
    public GameObject[] Stars;
    public GameObject PerfectIcon;

    public int PointsByOther;






    public  int ThisLevelActualPoints;
    public  GameObject _NewLevelRecord;


    public static Animator animator;

    public static bool StarsComplete;
    public static int CompletedLevels;


    string thisWorld;

    void Start()
    {

        GameManager.Timer.transform.GetComponent<W_numberAnimation>().enabled = true;
       

        //All'inizio azzero
        _PlayerStars.text = "0";
        //Prende il numero di stelle necessarie per completare questo livello
        _StarsNeeded.text = "/"+GameManager.ThisLevelManager.StarNeeded.ToString();

        PointsByOther = 0;

        //Prendo il numero del mondo su cui sta giocando
        thisWorld = GameManager.ThisLevelManager.Word.ToString();
        GetActualWorldPoints();
    }

    void Awake()
    {

        _istance = this;
        //Per l'animazione di raggiungimento stelle necessarie
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0);
        //Rimetto a non completo l'obbiettivo (essendo static)
        StarsComplete = false;
    }

    public int GetActualWorldPoints()
    {

        GamePlayerPoints = PlayerPrefs.GetInt(GameManager.Instance.AppName + thisWorld + "_WorldPoints"); //Punti Totali del mondo thisWorld


        Debug.Log("World: "+ thisWorld+" Points: " + GamePlayerPoints.ToString());
        return GamePlayerPoints;
    }


    //Punteggio del mondo in questione
    //Aggiunge i punti appena fatti (a fine livello) al totale (Punti Totali del thisWorld)
    public void UpdateAndStorePLayerHigScore(int Points, int RemoveOld)
    {

        //Salva i punti aggiungendo quelli inviati (punti totali del mondo, non del livello)
        //Nel caso ci sia un nuovo record del livello, rimuovo il vecchio punteggio fatto su questo livello dal totale e metto quello nuovo
        PlayerPrefs.SetInt(GameManager.Instance.AppName + thisWorld+ "_WorldPoints", GamePlayerPoints + Points - RemoveOld);

        Debug.Log("Actual World("+ thisWorld+") GamePoints: " + GamePlayerPoints + "+" + Points +"-" + RemoveOld + "=" + (GamePlayerPoints + Points - RemoveOld).ToString());

        //Salvo il mondo su cui si stava giocando per poter riaprire il gioco direttamente su quella schermata
        PlayerPrefs.SetInt(GameManager.Instance.AppName + "LastWorld", GameManager.ThisLevelManager.Word);
        print("SetLastWorld: " + GameManager.ThisLevelManager.Word);
    }





    //Calcola i punti fatti in questo livello in base al tempo rimasto
    public void LevelComplete()
    {

        print("StarsInTheScene: " + LevelManager.StarsInTheScene + " StarsGeted:" + _StarsGeted);

        if (_StarsGeted > LevelManager.StarsInTheScene) LevelManager.StarsInTheScene = _StarsGeted;//Per sicurezza

        //CALCOLO DEI PUNTI
        float PointsByRemainingTime = Mathf.Abs(Mathf.Ceil((GameManager.Timer.sceneTimer / GameManager.Timer.TimerAtStart) *1000)) ; //Sempre meno di 1000, diventa 1000 se impiegati 0 secondi
        int PointsByStars = 1500/ Mathf.Abs(LevelManager.StarsInTheScene-_StarsGeted+1)+1; //Al massimo 1500 (se prende tutte le stelle nel livello)
        if (_StarsGeted >= LevelManager.StarsInTheScene)  PointsByStars += 700;    //Se sono state prese tutte le stelline, aggiungo un bonus di 700 punti
        int PointsByEnergy = Mathf.Abs((int)(GameManager.m_Character.PlayerEnergy * 500));
        int PointsByDataTime = Mathf.Min(GameManager.GiorniPassati*2,1000);//Punti in base ai mesi del gioco, massimo 1000

        if (GameManager.ThisLevelManager.SecretAreasInThisLevel < 0)//Se c'erano aree segrete
        if (ActivationTrigger.endLevelSecretsAreaUI.founded < GameManager.ThisLevelManager.SecretAreasInThisLevel)//Se non sono state trovate tutte le aree segrete
                RemovePoints(500);
            else
                AddPoints(500);



 

            //Calcolo il punteggio in base alle stelle prese e al tempo rimasto (più PointsByOther e PointsByDataTime)
            ThisLevelActualPoints = ((int)PointsByRemainingTime + PointsByStars+ PointsByOther+ PointsByEnergy+ PointsByDataTime+GameManager.ThisLevelManager.AddRemovePointsAtEnd);
         print("PointsByDataTime:"+ PointsByDataTime+" PointsByRemainingTime;" + PointsByRemainingTime + " PointsByStars:" + PointsByStars + " PointsByEnergy:" + PointsByEnergy + "   ThisLevelActualPoints:<color=#FFFFFFF>" + ThisLevelActualPoints + "</color>");

        //Alla fine il punteggio massimo può arrivare a circa 5500, se prese tutte le stelline, tutte le aree segrete e con energia massima, dunque 
        //un buon punteggio potrà arrivare a circa 4000

        _GetedPoints.GetComponent<W_numberAnimation>().SetCount(0, ThisLevelActualPoints, 0);//Imposto le stelline con l'animazione
        _GetedStars.GetComponent<W_numberAnimation>().SetCount(0, _StarsGeted, 1);//Imposto le stelline con l'animazione
        _TimeSummary.GetComponent<W_numberAnimation>().SetCount(0, (int)GameManager.Timer.sceneTimer, 1);//Imposto il tempo rimasto con l'animazione
        GameManager.Timer.transform.GetComponent<W_numberAnimation>().enabled = true;
        GameManager.Timer.transform.GetComponent<W_numberAnimation>().SetCount((int)GameManager.Timer.sceneTimer,0 , 1);//Decremento il tempo rimasto con l'animazione
        _TotalStars.text = "/"+LevelManager.StarsInTheScene.ToString();


        Stars[0].SetActive(true);//Se completato, almeno una stella
        Stars[1].SetActive(false);
        Stars[2].SetActive(false);
        PerfectIcon.SetActive(false);

        //Qui calcolo e salvo il punteggio per assegnare le stelle e la corona
        if (ThisLevelActualPoints > GameManager.Star02Points) Stars[1].SetActive(true);
        if (ThisLevelActualPoints > GameManager.Star03Points) Stars[2].SetActive(true);
        if (ThisLevelActualPoints > GameManager.CrowPoints)  PerfectIcon.SetActive(true);
        

        //Compara i vecchi punti del livello con quelli appena fatti
        OldNewLevelPOintsComparation();

        GameManager.m_Character.DissolveRex();

    }



    public void OldNewLevelPOintsComparation()
    {

        //Prende il vecchio punteggio di questo livello salvato
        int OldLevelsPoints = PlayerPrefs.GetInt(GameManager.Instance.AppName + "LevN_" + GameManager.ThisLevelManager.LevelNumber);

        //Solo se è la prima volta che si completa questo livello
        if (OldLevelsPoints == 0)
        { AddGemsAtEndLevel(GameManager.ThisLevelManager.WinGemAtEnd); }


            //Compara il vecchio punteggio salvato con quello appena fatto
            if (ThisLevelActualPoints > OldLevelsPoints)
        {
            _NewLevelRecord.SetActive(true); //Attiva il testo di "nuovo record effettuato"
            SaveLevelData(); //Salva il nuovo punteggio di QUESTO LIVELLO su playerRev
            UpdateAndStorePLayerHigScore(ThisLevelActualPoints, OldLevelsPoints); //Aggiorna e salva il punteggio totale del MONDO in questione 
        }
        else {
            _NewLevelRecord.SetActive(false); //Disattivo il testo di "nuovo record effettuato"
        }
        print("AppName:" + GameManager.Instance.AppName + " LevN_:" + GameManager.ThisLevelManager.LevelNumber);
        print("TotalActualPoints:<color=#555555>" + ThisLevelActualPoints + "  OLdLevelPoints:</color><color=#555555>" + OldLevelsPoints+ "</color>");

        if(CheckInternetConnection.IsOnline)
        if(MainMenu.Instance)MainMenu.Instance.UpdateAllWorldsWebData();//Invio i dati di questo livello al punteggio del mondo sul web
    }

    public void SaveLevelData()
    {
        //Salva in formato LevN_n dove n è il numero del livello appena finito con dato il numero dei punti fatti su questo livello
        //Es. LevN__1 2500

        PlayerPrefs.SetInt(GameManager.Instance.AppName + "LevN_" + GameManager.ThisLevelManager.LevelNumber, ThisLevelActualPoints);
        print("SavePoints:" + "LevN_" + GameManager.ThisLevelManager.LevelNumber + " Points:" + ThisLevelActualPoints);


    }




    public void AddStars(int points )
    {
        _StarsGeted += points;
        _PlayerStars.text = _StarsGeted.ToString();

        if (_StarsGeted >= GameManager.ThisLevelManager.StarNeeded)
            ObbiettivoRaggiunto();
    }


    public void AddPoints(int points)
    {
        PointsByOther += points;
        //Qui posso mettere un modificatore generale di punteggio in base al tempo da cui esiste il gioco on-line
        //Così sarà sempre possibile migliorare i punteggi, nel tempo i punteggi che si faranno saranno sempre leggermente più alti

    }
    public void RemovePoints(int points)
    {
        if(PointsByOther>points)
        PointsByOther -= points;
       //Tolgo un po' di punti ad ogni respawn

    }
    //Aggiunge gemme a fine livello, solo se è la prima volta che si porta termine
    public void AddGemsAtEndLevel(int value)
    {
        if (value <= 0) return;

        W_GemManager._istance.AddGems(value);//Aggiunge gemme

     
    }


    void ObbiettivoRaggiunto()
    {
        _PlayerStars.color = Color.yellow;
        animator.SetFloat("Speed", 1);
        StarsComplete = true;
        GameManager.ThisLevelManager.endLevel.OpenPortalEffect();
        
    }
}
