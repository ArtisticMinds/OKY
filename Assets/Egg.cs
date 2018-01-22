using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

    public Texture2D[] EggTextures;
    public GameObject DestructionPrefb;
    Renderer rend;
    int Colpo;
    DropObjects dropObject;
    Vector3 OrYPosition;
    public bool update=false;


    private void Awake()
    {
        OrYPosition = transform.position;
    }

    void Start () {
        if(update)
        transform.position = new Vector3(transform.position.x, OrYPosition.y-3, transform.position.z);
        rend = GetComponent<Renderer>();
        rend.materials[0].mainTexture = EggTextures[0];
        Colpo = 0;
        dropObject = GetComponent<DropObjects>();

    }

    void OnTriggerEnter(Collider col)
    {

        if (GameManager.PlayerIsDead)
        {

            return;
        }
   
        if (col.tag.Equals("Player"))
        {

            if (GameManager.m_Character.PlayerYVelocity < 0.01f)
            {
                GameManager.m_Character.AutoBounceNow(0.7f);

                if (Colpo == 0) Colpo01();
                if (Colpo > 0) Colpo02();

                Colpo++;
            }
        }
    }
    void Colpo01 () {
        rend.materials[0].mainTexture = EggTextures[1];
    }


    void Colpo02()
    {
      GameObject destr=  GameObject.Instantiate(DestructionPrefb, transform.position, Quaternion.identity);
        if (dropObject)
        {
            dropObject.DropNow();
        }
        Destroy(gameObject, 0.2f);
    }

    private void Update()
    {
        if(update)
        if(Vector3.Distance(transform.position, OrYPosition)>0.01f)
        transform.position = Vector3.Lerp(transform.position, OrYPosition, Time.deltaTime );
    }
}
