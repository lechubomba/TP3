using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 4f;
    private Rigidbody rb;
    private float startingX;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingX = transform.position.x;
    }

    void FixedUpdate()
    {
        // Move the enemy left and right
        if (movingRight)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0f);
            if (transform.position.x >= startingX + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0f);
            if (transform.position.x <= startingX - distance)
            {
                movingRight = true;
            }
        }
    }
}