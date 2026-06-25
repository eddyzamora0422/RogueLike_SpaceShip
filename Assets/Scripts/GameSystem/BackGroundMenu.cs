using UnityEngine;

public class BackGroundMenu : MonoBehaviour
{
    private Vector2 offset;

    private Material material;

    public float velocidadFondo;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = Vector2.down * velocidadFondo;
        material.mainTextureOffset += offset;
    }

}
