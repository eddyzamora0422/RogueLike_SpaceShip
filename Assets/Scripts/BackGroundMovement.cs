using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    private Transform jugadorRB;

    private Vector3 lastPlayerPosition;


    private void Awake()
    {
        material = GetComponentInChildren<SpriteRenderer>().material;
        jugadorRB = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = jugadorRB.position;
    }

    private void Update()
    {
        
        if (jugadorRB == null) {
            return;
        }

        Vector3 movement = jugadorRB.position - lastPlayerPosition;

        offset = (Vector2)movement * velocidadMovimiento;

        material.mainTextureOffset += offset;

        lastPlayerPosition = jugadorRB.position;
    }
}
