using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string type;

    [Header("Stats (for consumables)")]
    public int healthGained;
    public int useAmount;

    public virtual void Use()
    {
        //this method is meant to be overriden
        //when item is used it does something
    }
}
