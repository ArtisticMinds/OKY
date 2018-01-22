using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutLineAdjust : MonoBehaviour {

    public Material[] thisMats;
    public float scale = 0.0002f;
    public float Minumum = 0.0025f;
    List<float> OrValues = new List<float>();

    void Awake () {
        thisMats = GetComponentInChildren<Renderer>().materials;
        
        for (int i = 0; i < thisMats.Length; i++)
            OrValues.Add( thisMats[i].GetFloat("_Outline"));


    }


    void Update()
    {
        if(GameManager.Instance)
        if (GameManager.Instance.GetGameState().Equals(GameManager.Game_State.Running))
        {

            float Value = (Camera.main.transform.position - transform.position).magnitude * scale;

            for (int i = 0; i < thisMats.Length; i++)
            {
                Value = Mathf.Clamp(Value, Minumum, OrValues[i]);
                thisMats[i].SetFloat("_Outline", Value);
            }
        }
    }

}
