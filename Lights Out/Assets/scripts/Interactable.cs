using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    public bool hasInteracted = false;
    private GameObject playerObject;
    private Player player;
    public Item item;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerObject = GameObject.FindWithTag("Player");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        // this method is meant to be overriden
    }

    void Update()
    {
        float distance = Vector2.Distance(playerObject.transform.position, transform.position);
        if (distance <= radius && !player.canInteract)
        {
            player.currentObject = item.name;
            player.canInteract = true;
        }
        if (distance > radius && player.canInteract)
        {
            player.canInteract = false;
        }
    }
}
