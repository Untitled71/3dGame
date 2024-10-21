using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody myRB;
    public float mySpeed;
    public GameObject target1;
    public GameObject targetPlayer;
    public NPC myScript;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindWithTag("Player");
        target1 = GameObject.FindWithTag("Target");
        myScript = GetComponent<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

   protected virtual void Move()
    {
        //Debug.Log("dw");
    }
    protected virtual void Kick()
    {
        Debug.Log("dw");
    }
    protected virtual void Jump()
    {
        Debug.Log("dw");
    }
}
