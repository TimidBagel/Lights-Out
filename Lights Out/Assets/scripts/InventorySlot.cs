using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image icon;
	public Button removeButton;
	public Chest chest;

	Item item;

	public bool hasItem = false;

	Chest[] chestList;

	void Start()
    {
		chestList = FindObjectsOfType<Chest>();
    }

	void Update()
    {
		if (item != null)
        {
			hasItem = true;
        }
    }

	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void OnRemoveButton()
	{
        for (int i = 0; i < chestList.Length; i++)
        {
			if (chestList[i].isOpen)
            {
				chest = chestList[i];
				TransferItem();
				return;
            }
        }
		Inventory.instance.Remove(item, false);
	}

	public void TransferItem()
    {
		bool wasPickedUp = chest.Add(item);
		if (wasPickedUp)
        {
			Inventory.instance.Remove(item, false);
        }
        if (!wasPickedUp)
        {
			chest.Unsuccessful();
        }
    }

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
