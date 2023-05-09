using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeactivate : MonoBehaviour
{
    [SerializeField] GameObject itemToDeactivate;
    Shader shader1;
    Renderer rend;

    private void OnTriggerEnter(Collider other)
    {
        var rend = itemToDeactivate.GetComponent<Renderer>();
        shader1 = Shader.Find("Shader Graphs/Dissolve");
        if (other.CompareTag("Player"))
            StartCoroutine(RetrasoDestruir());

        IEnumerator RetrasoDestruir()
        {
            rend.material.SetFloat("_FadeStartTime", -float.MaxValue);
            rend.material.shader = shader1;
            rend.material.SetFloat("_FadeStartTime", Time.time);
            yield return new WaitForSeconds(1f);
            Destroy(itemToDeactivate);
            yield return new WaitForSeconds(0.2f);
            Destroy(this);
        }
    }
}
