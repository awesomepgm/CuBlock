using UnityEngine;

public class PlayerPoleMove : MonoBehaviour
{

    public Rigidbody rb;
    public static Vector3 gravity;

    public float forwardForce = 2000f;
    public float sideForce = 500f;

    void Start() {
        rb.AddForce(0,0,forwardForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add forward force
        // rb.AddForce(0,0,forwardForce * Time.deltaTime);

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
        // if (Input.GetKey("space")) 
        // {
        //     Physics.gravity = new Vector3(0, 1.0F, 0);
        // }
    }
}