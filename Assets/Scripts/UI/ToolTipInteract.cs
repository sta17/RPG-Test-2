using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public TooltipPopup tooltipPopup;
    [SerializeField] private Item item;

    public void Awake()
    {
        item = null;
    }

    public void SetDisplayItem(Item newItem)
    {
        item = newItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null && tooltipPopup != null) {
                tooltipPopup.DisplayInfo(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipPopup != null)
        {
            tooltipPopup.HideInfo();
        }
    }
}