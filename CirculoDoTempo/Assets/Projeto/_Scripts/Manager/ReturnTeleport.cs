using UnityEngine;

public class ReturnTeleport : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject camera_obj;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindFirstObjectByType<SmoothCameraFollow>().target = collision.gameObject.transform;
            collision.gameObject.transform.position = target.position;
            camera_obj.SetActive(false);
        }
    }
}
