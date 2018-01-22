using UnityEngine;
using System.Collections;

public class QualityControl : MonoBehaviour
{

    public int AtMinQuality;
    public enum Azione { delete, disabilitaComp, diasabilitaRenderer }

    public Azione azione = Azione.delete;
    public GameObject Sostitutivo;
    public bool ForceChidrenDestruction;
    public Behaviour Componente;

    void Awake()
    {
        ControllNow();


    }

    public void  ControllNow()
    {
        if (Sostitutivo)
            Sostitutivo.SetActive(false);

        if (QualitySettings.GetQualityLevel() < AtMinQuality || QualitySettings.GetQualityLevel() == 0)
        {

            if (Sostitutivo)
                Sostitutivo.SetActive(true);

            if (azione == Azione.delete)
            {//Se azione Delete, distruggi questo gameObject

                if (ForceChidrenDestruction)
                    foreach (Transform ch in GetComponentInChildren<Transform>())
                        Destroy(ch.gameObject);

                Destroy(gameObject);

            }


            if (azione == Azione.disabilitaComp)
            {//Se azione DistrugiComponente


                if (Componente)
                    Componente.enabled = false;
            }

            if (azione == Azione.diasabilitaRenderer)
            {//Se azione DistrugiComponente


                if (GetComponent<Renderer>())
                    GetComponent<Renderer>().enabled = false;
            }

        }
    }

}
