using UnityEngine;

public class JumpPad : MonoBehaviour {
    public Rigidbody player;
    public float JumpForce = 250f;
    void OnTriggerEnter (Collider triggerInfo) {
        Vector3 playerForce = new Vector3(0, 1.0F, 0);
        if(triggerInfo.tag == "Player") {
            //Boost the player
            player.AddForce(playerForce * JumpForce);
        }
    }
}
