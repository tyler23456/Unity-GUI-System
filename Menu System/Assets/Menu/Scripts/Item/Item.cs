using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserItem
{
    public class Item : MonoBehaviour
    {
        [HideInInspector]
        public int maxCount;
        int index;
        UserUIElements.UIElements uI;
        RectTransform rect;
        Image image;
        TMP_Text text;
        public Action<string, int> OnCountChanged;     

        public int getCount
        {
            get { return text.text == ""? 0 : int.Parse(text.text); }
        }

        public Sprite getSprite
        {
            get { return image.sprite; }
        }

        void Awake()
        {
            uI = GetComponentInParent<UIElements>();
            rect = GetComponent<RectTransform>();
            image = transform.GetChild(0).gameObject.GetComponent<Image>();
            text = transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            OnCountChanged = (string arg1, int arg2) => { };
        }

        public void AddOne(Item item)
        {
            SetSprite(item.getSprite);
            SetCount(getCount + 1);
        }
        
        public void CreateNew(int count, int maxCount)
        {
            uI.AddIcon(image.sprite.name, rect.anchoredPosition.x, rect.anchoredPosition.y, count, maxCount, OnCountChanged); //on value changed ?
        }

        public void SetCount(int count)
        {
            text.text = Mathf.Clamp(count, 0, maxCount).ToString();

            if (getCount <= 0)
            {
                image.sprite = (Sprite)Resources.Load("AbilityIcons/Blank", typeof(Sprite));
                text.text = ""; //blank maybe
            }        
        }

        public void SetSprite(Sprite sprite)
        {
            this.image.sprite = sprite;
        }

        public bool CanAddOne(Item other)
        {
            return getCount == 0 || getCount < maxCount && this.getSprite.name == other.getSprite.name;
        }

        public void UpdateInventory()
        {
            OnCountChanged(image.sprite.name, getCount);         
        }
    }
}
