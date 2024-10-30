using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPC myScript;

    public Rigidbody myRB;
    public GameObject targetPlayer;
    public GameObject target1;

    // public bec to be changed by anyclass (special effects)
    public float distance;
    public float mySpeed; 
    public float health;

    // Start is called before the first frame update
    void Awake()
    {
        myScript = GetComponent<NPC>();

        myRB = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindWithTag("Player");
        target1 = GameObject.FindWithTag("Target");

        initiate();
    }
    protected virtual void initiate()
    {
        mySpeed = 0.5f;
        health = 5.0f;

    }
        // Update is called once per frame
        void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);
        if (health <= 0.0f)
        {
            ondeath();
            Destroy(gameObject);
        }
    }

   protected virtual void ondeath()
    {

    }

   protected virtual void Move()
    {

    }
    protected virtual void Kick()
    {

    }
    protected virtual void Jump()
    {

    }
    

}
