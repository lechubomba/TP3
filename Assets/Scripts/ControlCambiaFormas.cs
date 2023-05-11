using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCambiaFormas : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 500.0f;
    public float scaleChange = 0.1f;
    public float weightScaleFactor = 1.0f; // Factor to adjust weight based on scale

    private Rigidbody rb;
    private bool isGrounded = true;
    private float scaleValue = 1.0f;
    private MeshCollider meshCollider; // Reference to the MeshCollider component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>(); // Get the MeshCollider component
        meshCollider.convex = true; // Set the collider to use a convex mesh
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
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            scaleValue -= scaleChange;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            UpdateWeight();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    // Updates the weight of the player based on their current scale
    void UpdateWeight()
    {
        float newMass = rb.mass * (scaleValue * weightScaleFactor);
        rb.mass = newMass;
    }
}