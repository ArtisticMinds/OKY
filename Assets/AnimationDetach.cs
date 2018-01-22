using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDetach : MonoBehaviour {

	
	void Start () {
		
	}
	

	public void Detach () {
        transform.SetParent(null);
	}
}
