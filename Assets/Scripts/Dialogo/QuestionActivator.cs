using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestionObject questionObject;
    [SerializeField] private GameObject[] toggleObject;
    public bool isEndQuestion = false;

    public GameObject[] Objetos => toggleObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControlPersonaje player))
        {
            player.Interactable = this;
            player.QuestionUI.getComponentofObject(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControlPersonaje player))
        {
            if (player.Interactable is QuestionActivator questionActivator && questionActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(ControlPersonaje player)
    {
        player.QuestionUI.ShowQuestion(questionObject);
        player.QuestionUI.CopyObject(questionObject, isEndQuestion, toggleObject);
    }
}
