using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite chest_closed;
    public Sprite chest_opened;
    float radius = 1;
    public bool canOpen = false;
    public GameObject chestUI_Object;
    public bool isOpen = false;
    public int space = 8;
    Inventory inventory;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public List<Item> contents = new List<Item>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory = Inventory.instance;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        float distance = Vector2.Distance(Player.instance.transform.position, transform.position);
        if (distance > radius)
        {
            canOpen = false;
        }
        if (distance < radius)
        {
            canOpen = true;
        }
    }

    public void TransferItem(Item item)
    {
        bool wasTransfered = inventory.Add(item);
        Debug.Log("Result = " + wasTransfered);
    }

    public bool Add(Item item)
    {
        if (contents.Count >= space)
        {
            return false;
        }
        contents.Add(item);
        return true;
    }

    public void Unsuccessful()
    {
        PlayerUI.instance.ChangePopupText(2, "Chest full");
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        PlayerUI.instance.ChangePopupText(3, "Press 'Z' to open the chest");
    }

    public void OpenChest()
    {
        spriteRenderer.sprite = chest_opened;
        chestUI_Object.SetActive(true);
        isOpen = true;
    }

    public void CloseChest()
    {
        spriteRenderer.sprite = chest_closed;
        chestUI_Object.SetActive(false);
        isOpen = false;
    }
}
