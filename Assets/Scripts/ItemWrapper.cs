using UnityEngine;

[System.Serializable]
public class ItemWrapper
{

    #region Variables and Constructors

    [Header("Item Data")]
    [SerializeField] private ItemStats item;
    [SerializeField] private int itemID;
    [SerializeField] private ItemTypes itemType;
    [SerializeField] private int itemAmount = 1;

    public ItemWrapper()
    {

    }
    public ItemWrapper(int newItemAmount, ItemTypes newItemType, ItemStats newItem)
    {
        itemAmount = newItemAmount;
        itemType = newItemType;
        item = newItem;
    }

    #endregion

    public bool Use(out bool AmountBelowOne)
    {
        itemAmount -= 1;

        if (itemAmount < 1)
        {
            AmountBelowOne = true;
        }
        else
        {
            AmountBelowOne = false;
        }

        return true;
    }

    public bool Use()
    {
        itemAmount -= 1;
        return true;
    }

}