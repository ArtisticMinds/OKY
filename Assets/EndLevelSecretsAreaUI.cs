using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelSecretsAreaUI : MonoBehaviour
{

    public Text _DiscoveredSecretAreas;

    public Text _TotalSecretAreas;
    public int founded;
    public List<ActivationTrigger> Total = new List<ActivationTrigger>();

    private void Awake()
    {

    }

    private void Start()
    {
        founded = 0;
        Total.Clear();

        foreach (ActivationTrigger areas in FindObjectsOfType<ActivationTrigger>())
            if (areas.IsSecretArea)
                Total.Add(areas);

        GameManager.ThisLevelManager.SecretAreasInThisLevel = Total.Count;
        _TotalSecretAreas.text = Total.Count.ToString();
       _DiscoveredSecretAreas.text = founded.ToString();

        print("TotalSecretsAreasInScene "+Total.Count );

        if (Total.Count > 0)
           gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

    }

    public void AddDiscoveredArea()
    {
        founded++;
        _DiscoveredSecretAreas.text = founded.ToString();

        print("TotalSecretsAreasInScene " + Total.Count + "Discovered: " + founded);

    }

}
