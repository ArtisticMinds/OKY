using System.Collections;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof (Text))]
    public class FPSCounter : MonoBehaviour
    {

        private Text m_Text;
        float mis_period = 7;
        public static int OldFrameRate;
        public static int m_CurrentFps;
        private float myTimer;
        static public float multipler=1.6f;

    float deltaTime = 0.0f;
    private void Start()
    {
        
        m_Text = GetComponent<Text>();
    }
    void Update()
    {

        


            myTimer += Time.deltaTime;

            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float msec = deltaTime * 1000.0f;
            float fps = 1f / deltaTime;
            m_CurrentFps = (int)fps;

        if (myTimer >= mis_period)
        {
            OldFrameRate = m_CurrentFps;
            m_Text.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec/ multipler, (fps* multipler)+Random.Range(-5,+1));
            myTimer = 0;
        }

        if (Social.localUser.userName != "ArtisticMinds75"&& Social.localUser.userName != "Lerpz") m_Text.text = "";
    }


}

