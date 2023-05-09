using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCerrar : MonoBehaviour
{
    public GameObject UI;

    public AudioSource buttonPress;

    public void ButtonToggle()
    {
        buttonPress.Play();
        UI.SetActive(false);
    }
}
