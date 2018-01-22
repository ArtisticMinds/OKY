using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettingTrigger : MonoBehaviour {

    public FollowTarget cameraFollowLook;
    public bool ChangeOffset;
    public Vector3 NewOffset;

    public bool ChangSmoothing;
    public float NewSmoothing;
    Vector3 OginalOffSet;
    float OrSmoothing;



    void Start () {
       OginalOffSet= cameraFollowLook.offset;
        OrSmoothing = cameraFollowLook.smooting;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag.Equals("Player"))
        {

            if(ChangeOffset)
            cameraFollowLook.offset = NewOffset;

            if(ChangSmoothing)
               cameraFollowLook.smooting=NewSmoothing;
        }
        }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.tag.Equals("Player"))
        {

            if (ChangeOffset)
                cameraFollowLook.offset = OginalOffSet;
            if (ChangSmoothing)
                 cameraFollowLook.smooting=OrSmoothing;

        }
    }




    void Update () {
		
	}
}
