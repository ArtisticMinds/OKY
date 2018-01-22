using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimation : MonoBehaviour {

    Vector3 OrPosition;
    Vector3 Pos01;
    Vector3 EndPosition;
    float MyTimer;
    bool state0;

    void Awake() {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.position= new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

	void Start () {

        OrPosition = transform.position;
        Pos01 = new Vector3(transform.position.x, transform.position.y + 2.3f, transform.position.z);
        EndPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    IEnumerator Rreactivate(){

        if (!transform.GetChild(0).gameObject.activeInHierarchy)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<Renderer>().enabled = true;
            GameManager.MasterAudioSource.PlayOneShot(GameManager.Instance.dropSound);
        }
        yield return new WaitForSeconds(1f);
        GetComponent<Collider>().enabled = true; //Riattiva il collider (ora è raccoglibile)
       
    }

	void Update () {

        if (MyTimer > 4)
        {
            this.enabled=false;
            MyTimer = 0;
            return;
        }

        MyTimer += Time.deltaTime;
        if (MyTimer >= 1.25f) StartCoroutine(Rreactivate());

         if (MyTimer>2f)
        transform.position = Vector3.Lerp(transform.position, EndPosition, Time.deltaTime * 7 * GameManager.TimeMultipler);//Scende
        else if (MyTimer > 1.3f)
         transform.position = Vector3.Lerp(transform.position, Pos01, Time.deltaTime * 10 * GameManager.TimeMultipler); //Sale
    }
}
