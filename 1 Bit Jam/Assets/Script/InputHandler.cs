using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCam;
    public GameObject toRemove;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }

        MainItem mainItem = rayHit.collider.gameObject.GetComponent<MainItem>();

        if (mainItem != null)
        {
            Item item = mainItem.item;
            bool canAdd = InvntoryManager.instance.AddItem(item);
            if (canAdd)
            {
                 toRemove = rayHit.collider.gameObject;
                 Destroy(toRemove);
            }
        }

        InventorySlot slot = rayHit.collider.GetComponent<InventorySlot>();

        if (slot != null)
        {
            int selectedNum = System.Array.IndexOf(InvntoryManager.instance.inventorySlots, slot);
            InvntoryManager.instance.ChangeSelectedSlot(selectedNum);   
        }

    }
}
