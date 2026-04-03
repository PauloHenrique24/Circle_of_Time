using UnityEngine;

public class ParallaxEffect2D : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField, Range(0f, 1f)] private float parallaxFactor = 0.5f;
    [SerializeField] private bool lockY = true;

    private Vector3 lastCameraPosition;
    private float startZ;

    private void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;
        startZ = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Movimento horizontal e opcionalmente vertical
        float moveX = deltaMovement.x * parallaxFactor;
        float moveY = lockY ? 0 : deltaMovement.y * parallaxFactor;

        transform.position += new Vector3(moveX, moveY, 0);

        lastCameraPosition = cameraTransform.position;
    }
}
