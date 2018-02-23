using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiShot : MonoBehaviour {

    public Vector3 Speed;
    float YpositioN;

    public float myTimer;

    public float LifeTime = 5;

    private void Awake()
    {
        YpositioN = transform.position.y;
    }

    public void GoNow () {
        myTimer = 0;
        transform.LookAt(new Vector3(GameManager.m_Character.transform.position.x, YpositioN, GameManager.m_Character.transform.position.z));
    }


    void EndShot() {
        gameObject.SetActive(false);

    }

    void Update()
    {


        myTimer += Time.deltaTime * GameManager.TimeMultipler;

        transform.Translate(Speed * Time.deltaTime);
        Vector3 look = new Vector3(GameManager.m_Character.transform.position.x, YpositioN, GameManager.m_Character.transform.position.z);




        if (myTimer > LifeTime)
        {

            EndShot();

        }
        }
}
