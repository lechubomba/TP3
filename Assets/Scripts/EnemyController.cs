using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 2f;
    public float distance = 4f;
    public float pushForce = 5f; 
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

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            Vector3 pushDirection = collision.gameObject.transform.position - transform.position;
            pushDirection = pushDirection.normalized;

            
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}