using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companion : NPC
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);
        Move(); // can i uncomment this? NO

        Debug.Log(distance);
    }

    // Update is called once per frame
    protected override void Move()
    {
        if (distance >= 4.0f)
        {
            Debug.Log("I should follow player!");
            float xDelta = targetPlayer.transform.position.x - transform.position.x;
            float yDelta = targetPlayer.transform.position.y - transform.position.y;
            float zDelta = targetPlayer.transform.position.z - transform.position.z;
            Vector3 dir = new Vector3(xDelta, yDelta, zDelta).normalized;
            dir *= mySpeed;
            myRB.AddForce(dir);
        }
        else
        {
            Debug.Log("I am next to the player!");
        }

    }
}
