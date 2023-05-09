using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Nota,
    Llave,
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;

    public Item data = new Item();

    public virtual string GetItemDescription()
    {
        return description;
    }

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
    /* public int GetItemID()
    {
        return Id;
    } */
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public string description;
    public ItemType type;

    public Item()
    {
        Name = string.Empty;
        Id = -1;
        description = string.Empty;
    }

    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        description = item.description;
        type = item.type;
    }
}



