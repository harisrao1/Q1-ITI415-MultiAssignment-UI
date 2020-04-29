using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 0.2f;
    public float MouseLookSens = 5;
    public float UpDownSens = 2;
    float move = 0.1f;

    private float X = 0;
    private float Y = 0;

    void Start()
    {
        // Camera.main.transform.Rotate(30, 132.5, 0);
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            X = X + Input.GetAxis("Mouse X") * MouseLookSens;
            Y = Y + Input.GetAxis("Mouse Y") * MouseLookSens;
            Y = Mathf.Clamp(Y, -90, 90);


            transform.localRotation = Quaternion.AngleAxis(X, Vector3.up);
            transform.localRotation = transform.localRotation * Quaternion.AngleAxis(Y, Vector3.left);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 2f * move;
        }
        else
        {
            movespeed = 1f *move;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * movespeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * movespeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + transform.up * UpDownSens * move;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position - transform.up * UpDownSens * move;
        }
       
    }
}
