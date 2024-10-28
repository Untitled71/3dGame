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

    public float speed = 10.0f;
    public float casttime = 0.0f;
    public float lifeTime = 3.0f;
    public float dmg_multiplier = 0.5f;


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
            collision.gameObject.GetComponent<Enemies>().health -= (myPlayer.GetComponent<PlayerControls>().damage * dmg_multiplier);
            Destroy(gameObject);
            Debug.Log("Enemy: " + collision.gameObject.name + " Hit");
            Debug.Log(collision.gameObject.GetComponent<Enemies>().health);

        }
        else if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Shot");

        }
        else
        {
            Destroy(gameObject);
        }
    }

}