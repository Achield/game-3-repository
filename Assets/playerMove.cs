using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool debugs = true;
    Rigidbody rb;
    Collider col;
    public float speed;
    public float jump;
    public bool isGrounded;

    public float playerHeight;
    public float stickyMargin = .1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        speed = 10f;
        jump = 12f;
        //something that calculates the player height here
        playerHeight = col.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
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

        //isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight/2)+stickyMargin);
        Vector3 playerPos = col.bounds.center;
        isGrounded = Physics.Raycast(col.bounds.center, Vector3.down, (playerHeight/2)+stickyMargin);
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
