using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly HashSet<ItemId> items = new HashSet<ItemId>();

    public void Add(ItemId item)
    {
        items.Add(item);
        Debug.Log($"Inventory: added {item}");
    }

    public bool Has(ItemId item)
    {
        return items.Contains(item);
    }
}