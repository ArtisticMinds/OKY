using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShotArea : MonoBehaviour {

    public Alien01 alien;
    public Neanderthal neanderthal;
    public bool OnlyLookArea;
    public bool ShotArea;
    public bool SlugArea;
    public NeandertalBossApiedi neandertalBossApiedi;

    void OnEnable()
    {
        if (alien && ShotArea && alien.ShotEnabled == false)
            gameObject.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        #region IfAlien
        if (alien)
        {
            if (GameManager.PlayerIsDead)
            {
                alien.StopAllAttack();
                alien.IsHappy();
                return;
            }

            else
            {

                if (col.tag.Equals("Player"))
                {


                    if (SlugArea)
                    {

                        alien.StopShot();
                        alien.StartSlug();

                        return;
                    }



                    if (OnlyLookArea)
                    {
                        alien.LookPalyer();
                    }
                    else
                    {
                        if (ShotArea)
                        {
                            if (alien.ShotEnabled)
                                alien.StartShot();
                        }
                        else {
                            alien.StopShot();
                        }

                    }
                }
            }
        }
        #endregion

        #region IfNeanderthal
        else if (neanderthal)
        {

            if (SlugArea)
            {
                if (col.tag.Equals("StopFollowPlayer"))
                {

                    neanderthal.WayPointIsPlayer = false;
                    neanderthal.WalkAnimationSpeed = neanderthal.NormalWalkAnimationSpeed;
                    neanderthal.WayPoint = neanderthal.LastWayPoint.position;
                    neanderthal.PauseWalk();
                    neanderthal.FollowThePlayerActive = false;
                    Invoke("FollowPlayerActivation", 3);
                    return;

                }
            }


            if (col.tag.Equals("Player"))
            {
                if (GameManager.PlayerIsDead)
                {
                    neanderthal.StopAllAttack();
                    // alien.IsHappy();
                    return;
                }

                if (SlugArea)
                {

                    neanderthal.StartAttack01();

                    return;
                }
                else if (OnlyLookArea)
                {
                    if (neanderthal.FollowThePlayerActive)
                        neanderthal.LookPalyer();
                }



            }






        }
        #endregion

        #region neandertalBossApiedi
        else if (neandertalBossApiedi)
        {

            if (SlugArea)
            {

            }


            if (col.tag.Equals("Player"))
            {
                if (GameManager.PlayerIsDead)
                {
                    // neandertalBossApiedi.StopAllAttack();

                    return;
                }

                if (ShotArea)
                {
                    neandertalBossApiedi.ShotLancia();

                }
                else if (SlugArea)
                {
                    neandertalBossApiedi.Carica();
                }



            }





            #endregion
        }
    }

    void FollowPlayerActivation() {

        if (neanderthal) neanderthal.FollowThePlayerActive = true;
    }

    void OnTriggerExit(Collider col)
    {
        # region IfAlien
        if (alien)
        {
            if (SlugArea)
                if (col.tag.Equals("Player"))
                    alien.StopSlug();
                else
                    alien.StopShot();
       

        if (ShotArea)
            alien.StopShot();

            if (OnlyLookArea)
            {
                alien._StopLookPalyer();
            }
        }


        #endregion

        #region IfNeanderthal
        else if (neanderthal)
        {
            if (SlugArea)
                if (col.tag.Equals("Player"))
                    neanderthal.StopAttack01();

        }

    
#endregion
  
    #region neandertalBossApiedi
        else if (neandertalBossApiedi)
        {
        
        if (ShotArea) 
        neandertalBossApiedi.StopSHotLancia();


            if (SlugArea)
                neandertalBossApiedi.StopCarica();
        }

       
    }

    #endregion





}


