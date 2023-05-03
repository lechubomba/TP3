using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Inverted : Controller_Player
{
    private Vector3 surfaceNormal = Vector3.up;
    private Vector3 lastSurfaceNormal = Vector3.up;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1f))
        {

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;


            surfaceNormal = hit.normal;
            if (surfaceNormal != lastSurfaceNormal)
            {
                transform.position = hit.point + surfaceNormal * 0.5f;
            }

            lastSurfaceNormal = surfaceNormal;
        }
    }


    public override bool IsOnSomething()
    {
        bool isOnSomething = Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.up, out downHit, Quaternion.identity, downDistanceRay);

        if (isOnSomething)
        {
            surfaceNormal = downHit.normal;
        }

        return isOnSomething;
    }


    public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(surfaceNormal * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
