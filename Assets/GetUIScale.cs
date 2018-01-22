using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUIScale : MonoBehaviour {

	public bool AddY;
    public float multipler = 1;
    Vector3 OrScale;
    Vector3 OrPosition;
    static GetUIScale[] AllUIScale;
    public bool UseScale = true;
    public bool UseAlpha = true;
    public static float UIAlpha = 0.8f;

    void Awake() {
        AllUIScale = FindObjectsOfType<GetUIScale>();
        OrScale = transform.localScale;
        OrPosition = transform.localPosition;
    }

	void Start () {

        UpdateScale();
    }

   public void UpdateScale()
    {
        if (UseScale)
        {
            transform.localScale = OrScale * GameManager.ControlsUIScale * multipler;
            if (AddY)
                transform.localPosition = new Vector3(OrPosition.x, OrPosition.y * GameManager.ControlsUIScale, OrPosition.z);
        }


        if(UseAlpha&& GetComponent<CanvasGroup>())
        GetComponent<CanvasGroup>().alpha = UIAlpha;
    }


    //Aggiorna tutte le UIScale a runtime
    public static void UpdateAll()
    {
   
        foreach (GetUIScale all in AllUIScale)
            all.UpdateScale();

    }
}
