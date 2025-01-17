using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private MenuInputAction menuActions;
    [SerializeField] private bool UIActive = false;

    [Header("Screens")]
    public GameObject TabButtons;
    public GameObject PageArea;
    public GameObject Party;

    public TabGroup UnitDetailsHandler;

    public GameObject Encyclopedia;

    public GameObject Options;
    public GameObject Save;
    public GameObject Map;

    public GameObject Menu;

    [Header("Misc")]
    [SerializeField] private TooltipPopup tooltipPopup;
    public GameObject HorizontalBackground;
    public GameObject VerticalBackground;

    public void setMenuAction(MenuInputAction menuActions)
    {
        this.menuActions = menuActions;
    }

    public bool isActive()
    {
        return UIActive;
    }

    #region Hide Show Functions

    public void DisplayHideMenuWindow()
    {
        if (Menu.activeSelf)
        {
            UIOff();
        }
        else
        {
            UIOff();
            VerticalBackground.SetActive(true);
            Menu.SetActive(true);
            UIActive = true;
        }
    }

    private void UIOff()
    {
        HorizontalBackground.SetActive(false);
        VerticalBackground.SetActive(false);

        Menu.SetActive(false);

        TabButtons.SetActive(false);
        PageArea.SetActive(false);
        Party.SetActive(false);
        Encyclopedia.SetActive(false);
        Options.SetActive(false);
        Save.SetActive(false);
        Map.SetActive(false);
        UIActive = false;
    }

    public void DisplayHideInventoryWindow()
    {
        if (TabButtons.activeSelf || PageArea.activeSelf)
        {
            UIOff();
        }
        else
        {
            VerticalBackground.SetActive(false);
            HorizontalBackground.SetActive(true);
            UnitDetailsHandler.TurnOn();
            UIActive = true;
        }
    }

    public void DisplayHideEncyclopediaWindow()
    {
        if (Encyclopedia.activeSelf)
        {
            UIOff();
        }
        else
        {
            HorizontalBackground.SetActive(false);
            Encyclopedia.SetActive(true);
            UIActive = true;
        }
    }

    public void DisplayHideOptionsWindow()
    {
        if (Options.activeSelf)
        {
            UIOff();
        }
        else
        {
            HorizontalBackground.SetActive(false);
            Options.SetActive(true);
            UIActive = true;
        }
    }

    public void DisplayHideMapWindow()
    {
        if (Map.activeSelf)
        {
            UIOff();
        }
        else
        {
            HorizontalBackground.SetActive(false);
            Map.SetActive(true);
            UIActive = true;
        }
    }

    public void DisplayHidePartyWindow()
    {
        if (Party.activeSelf)
        {
            UIOff();
        }
        else
        {
            HorizontalBackground.SetActive(false);
            Party.SetActive(true);
            UIActive = true;
        }
    }

    #endregion

    #region Buttons Pressed

    public void EncyclopediaButtonPressed()
    {
        Menu.SetActive(false);
        DisplayHideEncyclopediaWindow();
    }

    public void OptionsButtonPressed()
    {
        Menu.SetActive(false);
        DisplayHideOptionsWindow();
    }

    public void SaveButtonPressed()
    {
        Menu.SetActive(false);
        Save.SetActive(true);
    }

    public void PartyButtonPressed()
    {
        Menu.SetActive(false);
        DisplayHidePartyWindow();
    }

    public void InventoryButtonPressed()
    {
        Menu.SetActive(false);
        DisplayHideInventoryWindow();
    }

    public void MapButtonPressed()
    {
        Menu.SetActive(false);
        DisplayHideMapWindow();
    }

    #endregion
}
