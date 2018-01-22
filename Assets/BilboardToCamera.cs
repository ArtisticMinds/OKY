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

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
           Camera.main.transform.rotation * Vector3.up);
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (inUpdate)
        {

            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
             Camera.main.transform.rotation * Vector3.up);
        }

        if (MoveUp)
        {
            newPosition = transform.position + (new Vector3(0, 3f * Time.deltaTime, 0));
            transform.position = newPosition;
        }
        if (Dissolve)
        {
            alpha -= 0.01f * Time.deltaTime;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, rend.material.color.a + alpha);

            if (alpha <= -1)
                Destroy(transform.root.gameObject);
        }
    }
}
