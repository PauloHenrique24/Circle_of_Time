using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DialogoItem", menuName = "Scriptable Objects/DialogoItem")]
public class DialogoItem : ScriptableObject
{
    public string nome;
    public List<Dialogos> dialogos;

    public string save;
}

[System.Serializable]
public struct Dialogos
{
    [TextArea]
    public string dialogo;
    public UnityEvent evento;
    public string desbloquear;
}
