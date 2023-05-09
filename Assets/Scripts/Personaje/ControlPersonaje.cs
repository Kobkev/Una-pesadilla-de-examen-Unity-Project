using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPersonaje : MonoBehaviour
{

    public GameObject elPersonaje;
    public bool enMovimiento;
    bool estaCorriendo;
    float movimientoHorizontal;
    float movimientoVertical;
    [SerializeField] float velocidadRotacion = 150f;
    [SerializeField] float velocidadCaminar = 0.8f;
    [SerializeField] float velocidadCorrer = 1f;


    public InventoryObject inventory;
    public GameObject anadido;
    public AudioSource recoger;
    public GameObject ActionDisplay;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private QuestionUI questionUI;
    public GameObject ActionText;
    public TMP_Text aText;
    public DialogueUI DialogueUI => dialogueUI;
    public QuestionUI QuestionUI => questionUI;
    public IInteractable Interactable { get; set; }
    Shader shader1;
    Renderer rend;

    void Update()
    {

        float velocidad = velocidadCaminar;

        if (dialogueUI.IsOpen || questionUI.IsOpen) elPersonaje.GetComponent<Animator>().Play("Idle");

        if (ControlGlobal.pausaAbierto == false)
        {
            if (ControlGlobal.inventarioAbierto == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    estaCorriendo = true;
                }
                else
                {
                    estaCorriendo = false;
                }
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        movimientoVertical = Time.deltaTime * (-velocidad / 2);
                        elPersonaje.GetComponent<Animator>().Play("WalkBack");
                    }
                    else
                    {
                        if (estaCorriendo == false)
                        {
                            movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar;
                            //elPersonaje.GetComponent<Animator>().Play("StartWalk");
                            elPersonaje.GetComponent<Animator>().Play("Walk");
                        }
                        else if (Input.GetKey(KeyCode.W) && estaCorriendo == true)
                        {
                            movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCorrer;
                            elPersonaje.GetComponent<Animator>().Play("Walk");
                            //elPersonaje.GetComponent<Animator>().Play("Run");
                        }
                    }
                    movimientoHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRotacion;
                    elPersonaje.transform.Rotate(0, movimientoHorizontal, 0);
                    elPersonaje.transform.Translate(0, 0, movimientoVertical);
                }
                else
                {
                    enMovimiento = false;
                    elPersonaje.GetComponent<Animator>().Play("Idle");
                }
            }
            else
            {
                elPersonaje.GetComponent<Animator>().Play("Idle");
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {

        var rend = other.GetComponent<Renderer>();
        var sphere = other.GetComponent<SphereCollider>();
        var box = other.GetComponent<BoxCollider>();
        shader1 = Shader.Find("Shader Graphs/Dissolve");
        var item = other.GetComponent<GroundItem>();
        var inter = other.GetComponent<DialogueActivator>();
        var inter2 = other.GetComponent<QuestionActivator>();
        var keyDoor = other.GetComponent<KeyDoor>();
        var anadidoText = anadido.GetComponent<TMP_Text>();



        IEnumerator RetrasoDestruir()
        {
            rend.material.SetFloat("_FadeStartTime", -float.MaxValue);
            rend.material.shader = shader1;
            rend.material.SetFloat("_FadeStartTime", Time.time);
            yield return new WaitForSeconds(1f);
            Destroy(other.gameObject);
        }

        if (item)
        {
            MostrarMensajes();
            aText.text = "Recoger";

            if (Input.GetButtonDown("Action"))
            {
                if (inventory.EmptySlotCount <= 0)
                    anadidoText.text = "Inventario lleno!!";
                else
                {
                    sphere.enabled = false;
                    recoger.Play();
                    elPersonaje.GetComponent<Animator>().Play("PickUp");

                    anadidoText.text = "Se ha añadido al inventario.";
                    Item _item = new Item(item.item);
                    inventory.AddItem(_item, 1);
                    EsconderMensajes();
                    StartCoroutine(RetrasoDestruir());
                }
                anadido.SetActive(true);
                StartCoroutine(MensajeAnadido());
            }
        }
        else if (inter || inter2)
        {
            MostrarMensajes();
            aText.text = "Interactuar / Inspeccionar";

            if (Input.GetButtonDown("Action") && ControlGlobal.ButtonsEnabled == true)
            {
                Interactable?.Interact(this);
            }
            if (dialogueUI.IsOpen || questionUI.IsOpen)
            {
                EsconderMensajes();
                ControlGlobal.pausaAbierto = true;
            }
            else
            {
                {
                    ControlGlobal.pausaAbierto = false;
                }
            }
        }
        else if (keyDoor)
        {
            for (int i = 0; i < inventory.Container.Items.Length; i++)
            {
                Item currentItem = inventory.Container.Items[i].item;
                if (currentItem.Id == keyDoor.ID)
                {
                    aText.text = "Abrir";
                    MostrarMensajes();
                    if (Input.GetButtonDown("Action"))
                    {
                        EsconderMensajes();
                        box.enabled = false;
                        inventory.Container.Items[i].RemoveItem();
                        StartCoroutine(RetrasoDestruir());
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        ActionDisplay.SetActive(false);
        aText.text = string.Empty;
        ActionText.SetActive(false);

    }


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    IEnumerator MensajeAnadido()
    {
        yield return new WaitForSeconds(2f);
        anadido.SetActive(false);
    }

    void MostrarMensajes()
    {
        ActionDisplay.SetActive(true);
        ActionText.SetActive(true);
    }

    void EsconderMensajes()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
