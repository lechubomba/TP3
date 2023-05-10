using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCambiaFormas : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 500.0f;
    public float scaleChange = 0.1f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private float scaleValue = 1.0f;
    public GameObject Player2;
    public GameObject ladderModel;
    public float transformTime = 1.0f;

    

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    
    

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            scaleValue += scaleChange;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            scaleValue -= scaleChange;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}