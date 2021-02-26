using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public Image icon;

    Item item;

    public bool hasItem = false;

    public Chest chest1;

    public Button transferButton;

    void Update()
    {
        if (item != null)
        {
            hasItem = true;
        }
    }

    public void OnTransferButton()
    {
        if (hasItem)
        {
            chest1.TransferItem(item);
        }
    }

    public void AddItem(Item newItem, Chest chest)
    {
        item = newItem;
        chest1 = chest;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
