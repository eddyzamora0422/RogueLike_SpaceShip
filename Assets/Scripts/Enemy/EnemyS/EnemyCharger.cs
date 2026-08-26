using UnityEngine;

public enum EstadoDeCharger { Persiguiendo, Preparando, Dashing, Recovering }

public class EnemyCharger : EnemyBase
{
    [Header("Seguimiento")]
    public float maxSpeed = 6f;
    public float acceleration = 2f;
    public float stoppingDistance = 3f;

    [Header("Preparacion")]
    public float preparingTime = 1.5f;
    public float preparingSpeedMultiplier = 0.4f;

    [Header("Dash")]
    public float dashSpeed = 15;
    public float dashOvershoot = 3f; // metros extra pasando al jugador

    [Header("Recuperacion")]
    public float deceleration = 0f;
    public float rotationSpeed = 180;

    float currentSpeed = 0f;
    float currentDashSpeed = 0f;
    float timePreparing = 0f;
    Vector3 dashDir;
    Vector3 dashTarget;

    EstadoDeCharger estadoActual;

    protected override void Start()
    {
        base.Start();
        estadoActual = EstadoDeCharger.Persiguiendo;
    }

    protected override void Move()
    {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        switch (estadoActual)
        {
            case EstadoDeCharger.Persiguiendo:
                // acelera progresivamente hasta maxSpeed
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);

                if (distance > stoppingDistance)
                    transform.position += direction.normalized * currentSpeed * Time.deltaTime;
                else
                {
                    estadoActual = EstadoDeCharger.Preparando;
                    timePreparing = 0f;
                }

                RotateTowards(direction);
                break;

            case EstadoDeCharger.Preparando:
                // reduce velocidad progresivamente
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed * preparingSpeedMultiplier, acceleration * Time.deltaTime);

                if (distance > stoppingDistance)
                    transform.position += direction.normalized * currentSpeed * Time.deltaTime;

                // sigue actualizando el objetivo del dash
                dashDir = direction.normalized;
                dashTarget = player.position + dashDir * dashOvershoot;

                timePreparing += Time.deltaTime;
                if (timePreparing >= preparingTime)
                {
                    timePreparing = 0f;
                    currentDashSpeed = dashSpeed;
                    estadoActual = EstadoDeCharger.Dashing;
                }

                RotateTowards(direction);
                break;

            case EstadoDeCharger.Dashing:
                print("Dash");
                transform.position += dashDir * currentDashSpeed * Time.deltaTime;

                // ✅ sin .normalized, evita el problema de vector cercano a cero
                bool pasóElTarget = Vector3.Dot(dashDir, dashTarget - transform.position) < 0;
                if (pasóElTarget)
                    estadoActual = EstadoDeCharger.Recovering;
                break;

            case EstadoDeCharger.Recovering:
                print("Recuperar");
                // frena progresivamente manteniendo la dirección del dash
                currentDashSpeed = Mathf.MoveTowards(currentDashSpeed, 0f, deceleration * Time.deltaTime);
                transform.position += dashDir * currentDashSpeed * Time.deltaTime;

                // rota progresivamente hacia el jugador
                RotateTowards(direction);

                if (currentDashSpeed <= 0.1f)
                {
                    currentSpeed = 0f;
                    estadoActual = EstadoDeCharger.Persiguiendo;
                }
                break;
        }
    }

    private void RotateTowards(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        // rota progresivamente, no instantáneo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}