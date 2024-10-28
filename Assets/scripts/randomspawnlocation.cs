using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawnlocation : MonoBehaviour
{
    public int mov = 20;
    public int rot = 180;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0,0,mov * Time.deltaTime);
        transform.Rotate(0,rot * Time.deltaTime, 0);
    }
}
