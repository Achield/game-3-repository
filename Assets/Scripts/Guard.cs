using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : NPC
{

    Vector3 rayDir;

    // Start is called before the first frame update
    void Start()
    {
        targetBall = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BallListener();
        if (targetBall != null)
        {
            //Vector3.wishDir = transform.InverseTransformDirection(Vector3.forward * 250f);
            //rb.AddForce(wishDir);
        }
    }

    void BallListener()
    {
        Vector3 rayDir = Vector3.forward * 10f;
        rayDir = transform.InverseTransformDirection(rayDir);
        RaycastHit hit;


        Debug.DrawRay(transform.position, rayDir, Color.white);
        //if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10f))
        //{
        //    Debug.Log("ray cast name: " + hit.collider.gameObject.name);
        //    Debug.Log("ray cast position: " + hit.point);
        //}

        if (Physics.SphereCast(transform.position, 2f, rayDir, out hit))      // replace 2f with CastRadius
        {
            Debug.Log("sphere cast name: " + hit.collider.gameObject.name);
            Debug.Log("sphere cast position: " + hit.point);
            if (hit.collider.gameObject.tag == "Ball")
            {
                targetBall = hit.collider.gameObject;
            }
            else { targetBall = null; }
        }
        else { targetBall = null; }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 increment = rayDir.normalized;
        for (int i = 0; i < 10; i++)
        {
            Gizmos.DrawWireSphere((transform.position + (rayDir / i)), 2f);
        }

    }

}
