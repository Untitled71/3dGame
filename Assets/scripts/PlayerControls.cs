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

    public GameObject bulletPrefab;
    public Transform firingPoint;

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
        Debug.Log(speed);
        PlayerRb.AddForce(transform.TransformDirection(PlayerDir()).normalized * speed);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Shot activated");
            Shoot();
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


}
