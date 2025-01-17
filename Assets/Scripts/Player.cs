using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables, Start, Awake and Constructors

    [Header("Controllers")]
    [SerializeField] private MenuInputAction menuActions;

    [Header("Party")]
    [SerializeField] private List<PartyMemberWrapper> PartyMembers = new List<PartyMemberWrapper>();

    [Header("Inventory")]
    public InventorySystemObject inventory;
    public InventorySystemObject equipment;

    [Header("UI")]
    public UIManager UI;

    [Header("Attributes")]
    public Attribute[] attributes;

    private void Awake()
    {
        menuActions = new MenuInputAction();
    }

    private void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
        UI.setMenuAction(menuActions);
    }

    #endregion

    #region Inventory

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }

                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }

    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }

                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }

    #endregion

    #region General

    public void OnTriggerEnter(Collider other)
    {
        var groundItem = other.GetComponent<GroundItem>();
        if (groundItem)
        {
            Item _item = new(groundItem.item);
            if (inventory.AddItem(_item, groundItem.amount))
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        
        }

    private void LateUpdate()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inventory.Save();
                equipment.Save();
            }
            else if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                inventory.Load();
                equipment.Load();
            }
            else if (menuActions.Menu.OpenMenu.WasPressedThisFrame())
            {
                UI.DisplayHideMenuWindow();
            }
            else if (menuActions.Menu.Encyclopedia.WasPressedThisFrame())
            {
                UI.DisplayHideEncyclopediaWindow();
            }
            else if (menuActions.Menu.Options.WasPressedThisFrame())
            {
                UI.DisplayHideOptionsWindow();
            }
            else if (menuActions.Menu.Save.WasPressedThisFrame())
            {
                inventory.Save();
                equipment.Save();
            }
            else if (menuActions.Menu.Map.WasPressedThisFrame())
            {
                UI.DisplayHideMapWindow();
            }
            else if (menuActions.Menu.Party.WasPressedThisFrame())
            {
                UI.DisplayHidePartyWindow();
            }
            else if (menuActions.Menu.Inventory.WasPressedThisFrame() )// && t >= 0)
            {
                UI.DisplayHideInventoryWindow();
            }
    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }

    private void OnEnable()
    {
        menuActions.Menu.Enable();
        menuActions.Menu.Inventory.Enable();
    }

    private void OnDisable()
    {
        menuActions.Disable();
        menuActions.Menu.Inventory.Disable();
    }

    #endregion

    #region Attributes

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
    }

    #endregion

}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;
    
    public void SetParent(Player _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}