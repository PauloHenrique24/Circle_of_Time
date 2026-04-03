using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Loop")]
    public static float tempo = 30f;  // Tempo até reiniciar o loop
    [SerializeField] private float duracaoTransicao = 3f; // Duração da transição

    [Header("Effects")]
    [SerializeField] private Light2D globalLight;
    private float t = 0f; // tempo de interpolação

    void Start()
    {
        // Luz começa no máximo
        if (globalLight != null)
            globalLight.intensity = 100f;

        tempo = PlayerPrefs.GetFloat("Timer", 30f);

        // Inicia o fade out (escurecer)
        StartCoroutine(FadeOutAndRestart());
    }

    public void PararLoop()
    {
        StopCoroutine(FadeOutAndRestart());
    }

    IEnumerator FadeOutAndRestart()
    {
        // Diminui a luz gradualmente
        while (t < 1f)
        {
            t += Time.deltaTime / duracaoTransicao;
            globalLight.intensity = Mathf.Lerp(100f, 0.8f, t);
            yield return null;
        }

        t = 0f;

        // Espera o restante do tempo antes de reiniciar
        yield return new WaitForSeconds(tempo);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);

        FindFirstObjectByType<SmoothCameraFollow>().Shake();
        while (t < 1f)
        {
            t += Time.deltaTime / duracaoTransicao;
            globalLight.intensity = Mathf.Lerp(.8f, 100f, t);
            yield return null;
        }

        // Reinicia a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
