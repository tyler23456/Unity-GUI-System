using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Rendering;
using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class InGame : MonoBehaviour
    {
        [HideInInspector]
        public UserUIElements.UIElements uI;
        
        [SerializeField]
        Image image;

        public Contents contents = new Contents();
        public Exit exit = new Exit();
        public Main main = new Main();
        public Options options = new Options();
        public Controls controls = new Controls();

        Volume volume;

        bool isMenuState = false;

        void Start()
        {
            uI = GetComponent<UIElements>();

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (isMenuState)
                    Hide();
                else
                    Show();
        }

        public void Show()
        {
            isMenuState = true;
            Time.timeScale = 0f;
            image.color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
            main.Open(this, uI);
        }

        public void Hide()
        {
            isMenuState = false;
            Time.timeScale = 1f;
            image.color = Color.clear;
            uI.Clear();
        }

        public void PlaceholderEvent()
        {
            //remove this method once you have custom events to use when changing UI element values.
        }

        public void PlaceholderEvent(float value)
        {
            //remove this method once you have custom events to use when changing UI element values.
        }

        public void PlaceholderEvent(int value)
        {
            //remove this method once you have custom events to use when changing UI element values.
        }

        public void PlaceholderEvent(string name, int value)
        {
            //remove this method once you have custom events to use when changing UI element values.
        }
    }
}