using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;
    public Sprite selected, notSelected;
    private bool inThis;

    private void Awake()
    {
        Deselect();
    }

    private void Update()
    {
        int selectedNum = System.Array.IndexOf(InvntoryManager.instance.inventorySlots, this);
        inventoryItem itemInSlot = GetComponentInChildren<inventoryItem>();

        if (selectedNum == 7 )
        {
            if (itemInSlot != null)
            {
                inThis = true;
            }
            if( itemInSlot == null)
            {
                inThis = false;
            }
        }
        else
        {
            return;
        }

        if(inThis == true)
        {
            InvntoryManager.instance.usableSlot = true;
            InvntoryManager.instance.flashlightSelected2 = true;

        }
        if (inThis == false)
        {
            InvntoryManager.instance.usableSlot = false;
            InvntoryManager.instance.flashlightSelected2 = false;
        }
    }

    public void Select()
    {
        
        image.sprite = selected;
    }

    public void Deselect()
    {
        
        image.sprite = notSelected;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            inventoryItem inventoryItem = dropped.GetComponent<inventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
