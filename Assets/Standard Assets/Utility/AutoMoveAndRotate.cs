using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
        public bool ignoreTimescale;
        private float m_LastRealTime;
        public Renderer MainRenderer;
        public bool translation=false;
        public bool UseWilezRotation=true;
        public bool IsVisible = false;


        private void Awake()
        {
            m_LastRealTime = Time.realtimeSinceStartup;

            MainRenderer = GetComponent<Renderer>();


        }



        void Update()
        {





            if (UseWilezRotation) {
                transform.Rotate(rotateDegreesPerSecond.value* Time.deltaTime);
            }
            else
            {
                float deltaTime = Time.deltaTime;
                if (ignoreTimescale)
                {
                    deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
                    m_LastRealTime = Time.realtimeSinceStartup;
                }
                if (translation) transform.Translate(moveUnitsPerSecond.value * deltaTime, moveUnitsPerSecond.space);
                transform.Rotate(rotateDegreesPerSecond.value * deltaTime, moveUnitsPerSecond.space);
            }
        }


        [Serializable]
        public class Vector3andSpace
        {
            public Vector3 value;
            public Space space = Space.Self;
        }
    }
}
