using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardToCamera : MonoBehaviour
{

    public bool inUpdate;
    public bool MoveUp;
    Vector3 newPosition;
    public bool Dissolve;
    Renderer rend;
    float alpha;

    void Start()
    {

        transform.LookAt(Camera.main.transform);
        transform.localEulerAngles = new Vector3(0, 180, 0);
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (inUpdate)
        {
            transform.LookAt(Camera.main.transform);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (MoveUp)
        {
            newPosition = transform.position + (new Vector3(0, 1f * Time.deltaTime, 0));
            transform.position = newPosition;
        }
        if (Dissolve)
        {
            alpha -= 0.01f;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, rend.material.color.a + alpha);
        }
    }
}
