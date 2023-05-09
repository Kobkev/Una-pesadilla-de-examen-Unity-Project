using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Llave", menuName = "Inventory System / Items / Llave")]
public class Llaves : ItemObject
{
    private void Awake()
    {
        type = ItemType.Llave;
    }
}
