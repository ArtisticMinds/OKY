using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFollow : MonoBehaviour {



	void Start () {
		
	}


	void Update () {
        transform.Translate(moveUnitsPerSecond.value * Time.deltaTime);
    }
}
