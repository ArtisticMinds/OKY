using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstantiateOnEnter : MonoBehaviour {

    public GameObject Prefab;
    public float delay = 1;
    public GameObject Shot;
    public Vector3 FallOff = new Vector3(0, 20, 0);
    public bool RandomizeXYFallOff=true;
    public Vector3 AddTorque = Vector3.zero;
    [Range(0, 100)]
    public int IstantiateProbability = 80;
    int rand;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            if (IstantiateProbability == 0) return;
            if (Random.Range(IstantiateProbability, 200) < 100) return;

            if (RandomizeXYFallOff)
                FallOff = new Vector3(Random.Range(-5, 25), FallOff.y, Random.Range(-1, 1));

            StartCoroutine(IstantiateNow());
        }
    }



    IEnumerator IstantiateNow() {
        yield return new WaitForSeconds(delay);
       if(!Shot) Shot = GameObject.Instantiate(Prefab, transform.position + FallOff, transform.rotation);
        Shot.GetComponent<Meteora>().AddTorque = AddTorque;
    
    }
}
