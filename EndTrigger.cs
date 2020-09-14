using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;
    public GameManager gameManager;
    Vector3 vel = new Vector3(0, 0, 0);
    void OnTriggerEnter(Collider triggerInfo) 
    {
        if(triggerInfo.tag != "Obstacle") {
            if(movement.enabled) {
                movement.enabled = false;
                rb.velocity = vel;
                gameManager.CompleteLevel();
            }
        }
    }
}
