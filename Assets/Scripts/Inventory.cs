using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Button> InventoryButtons;

    public void Clear()
    {
        foreach (var button in InventoryButtons)
        {
            button.interactable = true;
        }
    }
}