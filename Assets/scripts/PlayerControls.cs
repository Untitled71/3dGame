using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/* Pre-REQs
1. Attach script to Game Object = this is player object now, add player object tag
2. Apply Rigidbody Component to Player Object
3. Edit -> Project Settings -> Check inputManager 

*/

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody PlayerRb;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerRb.AddForce(transform.TransformDirection(PlayerDir()) * speed);
    }


    // Update is called once per frame
    void Update()
    {

    }

    Vector3 PlayerDir()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 pDir = new Vector3(x, 0, z);

            return pDir;
        }


}
