using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [Header("Relogio")]
    [SerializeField] private GameObject relogio_obj;

    void Start()
    {
        if (PlayerPrefs.HasKey("Relogio")) relogio_obj.SetActive(true);
        if (PlayerPrefs.HasKey("Forja")) forja_obj.SetActive(true);
        if (PlayerPrefs.HasKey("RelogioLeo")) relogio_leo.SetActive(false);
        if (PlayerPrefs.HasKey("Marek")) marek.SetActive(false);
    }

    public void Relogio()
    {
        PlayerPrefs.SetInt("Relogio", 1);
    }

    [Header("Marek")]
    [SerializeField] private GameObject forja_obj;
    [SerializeField] private GameObject relogio_leo;

    [SerializeField] private float timerExtra = 5f;
    [SerializeField] private GameObject marek;

    public void Forja()
    {
        PlayerPrefs.SetInt("Forja", 1);
    }

    public void Marek()
    {
        relogio_leo.SetActive(false);
        PlayerPrefs.SetInt("RelogioLeo", 1);
    }

    public void TempoExtra()
    {
        GameManager.tempo += timerExtra;
        PlayerPrefs.SetFloat("Timer", GameManager.tempo);
    }

    public void MarekDesaparece()
    {
        PlayerPrefs.SetInt("Marek", 1);
    }

}
