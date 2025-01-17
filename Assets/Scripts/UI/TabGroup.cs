using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButtonScript> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabSelected;
    public TabButtonScript selectedTab;
    public List<GameObject> objectsToSwap;

    public TabButtonScript startButton;

    public GameObject TabButtons;
    public GameObject PageArea;

    public void TurnOn()
    {
        PageArea.SetActive(true);
        TabButtons.SetActive(true);
        OnTabSelected(startButton);
    }

    public void Subscribe(TabButtonScript button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButtonScript>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButtonScript button) 
    {
        if (selectedTab == null || selectedTab != button)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButtonScript button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButtonScript button)
    {
        if (selectedTab != null)
        {
            selectedTab.DeSelect();
        }

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();

        selectedTab.background.sprite = tabSelected;

        int index = button.transform.GetSiblingIndex();

        for(int i=0; i< objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }

    }

    public void ResetTabs()
    {
        foreach(TabButtonScript button in tabButtons)
        {
            if (button != null && button != selectedTab)
            {
                button.background.sprite = tabIdle;
            }
        }
    }

}
