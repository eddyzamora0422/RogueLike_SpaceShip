using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;
    public float invulnerabilityTime = 1.5f;
    bool isInvulnerable = false;
    SpriteRenderer[] sprites;

    private Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        sprites = GetComponentsInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        currentHealth -= damage;

        Debug.Log("Vida del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    void Die()
    {
        animator.SetBool("LIVE", false);
        Debug.Log("El jugador murió");
        Destroy(gameObject, 3f);
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float timer = 0;

        while (timer < invulnerabilityTime)
        {
            foreach (SpriteRenderer s in sprites)
            {
                s.enabled = !s.enabled;
            }

            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }

        foreach (SpriteRenderer s in sprites)
        {
            s.enabled = true;
        }

        isInvulnerable = false;
    }
}