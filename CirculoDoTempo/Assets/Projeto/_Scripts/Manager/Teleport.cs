using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private string nome;
    [SerializeField] private GameObject camera_obj;
    [SerializeField] private Transform target;

    private bool coll;
    private GameObject collisionObj;

    void Update()
    {
        if (coll)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindAnyObjectByType<SmoothCameraFollow>().target = null;
                collisionObj.transform.position = target.position;
                camera_obj.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InterfaceManager.current.NomeTxt(nome);
            collisionObj = collision.gameObject;
            coll = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InterfaceManager.current.DesableNomeTxt();
            coll = false;
        }
    }
}
