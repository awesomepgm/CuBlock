using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody player;
    public float ImpactForce = 250f;
    void OnCollisionEnter (Collision collisionInfo) {
        Vector3 playerForce = new Vector3(0, 1.0F, -2.0F);
        if(collisionInfo.collider.tag == "Obstacle") {
            movement.enabled = false;
            //make an explosion
            collisionInfo.rigidbody.AddForce(Vector3.up * ImpactForce);
            player.AddForce(playerForce * 250);
            
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
