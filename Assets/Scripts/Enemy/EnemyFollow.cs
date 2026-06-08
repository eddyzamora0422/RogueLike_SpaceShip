using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 2f;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
                player = p.transform;

        }
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
