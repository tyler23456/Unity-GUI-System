using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

using GDA.Menu.UserUIElements;
using GDA.Menu.UserItem;

namespace GDA.Menu.UserDragDrop
{
    public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Canvas canvas;
        [HideInInspector]
        public CanvasGroup canvasGroup;
        RectTransform rect;
        Item item;
        Item previous;
        [HideInInspector]
        public bool isDropSuccessful = true;


        void Awake()
        {
            canvas = transform.root.gameObject.GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();
            item = GetComponent<Item>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (item.getCount <= 0)
                return;

            item.CreateNew(item.getCount - 1, item.maxCount);
            item.SetCount(1);
            previous = transform.parent.GetChild(transform.parent.childCount - 1).gameObject.GetComponent<Item>();
            transform.SetAsLastSibling();
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item.getCount <= 0)
                return;

            rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (item.getCount <= 0)
                return;

            GameObject hoveredObject = eventData.hovered.FirstOrDefault(h => h.GetComponent<Item>());

            Item hovered = null;
            if (hoveredObject != null)
                hovered = hoveredObject.GetComponent<Item>();

            if (hovered != null && hovered.CanAddOne(item)) //same type //Successful Drag Drop
            {
                hovered.AddOne(item);
                previous.UpdateInventory();
                hovered.UpdateInventory();
                //play sound FX here when dragged Item is being placed.
            }            
            else
                previous.AddOne(item);          

            DestroyImmediate(item.gameObject);
        }
    }
}