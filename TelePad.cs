using UnityEngine;

public class TelePad : MonoBehaviour {
    public Rigidbody player;
    public Transform cam;
    public FollowPlayer offset;
    public float target_y = 10f;
    public float rotateRate = 1f;
    private float newZ=0f;
    private bool rotating = false;
    private float direction;
    private Vector3 nextZ;
    private Vector3 change_z;
    private void Update() {
        CamRotate();
    }
    private void OnTriggerEnter (Collider triggerInfo) 
    {
        if(triggerInfo.tag == "Player") {
            offset.offset = new Vector3(offset.offset.x,offset.offset.y*-1,offset.offset.z);
            player.position = new Vector3(player.position.x, target_y, player.position.z);
            Physics.gravity = new Vector3(0f, Physics.gravity.y*-1, 0f);
            cam.position = new Vector3(player.position.x, player.position.y, player.position.z) + new Vector3(offset.offset.x,offset.offset.y,offset.offset.z);
            if(cam.eulerAngles.z == 180) {
                newZ = 0f;
                rotating = true;
            } else if (cam.eulerAngles.z == 0) {
                newZ = 180f;
                rotating = true;
            }
        }
    }
    private void CamRotate() 
    {
        if (rotating) {
            if ((int)cam.eulerAngles.z != (int)newZ) {
                if (cam.eulerAngles.z > newZ) {
                    direction = -1f;
                } else {
                    direction = 1f;
                }
                change_z = new Vector3(0f,0f,rotateRate*direction);
                nextZ = new Vector3(cam.eulerAngles.x,cam.eulerAngles.y,cam.eulerAngles.z) + change_z*Time.deltaTime;
                if (nextZ.z >= 180) {
                    cam.eulerAngles = new Vector3(cam.eulerAngles.x,cam.eulerAngles.y,180);
                } else if (nextZ.z <= 0) {
                    cam.eulerAngles = new Vector3(cam.eulerAngles.x,cam.eulerAngles.y,0);
                } else {
                    cam.Rotate(change_z*Time.deltaTime);
                }
            } else {
                rotating = false;
            }
        }
    }
}