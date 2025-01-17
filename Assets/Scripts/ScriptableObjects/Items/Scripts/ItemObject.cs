using UnityEngine;
using System.Text;

public enum ItemType 
{
    Default,
    Food,
    Helmet, Head,

    Boots, Feet,

    Chest,

    Shoulder,
    Wrist,
    Hands,
    Waist,

    Legs,
    Neck,
    Back,
    Finger,

    Trinket,

    Weapon,
    Shield,
    OneHand,
    TwoHand,
    MainHand,
    OffHand
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/item")]
public class ItemObject : ScriptableObject
{
    public Sprite icon;
    public bool stackable;
    public ItemType type;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    [SerializeField] private string Name;
    [TextArea(15, 20)]
    [SerializeField] private string description;
    public int Id = -1;

    //[SerializeField] private ItemType type;

    [SerializeField] private Rarity rarity;
    [SerializeField] private bool isUseable = false;
    [SerializeField] private string useText = "Fill In";

    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];
        rarity = item.data.rarity;
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }

    public string ItemName { get { return Name; } }

    //public Rarity Rarity { get { return rarity; } }

    public string ColouredName
    {
        get
        {
            var rarityColour = Color.black;
            if (rarity != null)
            {
                rarityColour = rarity.TextColour;
            }
            string hexColour = ColorUtility.ToHtmlStringRGB(rarityColour);
            return $"<color=#{hexColour}>{Name}</color>";
        }
    }

    public string GetTooltipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        var rarityName = "Common";
        if (rarity != null)
        {
            rarityName = rarity.Name;
        }

        builder.Append(rarityName).AppendLine();
        builder.Append("Description").AppendLine();
        builder.Append(description).AppendLine();
        if (isUseable)
        {
            builder.Append("<color=green>Use: ").Append(useText).Append("</color>").AppendLine();

        }
        return builder.ToString();
    }
}

[System.Serializable]
public class ItemBuff : IModifier
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}