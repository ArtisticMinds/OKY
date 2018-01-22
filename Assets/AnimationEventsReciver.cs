using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventsReciver : MonoBehaviour {

    Animator anima;
    Boss01 boss01;
	void Start () {
        anima = GetComponent<Animator>();
        boss01 = GetComponentInParent<Boss01>();
    }

    public void StopAttack01()
    {

        anima.SetBool("Attack", false);
        boss01.InAttacking = false;

    }

    public void EmitStartAttackEffect()
    {
        transform.root.GetComponent<Boss01>().EmitStartAttackEffect();
    }

    public void EmitColpoAttackEffect()
    {
        transform.root.GetComponent<Boss01>().EmitColpoAttackEffect();
    }
}
