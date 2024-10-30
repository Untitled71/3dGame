// BULLET OBJECTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireFlick : Hazards
{

    protected override void initiate()
    {
        speed = 100f;
        casttime = 0.0f;
        lifeTime = 3.0f;
        dmg_multiplier = 2.0f;
    }

}