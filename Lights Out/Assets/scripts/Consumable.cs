using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public override void Use()
    {
        Player.instance.GainHealth(healthGained);
        RemoveFromInventory(true);
    }
    
    public void RemoveFromInventory(bool used)
    {
        Inventory.instance.Remove(this, used);
    }
}
