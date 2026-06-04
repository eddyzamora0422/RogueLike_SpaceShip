using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float duration;
    float magnitude;

    public Vector3 shakeOffset { get; private set; }

    void Update()
    {
        if (duration > 0)
        {
            shakeOffset = Random.insideUnitCircle * magnitude;

            duration -= Time.deltaTime;
        }
        else
        {
            shakeOffset = Vector3.zero;
        }
    }

    public void Shake(float shakeDuration, float shakeMagnitude)
    {
        duration = shakeDuration;
        magnitude = shakeMagnitude;
    }
}