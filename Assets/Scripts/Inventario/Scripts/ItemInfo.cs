using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemInfo : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;


    public void SetUp(string name, string description)
    {
        itemName.text = name;
        itemDescription.text = description;
    }
}