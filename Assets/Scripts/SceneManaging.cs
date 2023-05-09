using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public GameObject UISelect;

    public GameObject confirmacion;

    public AudioSource buttonPress;

    public void ChangeScene(int sceneIndex)
    {
        PlaySound();
        SceneManager.LoadScene (sceneIndex);
    }

    public void CloseSelect()
    {
        PlaySound();
        UISelect.SetActive(false);
    }

    public void MostrarConfirmacion()
    {
        PlaySound();
        confirmacion.SetActive(true);
    }

    public void EsconderConfirmacion()
    {
        PlaySound();
        confirmacion.SetActive(false);
    }

    public void ResetLevels()
    {
        PlaySound();
        PlayerPrefs.SetInt("levelAt", 1);
        SceneManager.LoadScene(0);
    }

    public void PlaySound()
    {
        buttonPress.Play();
    }
}
