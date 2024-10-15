using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{

    Vector3 myLook;
    float lookSpeed = 200f;
    public Camera myCam;
    public float camLock = 90f;

    // This timer counts up from start to ease camLook speed at start
    float onStartTimer;


    private void Awake()
    {
        // Lock the mouse to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myLook = transform.localEulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onStartTimer += Time.deltaTime;
        // First we normalize look and speed relative to framerate
        myLook += DeltaLook() * lookSpeed * Time.deltaTime;
        myLook.y = Mathf.Clamp(myLook.y, -camLock, camLock);
        // Next we apply the rotation to the player's Y axis
        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        // Now we rotate the camera along its x axis, and also the same rotation as the player on Y
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);

        //Debug.DrawRay(myCam, transform.position, )
    }

    // going to calculate the difference in mouse position on screen relative to the previous frame 
    Vector3 DeltaLook()
    {
        Vector3 dLook;
        float roY = Input.GetAxisRaw("Mouse Y");
        float roX = Input.GetAxisRaw("Mouse X");
        dLook = new Vector3(roX, roY, 0);

        if (dLook != Vector3.zero) { Debug.Log("Delta look: " + dLook); }

        if (onStartTimer < 1f) // This smooths out camera jump on start of game
        {
            dLook = Vector3.ClampMagnitude(dLook, onStartTimer);
        }

        return dLook;
    }

}
