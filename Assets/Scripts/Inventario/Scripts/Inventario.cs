using System;
using System.Collections;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject pantallaInventario;
    public GameObject textoInstrucionesInventario;
    public AudioSource abrirInventario;
    public AudioSource cerrarInventario;
    private bool estaAbierto = false;
    private bool puedeCerrar = false;
    private bool primeraVez = true;

    public GameObject invUI;

    void Update()
    {
        if (ControlGlobal.inventarioAbierto == false && ControlGlobal.pausaAbierto == false)
        {
            if (Input.GetKey(KeyCode.Tab) && estaAbierto == false && puedeCerrar == false)
            {
                if (primeraVez)
                {
                    textoInstrucionesInventario.SetActive(true);
                    primeraVez = false;
                }
                estaAbierto = true;
                ControlGlobal.inventarioAbierto = true;
                abrirInventario.Play();
                StartCoroutine(InvControl());
            }
        }
        if (ControlGlobal.inventarioAbierto == true && ControlGlobal.pausaAbierto == false)
        {
            if (Input.GetKey(KeyCode.Tab) && estaAbierto == true && puedeCerrar == true)
            {
                estaAbierto = false;
                ControlGlobal.inventarioAbierto = false;
                cerrarInventario.Play();
                StartCoroutine(InvControl());
            }
        }
    }

    public void botonMenu()
    {
        estaAbierto = false;
        ControlGlobal.inventarioAbierto = false;
        cerrarInventario.Play();
        StartCoroutine(InvControl());
    }

    public void botonSalir()
    {
        estaAbierto = false;
        ControlGlobal.inventarioAbierto = false;
        cerrarInventario.Play();
        StartCoroutine(InvControl());
    }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(0.25f);
        if (estaAbierto == true)
        {
            pantallaInventario.SetActive(true);
        }
        else
        {
            pantallaInventario.SetActive(false);
            invUI.SetActive(false);
        }
        if (estaAbierto == true)
        {
            puedeCerrar = true;
            /* Time.timeScale = 0;
            Cursor.visible = true; */
        }
        else
        {
            puedeCerrar = false;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
