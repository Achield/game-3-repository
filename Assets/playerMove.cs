using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool debugs = true;
    Rigidbody rb;
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 wishDir = transform.TransformDirection(Direction(debugs));
        rb.AddForce(wishDir * speed);
    }

    Vector3 Direction(bool debugs)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        if (debugs)
        {
            Vector3 temp = transform.TransformDirection(dir);
            Debug.DrawRay(transform.position, rb.velocity, Color.yellow);
            // Debug.Log("vector: " + dir);
            Debug.DrawRay(transform.position, temp * 2f, Color.white);
            Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.green);
            Debug.DrawRay(transform.position + Vector3.up, transform.right, Color.green);
        }
        return dir;
    }

}
