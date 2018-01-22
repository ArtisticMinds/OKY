using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{

	public bool OnlyDeactivate;
    public float TimeForDead=1;
    public bool UseStart;
    public bool DetachBeforeDestruction;
    void OnEnable()
    {

        if (!UseStart)
        {
            if (DetachBeforeDestruction) transform.SetParent(null);
            Invoke("DestroyDelay", TimeForDead);
        }
    }
    void Start()
    {
        if (UseStart)
        {
            if (DetachBeforeDestruction) transform.SetParent(null);
            Invoke("DestroyDelay", TimeForDead);
        }
    }
    void DestroyDelay()
    {

        if (gameObject.activeInHierarchy)
        {
            if (OnlyDeactivate)
                gameObject.SetActive(false);
            else
                Destroy();
        }
              
     }

    private void Destroy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Destroy(transform.gameObject);
    }
}
