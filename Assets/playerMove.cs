using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool debugs = true;
    Rigidbody rb;
    public float speed;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        jump = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(rb.velocity.x, jump * 30f, rb.velocity.z));
        }
    }
    void FixedUpdate()
    {
        Vector3 wishDir = transform.TransformDirection(Direction(debugs));
        //rb.AddForce(wishDir * speed);
        //rb.velocity = (wishDir * speed * Time.deltaTime * 50f);
        rb.velocity = (wishDir);
    }

    Vector3 Direction(bool debugs)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h * speed, rb.velocity.y, v * speed);

        if (debugs)
        {
            Vector3 temp = transform.TransformDirection(dir);
            Debug.DrawRay(transform.position, rb.velocity, Color.yellow);
            Debug.Log("vector: " + dir);
            Debug.DrawRay(transform.position, temp * 2f, Color.white);
            Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.green);
            Debug.DrawRay(transform.position + Vector3.up, transform.right, Color.green);
        }
        return dir;
    }

}
