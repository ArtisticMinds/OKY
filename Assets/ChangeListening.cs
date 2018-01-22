using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeListening : MonoBehaviour {

     Dropdown myDropdown; // declare your dropdown
    public GameObject MessageTo;
    public string MessageToSend;

    void Awake() {
        myDropdown = GetComponent<Dropdown>();

    }
    void Start()
    {

        myDropdown.onValueChanged.AddListener(delegate {
            OnMyValueChange(myDropdown);
        });
    }
    public void OnMyValueChange(Dropdown dd)
    {
        Action();
    }

    void Action() {

        MainMenu.UpdateData();
        // SendMessage(MessageToSend, MessageTo);
    }

    void OnDestroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();

    }
}
