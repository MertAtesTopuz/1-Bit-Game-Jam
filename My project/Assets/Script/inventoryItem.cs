using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    [Header("UI")]
    public Image image;
    public Text countText;

    private BoxCollider2D col;

    public Vector2 screenPos;
    public Vector2 worldPos;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        screenPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        col.enabled = true;
        transform.SetAsLastSibling();
        if (image.sprite.name == "Bulb")
        {
            InvntoryManager.instance.getBulb = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        InvntoryManager.instance.getBulb = false;
        col.enabled = false;

        if (InvntoryManager.instance.destroyBulb == true)
        {
            InvntoryManager.instance.GetSelectedItem(true);
            InvntoryManager.instance.destroyBulb = false;
        }
    }
}
