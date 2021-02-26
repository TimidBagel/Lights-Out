using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoinCollision : MonoBehaviour
{
    public Player player;
    public PlayerUI playerUI;
    public GameObject coin;
    public float lightIncrease = 0.5f;
    public string direction;
    public int temp = 22;
    public GameManager gm;
    public ChestUI chestUI;
    public InventorySlot inventorySlot;

    Chest chest;

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.name == "Coin")
        {
            player.LightIncrease(lightIncrease);
        }
        if (collisionInfo.name == "Door")
        {
            gm.EnterRoom();
            StartCoroutine(Wait(1.5f, "forward"));
        }
        if (collisionInfo.name == "Door(back)")
        {
            gm.EnterRoom();
            StartCoroutine(Wait(1.5f, "backward"));
        }
        if (collisionInfo.tag == "Item")
        {
            Interactable interactable = collisionInfo.GetComponent<Interactable>();
            playerUI.ChangePopupText(2, "Picking up " + collisionInfo.name);
            interactable.Interact();
        }
        if (collisionInfo.tag == "Chest")
        {
            chest = collisionInfo.GetComponent<Chest>();
            chestUI.chest = chest;
        }
    }

    void Update()
    {
        if (chest != null)
        {
            if(chest.canOpen && Input.GetKeyDown(KeyCode.Z))
            {
                chest.OpenChest();
            }

            if ((chest.isOpen && !chest.canOpen) || chest.isOpen && Input.GetKeyDown(KeyCode.X))
            {
                chest.CloseChest();
            }
        }
    }

    private IEnumerator Wait(float length, string direction)
    {
        playerUI.LoadingScreen();
        player.isPaused = true;
        yield return new WaitForSeconds(length);
        if (direction == "forward")
        {
            transform.Translate(temp, 0, 0);
        }
        if (direction == "backward")
        {
            transform.Translate(-temp, 0, 0);
        }
        player.isPaused = false;
    }
}
