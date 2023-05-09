using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItemActivator : MonoBehaviour, IInteractable
{

    [SerializeField] private GroundItem groundItem;
    public void Interact(ControlPersonaje player)
    {
        //player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
