using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 8f;
    public float drag = 2f;
    public float tiltAmount = 15f;
    public float tiltSpeed = 5f;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 velocity;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        // acelerar
        velocity += input * acceleration * Time.deltaTime;

        // limitar velocidad máxima
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

        // fricción (para que eventualmente se frene)
        velocity = Vector2.Lerp(velocity, Vector2.zero, drag * Time.deltaTime);

        // mover nave
        transform.position += (Vector3)(velocity * Time.deltaTime);

        float targetTilt = -h * tiltAmount;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetTilt);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            tiltSpeed * Time.deltaTime
        );
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * maxSpeed * Time.fixedDeltaTime);
    }
}
