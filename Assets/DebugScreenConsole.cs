using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugScreenConsole : MonoBehaviour {

    public static Text _ConsoleTextsMessage;
    public static DebugScreenConsole Instance;

    void Awake () {

        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            Instance = this;
        }



        _ConsoleTextsMessage = GameObject.Find("_ConsoleTextsMessage").GetComponent<Text>();
        _ConsoleTextsMessage.text = "<WILEz Debugging Console>\n";

    }
	

	public static void Print (string message) {
        if(Instance)
        _ConsoleTextsMessage.text += "\n\n> " + message;

    }
    public static void Print(string message,bool AlsoConsole)
    {
        if (Instance)
        {
            _ConsoleTextsMessage.text += "\n\n> " + message;
        }
        if (AlsoConsole)
            print(message);
    }

    public static void Print(string message, bool AlsoConsole,bool RandomColor)
    {
        string color="#FFFFFF";
        if (RandomColor)
        {
            color= colorToHex();
        }

            if (Instance)
        {
            _ConsoleTextsMessage.text += "\n\n> <color=#"+ color.ToString() +">"+ message+"</color>";
        }
        if (AlsoConsole)
            print(message);
    }


    public static string colorToHex()
    {




        int r = Random.Range(30, 255);
        int g = Random.Range(80, 255);
        int b = Random.Range(30, 255);

        string hex = string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);

        
        return hex;
    }

    public void OpenColse(string message)
    {
        GetComponent<Animator>().SetBool("Open", !GetComponent<Animator>().GetBool("Open"));

    }

}
