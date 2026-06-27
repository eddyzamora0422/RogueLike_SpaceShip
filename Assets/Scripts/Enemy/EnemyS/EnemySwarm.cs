using UnityEngine;

public class EnemySwarm : EnemyBase
{
    protected override void Move()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
