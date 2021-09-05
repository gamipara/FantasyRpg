using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpCharacterMovement : MonoBehaviour
{
    public float speed;
    float refsmotthtime;
    public float smotthtime;
    public Transform Camera;
    bool grounded;
   
    public float radius;
    public LayerMask Ground;
    public Transform groundcheck;
    public float JumpForce;
   

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundcheck.position, radius, Ground);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       
        Vector3 MovePos = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        if (MovePos.magnitude > 0.01f && grounded)
        {
            float Direction = Mathf.Atan2(MovePos.x, MovePos.y) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float lookdirection = Mathf.SmoothDamp(transform.eulerAngles.y, Direction, ref refsmotthtime, smotthtime);
            transform.rotation = Quaternion.Euler(0f, lookdirection, 0f);
           
            transform.Translate(MovePos, Space.Self);
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(0, JumpForce, 0);
            }
        }
      
    }
}
