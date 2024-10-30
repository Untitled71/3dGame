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
    Rigidbody PlayerRb;

    // EXTERNAL OBJECTS~
    public GameObject bulletPrefab;
    public Transform firingPoint;

    // MOVEMENT VAR
    public float speed = 5.0f;
    public float jump = 3.0f;
        public bool inair = false;
        public bool doublejumped = false;

    // PLAYER STATS
    public int Score = 0;
    public float Health = 3.0f;
    public float Mana = 10.0f;
    public float damage = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }


    void Update()
    {   //Debug.Log(speed);
        // Movement
        PlayerRb.AddForce(transform.TransformDirection(PlayerDir()).normalized * speed);


        if (Input.GetMouseButtonDown(0))
        { // INPUT MOUSE ACTION
            Shoot();
        }
        if (Input.GetKeyDown("space") && inair == false)
        { // JUMP 1 (RIGIDBODY FORCE)
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            doublejumped = false;
            inair = true;
        } else if (Input.GetKeyDown("space") && inair == true && doublejumped == false)
        { // JUMP 2 (RIGIDBODY FORCE)
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            doublejumped = true;
        }
    }

    // MOVEMENT
    Vector3 PlayerDir()
    { 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 pDir = new Vector3(x, 0, z);

        return pDir;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        //Debug.Log("Bullet Spawned");
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground") 
        {
            inair = false;
            doublejumped = false;
            //Debug.Log("on Ground");
        }
        if(collision.gameObject.tag == "enemy")
        {
            Health -= collision.gameObject.GetComponent<Enemies>().dmgdealt;
            Score--;
            Debug.Log(Health);
        }
    }

}
