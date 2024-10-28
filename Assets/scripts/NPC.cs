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

    public float distance;
    public float mySpeed;
    public float health = 5.0f;

    // Start is called before the first frame update
    void Awake()
    {
        myScript = GetComponent<NPC>();

        myRB = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindWithTag("Player");
        target1 = GameObject.FindWithTag("Target");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);
        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
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
