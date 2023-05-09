using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionMenuPrincipal : MonoBehaviour
{
    public AudioSource buttonPress;

    public GameObject pantallaOpciones;

    public GameObject pantallaSelecciona;

    public GameObject pantallaCreditos;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        PlaySound();
        SceneManager.LoadScene(1);
    }

    public void SelectLevel()
    {
        PlaySound();
        pantallaSelecciona.SetActive(true);
    }

    public void SalirJuego()
    {
        PlaySound();
        Application.Quit();
    }

    public void Opciones()
    {
        PlaySound();
        pantallaOpciones.SetActive(true);
    }

    public void Creditos()
    {
        PlaySound();
        pantallaCreditos.SetActive(true);
    }

    public void PlaySound()
    {
        buttonPress.Play();
    }
}
