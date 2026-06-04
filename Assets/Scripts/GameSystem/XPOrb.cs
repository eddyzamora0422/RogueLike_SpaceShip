using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class XPOrb : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddXP(value);
            Destroy(gameObject);
        }
    }
}