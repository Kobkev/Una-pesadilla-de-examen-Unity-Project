using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    private bool _canUseDialogue;

    /* private void Update()
    {
        if (_canUseDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _canUseDialogue = false;
                // your code          
            }
        }
    } */

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControlPersonaje player))
        {
            player.Interactable = this;
            //_canUseDialogue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControlPersonaje player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
                //_canUseDialogue = false;
            }
        }
    }

    public void Interact(ControlPersonaje player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
