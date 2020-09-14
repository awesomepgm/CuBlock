using UnityEngine;

public class PlayerPoleCol : MonoBehaviour
{
    public PlayerPoleMove move;
    public Rigidbody player;
    public float ImpactForce = 250f;
    void OnCollisionEnter (Collision collisionInfo) {
        Vector3 playerForce = new Vector3(0, 1.0F, -2.0F);
        if(collisionInfo.collider.tag == "Obstacle") {
            move.enabled = false;
            //make an explosion
            collisionInfo.rigidbody.AddForce(Vector3.up * ImpactForce);
            player.AddForce(playerForce * 250);
            
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
