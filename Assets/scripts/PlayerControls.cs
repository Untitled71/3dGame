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

    public GameObject bulletPrefab;
    public Transform firingPoint;

    public float speed = 5.0f;
    public float jump = 3.0f;
        public bool inair = false;
        public bool doublejumped = false;

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

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        PlayerRb.AddForce(transform.TransformDirection(PlayerDir()).normalized * speed);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown("space") && inair == false)
        {
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);

            inair = true;
            doublejumped = false;

        } else if (Input.GetKeyDown("space") && inair == true && doublejumped == false)
        {
            //Debug.Log("double");
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);

            doublejumped = true;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        //Debug.Log("Bullet Spawned");
    }

    Vector3 PlayerDir()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 pDir = new Vector3(x, 0, z);

            return pDir;
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
