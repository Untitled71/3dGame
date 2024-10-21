using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugger : NPC
{
    // Start is called before the first frame update
    void Update()
    {
        //Debug.Log("Moving");
        Move();
    }

    // Update is called once per frame
    protected override void Move()
    {
        float xDelta = targetPlayer.transform.position.x;
        float yDelta = targetPlayer.transform.position.y;
        float zDelta = targetPlayer.transform.position.z;
        Vector3 dir = new Vector3(xDelta, yDelta, zDelta).normalized;
        dir *= mySpeed;
        myRB.AddForce(dir);
    }
}
