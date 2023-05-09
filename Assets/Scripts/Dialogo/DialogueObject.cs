using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    //[TextArea] private string[] name;
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
