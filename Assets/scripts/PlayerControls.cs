using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float speed = 10f;
    Rigidbody PlayerRb;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerRb.AddForce(PlayerDir() * speed);
    }


    // Update is called once per frame
    void Update()
    {

    }

    Vector3 PlayerDir()
        {
            float x = Input.GetAxis("horizontal");
            float z = Input.GetAxis("vertical");
            Vector3 pDir = new Vector3(x, 0, z);

            return pDir;
        }


}
