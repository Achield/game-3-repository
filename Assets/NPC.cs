using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody rb;
    public float mySpeed = 1f;
    public GameObject targetBall;
    public GameObject targetPlayer;
    public NPC myScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetBall = GameObject.FindWithTag("Ball");
        targetPlayer = GameObject.FindWithTag("Player");
        myScript = GetComponent<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update not defined yet");
    }

    protected virtual void Move()
    {
        Debug.Log("Move not defined for this object: " + name);
    }

    protected virtual void Kick()
    {
        Debug.Log("Kick not defined for this object: " + name);
    }

    protected virtual void Jump()
    {
        Debug.Log("Jump not defined for this object: " + name);
    }


}
