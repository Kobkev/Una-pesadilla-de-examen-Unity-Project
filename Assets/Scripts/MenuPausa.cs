using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausaUI;
    [SerializeField] private GameObject ConfirmacionMenu;
    [SerializeField] private GameObject ConfirmacionCerrar;
    [SerializeField] private GameObject Opciones;
    [SerializeField] private bool estaPausado;
    private bool estadoAudio;

    public AudioSource buttonPress;

    private AudioSource[] _audioSources;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                DesactivarMenu();
            }
            else
            {
                ActivarMenu();
            }
        }
    }

    private void ActivarMenu()
    {
        estaPausado = true;
        ControlGlobal.pausaAbierto = true;
        Time.timeScale = 0f;
        estadoAudio = true;
        controlAudio();
        menuPausaUI.SetActive(true);
    }

    private void DesactivarMenu()
    {

        estaPausado = false;
        Time.timeScale = 1f;
        estadoAudio = false;
        controlAudio();
        menuPausaUI.SetActive(false);
        ConfirmacionMenu.SetActive(false);
        ConfirmacionCerrar.SetActive(false);
        Opciones.SetActive(false);
        ControlGlobal.pausaAbierto = false;

    }

    public void BotonMenuP()
    {
        buttonPress.Play();
        ConfirmacionMenu.SetActive(true);
        ConfirmacionCerrar.SetActive(false);
    }

    public void BotonCerrar()
    {
        buttonPress.Play();
        ConfirmacionMenu.SetActive(false);
        ConfirmacionCerrar.SetActive(true);
    }

    public void botonResumir()
    {
        buttonPress.Play();
        DesactivarMenu();
    }

    public void botonOptiones()
    {
        buttonPress.Play();
        menuPausaUI.SetActive(false);
        Opciones.SetActive(true);
    }
    public void opcionSIMenu()
    {
        buttonPress.Play();
        ControlGlobal.pausaAbierto = false;
        estadoAudio = false;
        estaPausado = false;
        SceneManager.LoadScene(0);
    }

    public void opcionNOMenu()
    {
        buttonPress.Play();
        ConfirmacionMenu.SetActive(false);
    }

    public void opcionSICerrar()
    {
        buttonPress.Play();
        Application.Quit();
    }

    public void opcionNOCerrar()
    {
        buttonPress.Play();
        ConfirmacionCerrar.SetActive(false);
    }

    private void controlAudio()
    {
        var temp = GameObject.FindGameObjectsWithTag("Ambientacion");
        _audioSources = new AudioSource[temp.Length];

        for (int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = temp[i].GetComponentInChildren<AudioSource>();
            if (estadoAudio)
            {
                _audioSources[i].Pause();
            }
            else
            {
                _audioSources[i].UnPause();
            }
        }
    }

}
