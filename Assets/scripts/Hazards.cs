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

    // Only to be changed by the childclass
    protected float speed;
    protected float casttime;
    protected float lifeTime;
    protected float dmg_multiplier;


    public void Awake()
    {
        myScript = GetComponent<Hazards>();

        rb = GetComponent<Rigidbody>();
        myPlayer = GameObject.FindWithTag("Player");

        initiate();
    }

    protected virtual void initiate()
    {
        speed = 10f;
        casttime = 0.0f;
        lifeTime = 3.0f;
        dmg_multiplier = 0.5f;
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