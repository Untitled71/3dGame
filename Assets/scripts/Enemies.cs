using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : NPC
{
    public GameObject blood;

    public float dmgdealt = 1.0f;
    public float enemyspeed = 5f;
    public float enemyhealth = 2.5f; 

    void Update()
    {
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);
        //Debug.Log(distance);

        if (distance <= 50.0f)
        {
            //Debug.Log("I should follow player!");
            Move();
        }
        else
        {
           Stop();
           //Debug.Log("I cannot see player!");
        }
    }

    protected override void initiate()
    {


        mySpeed = enemyspeed;
        health = enemyhealth;
    }

    // Update is called once per frame
    protected override void Move()
    {
        //Debug.Log("MOVING");
        float xDelta = targetPlayer.transform.position.x - transform.position.x;
        float yDelta = targetPlayer.transform.position.y - transform.position.y;
        float zDelta = targetPlayer.transform.position.z - transform.position.z;
        Vector3 dir = new Vector3(xDelta, yDelta, zDelta).normalized;
        dir *= mySpeed;
        myRB.AddForce(dir);
    }

    protected void Stop()
    {
        //Debug.Log("STOPPPED");
    }

    protected override void ondeath()
    {
        targetPlayer.GetComponent<PlayerControls>().Score++;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //Debug.Log("Enemy: " + collision.gameObject.name + " Hit");

        }
        else if (collision.gameObject.tag == "enemy")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            
            //Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "hazard") 
        { 
             Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        }

    }
}
