using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    //[SerializeField] private GameObject dialogueButton;
    [SerializeField] private TMP_Text dialogueText;
    //[SerializeField] private TMP_Text dialogueName;
    public bool IsOpen { get; private set; }
    private TypeWriterEffect typewriterEffect;

    void Start()
    {
        typewriterEffect = GetComponent<TypeWriterEffect>();

        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        /* var box = gameObject.GetComponent<BoxCollider>();
        box.enabled = false; */
        ControlGlobal.ButtonsEnabled = false;
        StartCoroutine(StepThroughtDialogue(dialogueObject));
    }

    private IEnumerator StepThroughtDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            //yield return typewriterEffect.Run(dialogue, dialogueText);
            yield return RunTypingEffect(dialogue);
            dialogueText.text = dialogue;
            yield return null;
            yield return new WaitUntil(() => Input.GetButtonDown("Action") || Input.GetMouseButtonDown(0));
        }

        CloseDialogueBox();
        ControlGlobal.ButtonsEnabled = true;
        /* var box = gameObject.GetComponent<BoxCollider>();
        box.enabled = true; */
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, dialogueText);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetButtonDown("Action") || Input.GetMouseButtonDown(0))
            {
                typewriterEffect.Stop();
            }
        }
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        ControlGlobal.ButtonsEnabled = true;
    }
}
