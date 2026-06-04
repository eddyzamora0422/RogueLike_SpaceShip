using UnityEngine;

public class DroneFollower : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;
    public float followSpeed = 5f;

    void Update()
    {
        Vector3 targetPos = player.position + (Vector3)offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }
}