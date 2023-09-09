using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform body;
    private float xRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        body.transform.Rotate(Vector3.up * mouseX);//<-----------For Y Rotation or Side Look.

        xRotation -= mouseY; //Towards bottom its -ve (0 to -1) so the xRotation increases +vely [xRotation-(-mouseY)] <---> Towards top its +ve (0 to +1) so the xRotation increases -vely [xRotation-(mouseY)]
        Debug.Log(xRotation);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //<---Used to restrict the camera rotate after 90 degree or -90 degree rotation, which makes a realistic feel.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //<-----------For X Rotation or UpDown Look.



        //<------------Practice area----------(Start)-->
        /* float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

         body.Rotate(Vector3.up * mouseX);

         xRotation -= mouseY;
         xRotation = Mathf.Clamp(xRotation, -90f, 90f);

         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);*/
    }
}
