// COLLECTABLE OBJECTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Speedup : Collectables
{
    public float original_speed;
    float speederupper = 3f;


    /////////////////////
    ///  Stat Changes ///
    /////////////////////
    protected override void initiate()
    {
        Lifetime = 10.0f;
        effectlast = 10.0f;
    }

    protected override void item_effect()
    {
        original_speed = myPlayer.GetComponent<PlayerControls>().speed; // speed

        //Debug.Log("Speeding Up");
        myPlayer.GetComponent<PlayerControls>().speed *= speederupper;
        //Debug.Log(myPlayer.GetComponent<PlayerControls>().speed);
    }

    protected override void anti_effect()
    {
        //Debug.Log("Normal Speed");
        myPlayer.GetComponent<PlayerControls>().speed = original_speed;
    }
}

