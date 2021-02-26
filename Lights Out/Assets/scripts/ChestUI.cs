using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public Transform chestSlotParent;
    public GameObject chestUI;

    void Update()
    {
        if (chestUI.activeSelf)
        {
            UpdateUI();
        }
    }

    public Chest chest;
    ChestSlot[] slots;

    void Start()
    {
        chest.onItemChangedCallback += UpdateUI;

        slots = chestSlotParent.GetComponentsInChildren<ChestSlot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < chest.contents.Count)
            {
                slots[i].AddItem(chest.contents[i], chest);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
