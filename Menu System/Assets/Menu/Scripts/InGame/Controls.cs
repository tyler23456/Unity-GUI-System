using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class Controls
    {
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData> { };
        public Controls()
        {
            for (int i = 0; i <= 325; i++)
                options.Add(new TMP_Dropdown.OptionData(((KeyCode)i).ToString()));
        }
        
        public void Open(InGame book, UserUIElements.UIElements uI)
        {
            book.contents.Open(book, uI);

            uI.AddDropDownOption("Move forward", 50, -50, options, 0, book.PlaceholderEvent);

            uI.AddDropDownOption("Move back", 50, -80, options, 1, book.PlaceholderEvent);

            uI.AddDropDownOption("Move left", 50, -110, options, 2, book.PlaceholderEvent);

            uI.AddDropDownOption("Move right", 50, -140, options, 3, book.PlaceholderEvent);

            uI.AddDropDownOption("Sprint", 50, -170, options, 4, book.PlaceholderEvent);

            uI.AddDropDownOption("Jump", 50, -200, options, 5, book.PlaceholderEvent);

            uI.AddDropDownOption("Attack", 50, -230, options, 6, book.PlaceholderEvent);

            uI.AddDropDownOption("Toggle ability", 50, -260, options, 7, book.PlaceholderEvent);

            uI.AddDropDownOption("Scroll Abilities", 50, -290, options, 8, book.PlaceholderEvent);

            uI.AddDropDownOption("Toggle Menu", 50, -320, options, 9, book.PlaceholderEvent);
        }
    }
}
