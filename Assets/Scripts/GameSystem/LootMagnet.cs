using UnityEngine;

public class LootMagnet : MonoBehaviour
{
    public float magnetRange = 3f;
    public float moveSpeed = 10f;

    Transform player;
    Rigidbody2D rb;

    bool attracted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (!attracted && distance < magnetRange)
        {
            attracted = true;

            // detener física
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
        }

        if (attracted)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
}