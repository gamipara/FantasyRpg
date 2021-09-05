using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpCameraController : MonoBehaviour
{
    public float xRotationspeed;
    public float yRotationspeed;
    public Transform Target;
    float mouseX, mouseY;
    public float yminclamp, ymaxclamp;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * xRotationspeed;
        mouseY -= Input.GetAxis("Mouse Y") * yRotationspeed;
        mouseY = Mathf.Clamp(mouseY, yminclamp, ymaxclamp);
        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        
    }
}
