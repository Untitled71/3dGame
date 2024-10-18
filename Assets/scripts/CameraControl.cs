using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    Vector3 Dirlook;
    public GameObject myCam;

    public float lookSpeed = 100;
    public float camLock = 90f;
    float onStartTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onStartTimer += Time.deltaTime;

        Dirlook += Deltalook() * lookSpeed * Time.deltaTime;
        Dirlook.y = Mathf.Clamp(Dirlook.y, -camLock, camLock);
        
        transform.rotation = Quaternion.Euler(0f, Dirlook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-Dirlook.y, Dirlook.x, 0f);
    }

    Vector3 Deltalook()
    {
        Vector3 currentLook;
        float rotY = Input.GetAxisRaw("Mouse Y");
        float rotX = Input.GetAxisRaw("Mouse X");
        currentLook = new Vector3 (rotX, rotY, 0);

        return currentLook;
    }
}
