using UnityEngine;

public class PlayerMoveBoost : MonoBehaviour
{

    public Rigidbody rb;
    public Camera cam;

    public float forwardForce = 4500f;
    public float boostForce = 2000f;
    public float sideForce = 120f;
    public float fovChange = 1.0F;

    // void Start() {
    //     rb.AddForce(0,0,forwardForce);
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add forward force
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
        if ((cam.fieldOfView > 60) && !Input.GetKey("w"))
        {
            cam.fieldOfView = cam.fieldOfView - fovChange;
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0,0,boostForce * Time.deltaTime);
            if (cam.fieldOfView < 70) 
            {
                cam.fieldOfView = cam.fieldOfView + fovChange;
            }
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f) 
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if (rb.position.y > 11f) 
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        // if (Input.GetKey("space")) 
        // {
        //     Physics.gravity = new Vector3(0, 1.0F, 0);
        // }
    }
}