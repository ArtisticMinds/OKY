using UnityEngine;
using System.IO;

public class Player : MonoBehaviour {
    public string VariabileNonSerializzata;


    public PlayerData playerDataObject;
    //L'istanza della sotto classe PlayerData 
    //Apertura classe PlayerData
    [System.Serializable]
    public class PlayerData {
       public string name="Jack";
        public int age=27;
        public string gender ="Maschio";
    } //Chiusura classe PlayerData

    public string altraVariabileNonSerializzata;
    public string altraVariabileNonSerializzata2;
    void Awake(){

    }
    void Start () {
 
    }
    //Percorso file da salvare/caricare 
     string filePath;
    // Funzione per serializzare e salvare il file su disco

    public void Save(){
        string jsonString = JsonUtility.ToJson(playerDataObject, true); //Crea la stringa da salvare 
        File.WriteAllText(filePath, jsonString); //Salva la stringa sul file al percorso stabilito 
    } // Funzione per deserializzare il file ed inserire i dati in playerDataObject 
    public void Load(){
        string jsonString = File.ReadAllText(filePath); //Leggi il file 
        playerDataObject = JsonUtility.FromJson<PlayerData>(jsonString); //Reimposta playerDataObject con i dati caricati 
    }

} //Chiusura Classe Player