// BULLET OBJECTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Speedup : Collectables
{
    public float speederupper = 1.0f;
    public float original_speed;
    protected override void item_effect()
    {
        original_speed = myPlayer.GetComponent<PlayerControls>().speed; // speed

        Debug.Log("Speeding Up");
        myPlayer.GetComponent<PlayerControls>().speed *= speederupper;
    }

    protected override void anti_effect()
    {
        Debug.Log("Normal Speed");
        myPlayer.GetComponent<PlayerControls>().speed = original_speed;
    }
}

