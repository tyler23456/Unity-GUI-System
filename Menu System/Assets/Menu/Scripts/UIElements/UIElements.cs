using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GDA.Menu.UserUIElements
{
    public class UIElements : UIBase
    {
        public void Clear()
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
        }

        public void AddSliderOption(string name, int min, int max, float x, float y, int value, Action<float> onValueChanged)
        {
            AddText(name, x, y);
            AddSlider(min, max, x + 150f, y, value, onValueChanged);
        }

        public void AddDropDownOption(string name, float x, float y, List<TMP_Dropdown.OptionData> options, int value, Action<int> onSelected)
        {
            AddText(name, x, y);
            AddDropDown(x + 150f, y, options, value,  onSelected);
        }
    }
}