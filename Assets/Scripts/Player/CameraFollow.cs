using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 5f;

    public float lookAheadDistance = 2f;
    public float maxOffset = 4f;

    public float movementLookAhead = 1.5f;

    Camera cam;

    Vector3 lastPlayerPosition;

    CameraShake shake;

    void Start()
    {
        cam = Camera.main;
        lastPlayerPosition = player.position;

        shake = GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if (player == null) return;

        // mouse look ahead
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 mouseDirection = mousePos - player.position;
        mouseDirection = Vector3.ClampMagnitude(mouseDirection, maxOffset);

        Vector3 mouseOffset = mouseDirection.normalized * lookAheadDistance;

        // movimiento del jugador
        Vector3 movement = player.position - lastPlayerPosition;

        Vector3 movementOffset = movement * movementLookAhead;

        lastPlayerPosition = player.position;

        Vector3 targetPos = player.position + mouseOffset + movementOffset;

        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos + shake.shakeOffset,
            smoothSpeed * Time.deltaTime
        );
    }
}