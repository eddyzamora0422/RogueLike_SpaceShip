using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public float launchForce = 4f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        rb.AddForce(randomDirection * launchForce, ForceMode2D.Impulse);
    }
}