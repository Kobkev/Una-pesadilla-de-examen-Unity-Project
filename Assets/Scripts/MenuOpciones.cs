using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{

    public TMPro.TMP_Dropdown resolutionDropdown;

    public GameObject menuPausa;
    public GameObject Opciones;

    public AudioSource buttonPress;
    Resolution[] resolutions;

    //[SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;
    public AudioMixer audioMixer;

    void Start()
    {
        /* CargarValores(); */

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NumeroVolumen(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void FijarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    /* public void GuardarVolumen()
    {
        float valorVolumen = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", valorVolumen);
        CargarValores();
    }

    private void CargarValores()
    {
        float valorVolumen = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = valorVolumen;
        AudioListener.volume = valorVolumen;
    } */

    public void FijarCalidad(int calidadIndice)
    {
        QualitySettings.SetQualityLevel(calidadIndice);
    }

    public void FijarPantallaCompleta(bool esCompleta)
    {
        Screen.fullScreen = esCompleta;
    }

    public void botonRegresar()
    {
        buttonPress.Play();
        menuPausa.SetActive(true);
        Opciones.SetActive(false);
    }

    public void botonRegresarMenuP()
    {
        buttonPress.Play();
        Opciones.SetActive(false);
    }
}
