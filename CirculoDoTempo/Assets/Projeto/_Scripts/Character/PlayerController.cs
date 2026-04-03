using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    [SerializeField] private float speed = 3f;
    private Vector3 input;

    private bool _isFacing;
    private bool moving = false;

    private Animator anim;
    private Animator shadow_anim;

    public static bool not_moviment = false;

    [Header("Effects")]
    [SerializeField] private float timerPasso;
    private bool passos_bool;

    void Start()
    {
        anim = GetComponent<Animator>();
        not_moviment = false;
        shadow_anim = gameObject.transform.Find("Shadow").GetComponent<Animator>();
    }

    IEnumerator Passos()
    {
        passos_bool = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timerPasso);
        passos_bool = false;
    }

    void Moviment()
    {
        Vector3 mov = new Vector3(input.x, 0);
        transform.position += mov * speed * Time.deltaTime;

        if (mov.x < 0 && !_isFacing) Flip();
        else if (mov.x > 0 && _isFacing) Flip();

        if (mov.x != 0f) moving = true;
        else moving = false;

        if (mov.x != 0f && !passos_bool) StartCoroutine(Passos());
        else StopCoroutine(Passos());

        anim.SetBool("walk", moving);
        shadow_anim.SetBool("walk", moving);
    }
    
    void Flip()
    {
        _isFacing = !_isFacing;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void FixedUpdate()
    {
        if(!not_moviment)
            Moviment();
    }

    public void OnMov(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private NpcController npc;
    private bool inNpc;

    public void OnInteract(InputValue value)
    {
        if (inNpc)
        {
            npc.StartDialog();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            if (!collision.gameObject.GetComponent<NpcController>().inDialog)
            {
                inNpc = true;
                npc = collision.gameObject.GetComponent<NpcController>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            npc = null;
            not_moviment = false;
            inNpc = false;
        }
    }
}
