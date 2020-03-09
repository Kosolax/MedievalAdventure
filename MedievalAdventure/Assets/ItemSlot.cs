
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private Image image;

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private Vector2 originalPosition;
    private Color normalColor = Color.white;
    //Transparent
    private Color disabledColor = Color.clear;

    public Item Item
    {
        get => this._item;
        set
        {
            this._item = value;

            if (this._item == null)
            {
                this.image.color = this.disabledColor;
            }
            else
            {
                this.image.sprite = this._item.Icon;
                this.image.color = this.normalColor;
            }
        }
    }
    private Item _item;

    protected virtual void OnValidate()
    {
        if(this.image == null)
        {
            this.image = this.GetComponent<Image>();
        }
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }

    //Someone RightClicked me, this is my item (go to inventory class)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClickEvent?.Invoke(this);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnPointerEnterEvent?.Invoke(this);
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnPointerExitEvent?.Invoke(this);
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnDragEvent?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnBeginDragEvent?.Invoke(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnEndDragEvent?.Invoke(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnDropEvent?.Invoke(this);
        }
    }
}
