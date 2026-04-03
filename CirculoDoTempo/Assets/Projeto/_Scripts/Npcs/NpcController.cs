using System.Collections;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [Header("Npc")]
    [SerializeField] private string nome_npc;
    [SerializeField] private GameObject alert_obj;

    private bool isFacing;

    [Header("Dialogo")]
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private DialogoItem itemDialogo;

    [HideInInspector] public bool inDialog;
    private int indice;
    private TextMeshProUGUI text_dialogo;

    void Flip()
    {
        isFacing = !isFacing;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void StartDialog()
    {
        if (!inDialog)
        {
            if (itemDialogo.dialogos[indice].desbloquear == "" || PlayerPrefs.HasKey(itemDialogo.dialogos[indice].desbloquear))
            {
                PlayerController.not_moviment = true;

                inDialog = true;
                particles.Stop();
                alert_obj.SetActive(false);

                text_dialogo = InterfaceManager.current.DialogoStart();
                if (PlayerPrefs.HasKey(itemDialogo.save))
                {
                    indice = PlayerPrefs.GetInt(itemDialogo.save);
                }

                StartCoroutine(Dialogo());
            }
        }
    }

    void CloseDialogo()
    {
        InterfaceManager.current.CloseDialogo();
        PlayerController.not_moviment = false;

        if(indice < itemDialogo.dialogos.Count - 1)
        {
            indice++;
            PlayerPrefs.SetInt(itemDialogo.save, indice);
        }
    }

    IEnumerator Dialogo()
    {
        text_dialogo.text = "";
        foreach (var c in itemDialogo.dialogos[indice].dialogo)
        {
            text_dialogo.text += c;
            yield return new WaitForSeconds(0.08f);
        }

        itemDialogo.dialogos[indice].evento?.Invoke();

        yield return new WaitForSeconds(1f);
        PlayerController.not_moviment = false;
        CloseDialogo();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!inDialog)
                alert_obj.SetActive(true);
                
            InterfaceManager.current.NomeTxt(nome_npc);

            if (collision.gameObject.transform.position.x < transform.position.x && !isFacing) Flip();
            else if (collision.gameObject.transform.position.x > transform.position.x && isFacing) Flip();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            alert_obj.SetActive(false);
            InterfaceManager.current.DesableNomeTxt();
        }
    }
}
