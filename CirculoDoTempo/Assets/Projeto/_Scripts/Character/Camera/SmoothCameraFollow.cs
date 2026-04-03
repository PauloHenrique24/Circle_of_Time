using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target; // Jogador
    [SerializeField] private float smoothSpeed = 5f; // Suavidade do movimento
    [SerializeField] private Vector3 offset; // Distância da câmera em relação ao player

    [Header("Shake Settings")]
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeMagnitude = 0.3f;

    private float shakeTimer = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        // Segue o jogador suavemente
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Aplica o Camera Shake
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            transform.position += (Vector3)Random.insideUnitCircle * shakeMagnitude;

            if (shakeTimer <= 0)
                transform.position = new Vector3(transform.position.x, transform.position.y, offset.z); // Garante o z fixo
        }
    }

    /// <summary>
    /// Ativa o efeito de tremor da câmera.
    /// </summary>
    public void Shake(float intensity, float duration)
    {
        shakeMagnitude = intensity;
        shakeDuration = duration;
        shakeTimer = duration;
    }

    // Método alternativo para ativar shake com valores padrão
    public void Shake()
    {
        shakeTimer = shakeDuration;
    }
}
