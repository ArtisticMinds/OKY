using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Spawner : MonoBehaviour {

    public float StartTime = 5;
    public GameObject[] PrefabsObjects;
    public GameObject[] DropObjects;
    public float[] DropObjValue;
    public float SpawnTime = 10;
    public int SpawnID;
    public int MaxTogheter=1;
    List<GameObject> OnSceneObjects = new List<GameObject>();
    public Vector3 SpawnOffSet;
    public GameObject SpawnEffect;
    public float Delay = 1;
    public float WayPointsYOffSet;




    void Start () {
        OnSceneObjects.Clear();
        InvokeRepeating("SpawnNow", StartTime, SpawnTime);

    }


	void SpawnNow () {
        if (GameManager.PlayerIsDead) return;

        if (SpawnID > PrefabsObjects.Length - 1)
        {
            SpawnID = 0;
            OnSceneObjects.Clear();
            return;
        }

        for (var i = OnSceneObjects.Count - 1; i > -1; i--)
        {
            if (OnSceneObjects[i] == null)
                OnSceneObjects.RemoveAt(i);
        }

        if (SpawnID < PrefabsObjects.Length-1)
        {
            SpawnID++;
        }
        else
        {
            SpawnID = 0;
            return;
        }

        if (OnSceneObjects.Count >= MaxTogheter) return;

        //SpawnEffect
       GameObject.Instantiate(SpawnEffect, transform.position + SpawnOffSet, SpawnEffect.transform.rotation);
       Invoke("Spawn", Delay);

    }

    void Spawn() {
        GameObject obj = GameObject.Instantiate(PrefabsObjects[SpawnID], transform.position + SpawnOffSet, transform.rotation);

        if (obj.GetComponent<Alien01>()) { 
        obj.GetComponentInChildren<WayPoints>().transform.position = new Vector3(transform.position.x, transform.position.y + WayPointsYOffSet, transform.position.z);
        obj.GetComponent<Alien01>().enabled = false;
            StartCoroutine(ActivateOject(obj));
        }
        OnSceneObjects.Add(obj);



        if (DropObjects.Length - 1 >= SpawnID) {
            obj.GetComponent<DropObjects>().DropItem = DropObjects[SpawnID - 1];
            obj.GetComponent<DropObjects>().AddValue = DropObjValue[SpawnID - 1];
        }
        obj.transform.rotation = transform.rotation;
    }


    IEnumerator ActivateOject(GameObject obj) {

        yield return new WaitForSeconds(Delay);
       if(obj) obj.GetComponent<Alien01>().enabled = true;
    }


    void OnDisable()
    {
        CancelInvoke("SpawnNow");
    }
}
