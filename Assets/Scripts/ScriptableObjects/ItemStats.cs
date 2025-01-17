using UnityEngine;

[CreateAssetMenu(menuName = "Old/Items/Item")]
public class ItemStats : ScriptableObject
{
    public string itemName;
    [TextArea(4, 4)]
    public string itemDescriptions;
    public ItemTypes type;
    public ItemSlotTypes slotType;
    public Sprite icon = null;
    public int itemAmount = 1;

    public string ItemName { get { return itemName;  } }

    //public abstract string ColouredItemName { get; }

    //public abstract string GetTooltipInfoText();
}

public enum ItemTypes
{
    Generic,
    Pickup,
    Stackable
}

public enum ItemSlotTypes
{
    Generic,
    Head,
    Shoulder,
    Chest,
    Wrist,
    Hands,
    Waist,
    Legs,
    Feet,
    Neck,
    Back,
    Finger,
    Trinket,
    OneHand,
    TwoHand,
    MainHand,
    OffHand
}