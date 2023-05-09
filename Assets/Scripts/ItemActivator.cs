using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField] GameObject itemToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            itemToActivate.SetActive(true);

        Destroy(this);
    }
}
