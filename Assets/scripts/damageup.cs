// COLLECTABLE OBJECTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class damageup : Collectables
{
    protected float original_damage;
    protected float damageupper = 7.0f;

    protected override void initiate()
    {
        Lifetime = 10.0f;
        effectlast = 7.0f;
    }

    protected override void item_effect()
    {
        original_damage = myPlayer.GetComponent<PlayerControls>().damage; // speed

        //Debug.Log("Speeding Up");
        myPlayer.GetComponent<PlayerControls>().damage *= damageupper;
        //Debug.Log(myPlayer.GetComponent<PlayerControls>().speed);
    }

    protected override void anti_effect()
    {
        //Debug.Log("Normal Speed");
        original_damage = myPlayer.GetComponent<PlayerControls>().damage = original_damage;
    }
}

