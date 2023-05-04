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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }

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
