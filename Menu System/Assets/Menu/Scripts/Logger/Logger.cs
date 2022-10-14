using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserDisplay
{
    public class Logger : MonoBehaviour
    {
        UIElements uI;

        const float yPosition = -100f;
        const float duration = 5f;
        const float speed = 150f;
        float timer;

        void Start()
        {
            uI = GetComponent<UIElements>();
            timer = 0f;
        }

        void Update()
        {        
            if (transform.childCount > 0)
                IncrementTimerAndUpdateLogs();

            if (timer >= duration)
                ResetTimerAndDestroyFirstLog();
        }

        void IncrementTimerAndUpdateLogs()
        {
            timer += Time.deltaTime;

            int i = 0;
            foreach (RectTransform child in transform)
            {
                Vector2 position = child.anchoredPosition;
                position.y = Mathf.Clamp(position.y + speed * Time.deltaTime, -2000f, yPosition + i * -50);
                child.anchoredPosition = position;
                i++;
            }
        }

        void ResetTimerAndDestroyFirstLog()
        {
            timer = 0;

            if (transform.childCount > 0)
                GameObject.Destroy(transform.GetChild(0).gameObject);
        }

        public void Print(string message)
        {
            int count = transform.childCount;
            uI.AddMessage(100, yPosition + count * -50, message);
        }

    }
}