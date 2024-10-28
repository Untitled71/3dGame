// STANDARD BULLET OBJECT ATTRIBUTES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hazards : MonoBehaviour
{
    public Hazards myScript;
    // This will be standard stats necessary for a bullet
    public float speed = 10.0f;
    public float casttime = 0.0f;
    public float lifeTime = 3.0f;
    public int damage = 1;

    public GameObject myPlayer;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myPlayer = GameObject.FindWithTag("Player");
    }

    public void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            
            Destroy(gameObject);
            Debug.Log("Enemy: " + collision.gameObject.name + " Hit");

        }
        else
        {
            Destroy(gameObject);
        }
    }

}