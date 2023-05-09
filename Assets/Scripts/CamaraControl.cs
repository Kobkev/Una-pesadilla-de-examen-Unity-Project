using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [Tooltip("Este es la camara al cual se cambiará")]
    public GameObject camaraEncendido;
    [Tooltip("Este es la camara que se desactiva")]
    public GameObject camaraApagado;
    [Tooltip("Muestra si la camara está activa")]
    public bool camOn = false;

    /* void Start()
    {
        //StartCoroutine(CameraSwitch());
    } */

    /*     IEnumerator CameraSwitch() // Se utiliza la corutina en el caso de agregar un retrase cuando se cambian las camaras.
        {
            yield return new WaitForSeconds(5);
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
            camOn = true;
            cameraNumber = 2;
        } */

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camaraEncendido.SetActive(true);
            //camaraEncendido.GetComponent<AudioListener>().enabled = true;
            camaraApagado.SetActive(false);
            //camaraApagado.GetComponent<AudioListener>().enabled = false;
        }
    }
}
