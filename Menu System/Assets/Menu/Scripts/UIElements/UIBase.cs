using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

using GDA.Menu.UserItem;

namespace GDA.Menu.UserUIElements
{
    public abstract class UIBase : MonoBehaviour
    {
        GameObject obj;

        void Start()
        {
        }

        public void AddButton(string name, float x, float y, Action onClick)
        {
            obj = InstantiateGUI("UserButton");
            SetParameters(name, x, y);
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(delegate { onClick(); });
        }

        public void AddDropDown(float x, float y, List<TMP_Dropdown.OptionData> options, int value, Action<int> onValueChanged)
        {
            obj = InstantiateGUI("UserDrop");
            SetParameters(x, y);
            TMP_Dropdown drop = obj.GetComponent<TMP_Dropdown>();
            drop.options = options;
            drop.value = value;
            drop.onValueChanged.AddListener(delegate { onValueChanged(drop.value); });
        }

        public void AddInput(float x, float y, string value, Action onValueChanged)
        {
            obj = InstantiateGUI("UserInput");
            SetParameters(value, x, y);
            TMP_InputField input = obj.GetComponent<TMP_InputField>();
            input.onValueChanged.AddListener(delegate { onValueChanged(); });
        }

        public void AddToggle(string name, float x, float y, bool isOn, Action onValueChanged)
        {
            obj = InstantiateGUI("UserToggle");
            SetParameters(name, x, y);
            Toggle toggle = obj.GetComponent<Toggle>();
            toggle.isOn = isOn;
            toggle.onValueChanged.AddListener(delegate { onValueChanged(); });
        }

        public void AddText(string name, float x, float y)
        {
            obj = InstantiateGUI("UserText");
            SetParameters(name, x, y);
        }

        public void AddSlider(int min, int max, float x, float y, int value, Action<float> onValueChanged)
        {
            obj = InstantiateGUI("UserSlider");
            SetParameters(x, y);
            Slider slider = obj.GetComponent<Slider>();
            slider.minValue = min;
            slider.maxValue = max;
            slider.wholeNumbers = true;
            slider.value = Mathf.Clamp(value, min, max);
            slider.onValueChanged.AddListener(delegate { onValueChanged(slider.value); });
        }

        public void AddScroll(float x, float y, float size, Color color, Action<float> onValueChanged)
        {
            obj = InstantiateGUI("UserScroll");
            SetParameters(x, y);
            Scrollbar scroll = obj.GetComponent<Scrollbar>();
            scroll.value = 0;
            scroll.size = size;
            scroll.onValueChanged.AddListener(delegate { onValueChanged(scroll.size); });
            Image image = scroll.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            image.color = color;
        }

        public void AddIcon(string name, float x, float y, int count, int maxCount, Action<string, int> OnValueChanged)
        {       
            obj = InstantiateGUI("UserIcon");
            Item item = obj.GetComponent<Item>();
            item.SetSprite((Sprite)Resources.Load("AbilityIcons/" + name, typeof(Sprite)));
            item.maxCount = maxCount;
            item.SetCount(count);
            item.OnCountChanged = OnValueChanged; //need to set this up
            SetParameters(x, y);         
        }

        public void AddMap(float x, float y)
        {
            obj = InstantiateGUI("UserMap");
            SetParameters(x, y);      
        }

        public void AddMarker(float x, float y)
        {
            obj = InstantiateGUI("UserMarker");
            SetParameters(x, y);
        }

        public void AddMessage(float x, float y, string message)
        {
            obj = InstantiateGUI("UserMessage");
            SetParameters(message, x, y);
        }

        GameObject InstantiateGUI(string fileName)
        {
            return GameObject.Instantiate((GameObject)Resources.Load("GUI/" + fileName, typeof(GameObject)), transform);
        }

        void SetParameters(string name, float x, float y)
        {
            obj.GetComponentInChildren<TMP_Text>().text = name;
            SetParameters(x, y);
        }

        void SetParameters(float x, float y)
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }
    }
}