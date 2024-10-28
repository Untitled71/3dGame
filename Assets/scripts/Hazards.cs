// STANDARD BULLET OBJECT ATTRIBUTES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hazards : MonoBehaviour
{
    public Hazards myScript;

    private Rigidbody rb;
    public GameObject myPlayer;
    // This will be standard stats necessary for a bullet
    public float speed = 10.0f;
    public float casttime = 0.0f;
    public float lifeTime = 3.0f;
    public int damage = 1;


    public void Awake()
    {
        myScript = GetComponent<Hazards>();

        rb = GetComponent<Rigidbody>();
        myPlayer = GameObject.FindWithTag("Player");
    }

    public void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    public void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            
            Destroy(gameObject);
            Debug.Log("Enemy: " + collision.gameObject.name + " Hit");

        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Shot");

        }
        else
        {
            Destroy(gameObject);
        }
    }

}