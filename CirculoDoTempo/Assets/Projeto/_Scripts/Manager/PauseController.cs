using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool pause;
    [SerializeField] private GameObject pause_obj;

    public void OnPause(InputValue value)
    {
        pause = !pause;
        pause_obj.SetActive(pause);

        if (pause) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    public void Despause()
    {
        pause = false;
        pause_obj.SetActive(false);

        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
