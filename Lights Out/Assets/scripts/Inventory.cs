using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 8;

    public List<Item> items = new List<Item>();

    PlayerUI playerUI;

    void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                playerUI.ChangePopupText(2, "Inventory full");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item, bool used)
    {
        items.Remove(item);
        if (!used)
        {
            playerUI.ChangePopupText(2, "Dropped " + item.name);
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        if (used)
        {
            playerUI.ChangePopupText(2, "Used " + item.name);
        }
    }
}
