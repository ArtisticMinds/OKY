using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour {


    public CameraType cameraType = CameraType.Tower;
    public enum CameraType
    {
        Tower, Horizontal
    }

 
    public Vector3 PositionOffSet;
    public Vector3 lookAtOffSet;
    public Transform target;
    [HideInInspector]
    public Transform normalTarget;
    Vector3 lookAt;
    //  [HideInInspector]
    public float SmoothMovements = 5;
    float RemoveSmooth;
    //  [HideInInspector]
    public float heightDamping = 15;
    public float height = -1f;
    Camera cam;
    public bool ToRotation;
    public bool entranceAnimation;
    Vector3 savedTowerPoistion;
    public CameraType cameraTypeOnStart;
    float fOvOnstart;


    void Start () {

        normalTarget = target;
        cam = Camera.main;
        lookAt = target.position;


        cameraTypeOnStart = cameraType;
        fOvOnstart = Camera.main.fieldOfView;
    }
    //Animazione player del entrata in una porta 
    void PlayerEntranceAnimation()
    {

        GameManager.m_Character.transform.LookAt(GameManager._sapwnPoint);
        GameManager.UserControl.m_Rigidbody.isKinematic = true;
        GameManager.UserControl.enabled = false;
        GameManager.m_Character.enabled = false;
        GameManager.m_Character.transform.position = Vector3.Lerp(GameManager.m_Character.transform.position,GameManager._sapwnPoint.position, Time.fixedDeltaTime * 0.5f * GameManager.TimeMultipler);
        GameManager.m_Character.m_Animator.SetFloat("Forward", 1f, 0.1f, Time.deltaTime * GameManager.TimeMultipler);
        
    }
    //Eseguito all'entrata in una porta (oneShot inviato dal TriggerInside)
    public IEnumerator StartRotation180()
    {
        RemoveSmooth = 4f;
        entranceAnimation = true;
        yield return new WaitForSeconds(1.2f); //Aspetta due secondi, tempo in cui esegue l'animazione di entrata
        Reactivate();

    }
    //Rotazione (OneShot) 
    void Reactivate()
    {
        

     
        GameManager.m_Character.transform.position = GameManager._sapwnPoint.position;
        GameManager.m_Character.transform.rotation = GameManager._sapwnPoint.rotation;

        //Riattiva tutto
        GameManager.UserControl.m_Rigidbody.isKinematic = false;
        GameManager.UserControl.enabled = true;
        GameManager.m_Character.enabled = true;
        ToRotation = false;//Segnalo che la rotazione è finita
    

        entranceAnimation = false;

        Invoke("EndRotation", 3f);
    }
    void EndRotation() {
        RemoveSmooth = 0;

    }

    void FixedUpdate() {

        if (cameraType.Equals(CameraType.Tower))
            FollowPlayerTower();

        if (cameraType.Equals(CameraType.Horizontal))
            FollowPlayerHorizontal();

        if (entranceAnimation)
            PlayerEntranceAnimation();
 
    }



        public void SwitchVisual()
    {


        if (cameraType.Equals(CameraType.Horizontal))
        {
            cameraType = CameraType.Tower;
            transform.position = savedTowerPoistion;
            Camera.main.fieldOfView = fOvOnstart;


        }
        else
        {
            savedTowerPoistion = transform.position;
            cameraType = CameraType.Horizontal;
            Camera.main.fieldOfView = 45;
        }
        GameManager.LastCheckPoint = Vector3.zero;
    }


    void FollowPlayerHorizontal()
    {
        if (!target)
            return;

        if (transform.position.y < 0.1f) transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);

        var wantedHeight = target.position.y;

        var currentHeight = transform.position.y;


        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime * GameManager.TimeMultipler);

        lookAt = Vector3.Lerp(lookAt, new Vector3(target.position.x, target.position.y, target.position.z), (SmoothMovements - RemoveSmooth) * Time.deltaTime * GameManager.TimeMultipler);

        //  transform.position = new Vector3(lookAt.x, Mathf.Lerp(transform.position.y, lookAt.y + (height), (SmoothMovements - RemoveSmooth) * Time.deltaTime / 2), lookAt.z);
        transform.position = lookAt + PositionOffSet;
        transform.LookAt(lookAt+ lookAtOffSet);
    }
    void FollowPlayerTower()
    {
        if (!target)
            return;

        if (transform.position.y < 0.1f) transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);

         var wantedHeight = target.position.y;

        var currentHeight = transform.position.y;


        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime * GameManager.TimeMultipler);

        lookAt = Vector3.Lerp(lookAt, new Vector3(target.position.x, target.position.y, target.position.z), (SmoothMovements - RemoveSmooth) * Time.deltaTime * GameManager.TimeMultipler);

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, lookAt.y+(height), (SmoothMovements - RemoveSmooth) * Time.deltaTime / 2 * GameManager.TimeMultipler), transform.position.z)+ PositionOffSet;
        transform.LookAt(lookAt+ lookAtOffSet);
    }
}
