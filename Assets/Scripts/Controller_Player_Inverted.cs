using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Inverted : Controller_Player
{
    public override void FixedUpdate()
    {
        base.rb.AddForce(new Vector3(0, 30f, 0));
        base.FixedUpdate();
    }

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.up, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }
    /*El siguiente codigo permite que el personaje verde rompa las leyes de la gravedad y se adhiera a cualquier superficie que toque*/
    /*
      public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
                StartCoroutine(GroundSnap());
            }
        }
    }

    private IEnumerator GroundSnap()
    {
        // Wait for a short time to allow the player to leave the ground
        yield return new WaitForSeconds(0.1f);

        // Check if the player is above an object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.5f))
        {
            // Align the player's rotation to the surface normal
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            // Snap the player to the surface
            transform.position = hit.point + hit.normal * 0.5f;
        }
    }
    
     */
}
