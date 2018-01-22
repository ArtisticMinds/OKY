using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uccello : MonoBehaviour {


    public float speed = 200;
    public float RotationSpeed = 5;
    public WayPoints theWay;
    Vector3 WayPoint;
    Rigidbody _rigid;
    SkinnedMeshRenderer rendr;
    int i;
    Transform ObjToDetack;
    public GameObject Shot;
    public Transform ShotPoint;
    public float ActivationDelay=20;
    float myTimer;
    bool Enabled;


    void Start () {

        if (!theWay) theWay = GetComponentInChildren<WayPoints>();
        if (!rendr) rendr = GetComponentInChildren<SkinnedMeshRenderer>();

        GenerateRock();
        _rigid = GetComponent<Rigidbody>();
        if (theWay)
            WayPoint = theWay.points[0].position;

        rendr.enabled = false;
        if (ObjToDetack)
            ObjToDetack.GetComponent<Renderer>().enabled = false;
    }

    void GenerateRock() {
        if (ObjToDetack) return;
        ObjToDetack= GameObject.Instantiate(Shot, ShotPoint).transform;
        ObjToDetack.localPosition = Vector3.zero;
        ObjToDetack.GetComponent<Ruota>().enabled = false;
        ObjToDetack.GetComponent<Rigidbody>().isKinematic = true;
    }



    public void CheckWayPoints()
    {
        if (!Enabled) return;

        if (Vector3.Distance(transform.position, theWay.points[i].position) < 0.5f)
        {
            if (i < theWay.points.Length - 1)
            {
                i++;
            }
            else
            {

                i = 0;
                System.Array.Reverse(theWay.points);
                GenerateRock();
                return;
            }
        }



        SmoothLook(theWay.points[i].position);

        if (i <= 1 || i == theWay.points.Length - 1)
        {
            rendr.enabled = false;
            if (ObjToDetack)
                ObjToDetack.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            rendr.enabled = true;
            if(ObjToDetack)
            ObjToDetack.GetComponent<Renderer>().enabled = true;
        }

    }

    void SmoothLook(Vector3 newDirection)
    {

        var targetRotation = Quaternion.LookRotation(newDirection - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (RotationSpeed*2) * Time.fixedDeltaTime * GameManager.TimeMultipler);

    }

    void OnTriggerEnter(Collider col)
    {
        if (!Enabled) return;
        if (!ObjToDetack) return;

        if (col.tag.Equals("Player"))
        {
            ObjToDetack.GetComponent<Rigidbody>().isKinematic = false;
            ObjToDetack.SetParent(null);
            Invoke("ActivateShot", 0.1f);
        }
    }


    void ActivateShot() {
        if (!ObjToDetack) return;

        ObjToDetack.GetComponent<Ruota>().enabled = true;
    }


    void FixedUpdate () {


                myTimer += Time.fixedDeltaTime * GameManager.TimeMultipler;

                if (myTimer >= ActivationDelay) Enabled = true;

                if (!Enabled) return;
                CheckWayPoints();


                _rigid.velocity = transform.forward * (speed / 2f) * Time.fixedDeltaTime * GameManager.TimeMultipler;
            
    }
}
