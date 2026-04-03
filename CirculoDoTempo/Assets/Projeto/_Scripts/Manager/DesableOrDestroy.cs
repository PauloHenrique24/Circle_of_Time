using UnityEngine;

public class DesableOrDestroy : MonoBehaviour
{
    public void Desable()
    {
        gameObject.SetActive(false);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
