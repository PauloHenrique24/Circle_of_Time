using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager current { get; set; }

    void Awake()
    {
        current = current ? current : this;
    }

    [Header("Nome")]
    [SerializeField] private TextMeshProUGUI txt_nome;

    public void NomeTxt(string nome)
    {
        txt_nome.gameObject.SetActive(true);
        txt_nome.text = nome;
    }

    public void DesableNomeTxt()
    {
        if (txt_nome != null)
            txt_nome.gameObject.GetComponent<Animator>().SetTrigger("close");
    }
    
    [Header("Dialogo")]
    [SerializeField] private GameObject dialogo_obj;
    [SerializeField] private TextMeshProUGUI txt_dialogo;

    public TextMeshProUGUI DialogoStart()
    {
        dialogo_obj.SetActive(true);
        return txt_dialogo;
    }

    public void CloseDialogo()
    {
        dialogo_obj.GetComponent<Animator>().SetTrigger("close");
    }
}
