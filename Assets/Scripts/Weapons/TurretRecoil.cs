using UnityEngine;

public class TurretRecoil : MonoBehaviour
{
    public float recoilDistance = 0.15f;
    public float recoilSpeed = 10f;

    Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            originalLocalPosition,
            recoilSpeed * Time.deltaTime
        );
    }

    public void ApplyRecoil()
    {
        transform.localPosition -= transform.up * recoilDistance;
    }
}