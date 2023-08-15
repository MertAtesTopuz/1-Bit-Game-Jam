using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvntoryManager : MonoBehaviour
{
    public static InvntoryManager instance;

    public int maxStackedItem = 10;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public bool getBulb;
    public bool destroyBulb;

    int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
      
    }

    public void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >=0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            inventoryItem itemInSlot = slot.GetComponentInChildren<inventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItem && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            inventoryItem itemInSlot = slot.GetComponentInChildren<inventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        inventoryItem inventoryItem = newItemGo.GetComponent<inventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        inventoryItem itemInSlot = slot.GetComponentInChildren<inventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }

        return null;
    }
}
