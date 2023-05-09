using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Nueva Nota", menuName = "Inventory System / Items / Nota")]
public class Nota : ItemObject
{
    private void Awake()
    {
        type = ItemType.Nota;
    }
}
