using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public Transform box;
    public float lowerBound = 1.5f;
    public float upperBound = 10f;
    public float moveRate = 0.1f;
    public float direction = 1f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (box.position.y >= upperBound)
        {
            direction = -1.0f;
        }
        if (box.position.y <= lowerBound)
        {
            direction = 1.0f;
        }
        box.position = new Vector3(box.position.x, box.position.y, box.position.z) + new Vector3(0,moveRate*direction,0);
    }
}
