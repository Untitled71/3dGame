// COLLECTABLE OBJECTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectables : MonoBehaviour
{
    public Collectables myScript;

    public GameObject myPlayer;
    public Rigidbody myRB;

    protected float Lifetime = 10.0f;
    protected float effectlast = 4.0f;

    public float tempefftimer;
    public bool active_passive;
    protected bool onoff;

    public void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        myPlayer = GameObject.FindWithTag("Player");

        active_passive = false;
        onoff = false;

        tempefftimer = 100f;
    }

    protected virtual void initiate()
    {
        Lifetime = 10.0f;
        effectlast = 4.0f;
    }

    public void FixedUpdate()
    {
        // item despawn
        Lifetime -= Time.deltaTime;

        if ( tempefftimer > 0.0f )
        {
            tempefftimer -= Time.deltaTime;
        }

        if (tempefftimer <= 0.0f) {
            active_passive = false;
            onoff = true;
        }

        if (onoff == true)
        {
            if (active_passive == false)
            {
                anti_effect();
            }
            onoff = false;
        }

        if( (Lifetime <= 0.0f && active_passive == false) || (tempefftimer <= 0.0f && active_passive == false) )
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Collect Item
            // Destroy(gameObject); // will end effect wont it?
            item_effect();
            active_passive = true;
            tempefftimer = effectlast;

            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Renderer>());
            Debug.Log("Item Collected: " + gameObject.name + " by [ " + collision.gameObject.name + " ]!");
        }
        else
        {
            //Destroy(gameObject);
        }
    }



    protected virtual void item_effect()
    {
        Debug.Log("Initiate Item");
    }

    protected virtual void anti_effect()
    {
        Debug.Log("reverse changes");
    }
}






/*
     void actswitch()
    {
        
    }
        if (Lifetime <= 0.0f)
        {
            Destroy(gameObject); //cannot destroy if collected
        }
        while (active_passive)
        {
            item_effect();
            tempefftimer -= Time.deltaTime;
            if (tempefftimer <= 0.0f)
            {
                anti_effect();
                active_passive = false;
            }
        }
 * 
 * 
 */