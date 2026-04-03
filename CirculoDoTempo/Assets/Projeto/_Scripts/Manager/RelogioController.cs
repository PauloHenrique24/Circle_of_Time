using UnityEngine;

public class RelogioController : MonoBehaviour
{
    private bool relogio;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) relogio = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) relogio = false;
    }

    [SerializeField] private GameObject decisao_obj;

    void Update()
    {
        if (relogio)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                decisao_obj.SetActive(true);
                PlayerController.not_moviment = true;
            }
        }
    }

    [SerializeField] private GameObject final1;
    [SerializeField] private GameObject final2;

    public void Ficar()
    {
        final2.SetActive(true);
        FindFirstObjectByType<GameManager>().PararLoop();
    }
    
    public void Sair()
    {
        final1.SetActive(true);
        FindFirstObjectByType<GameManager>().PararLoop();
    }

}
