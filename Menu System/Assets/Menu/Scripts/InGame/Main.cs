using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class Main
    {
        public void Open(InGame book, UserUIElements.UIElements uI)
        {
            book.contents.Open(book, uI);

            int x;
            int y = 50;   
            for (int i = 0; i < 3; i++)
            {
                x = 50;
                for (int ii = 0; ii < 3; ii++)
                {
                    uI.AddIcon("Blank", x, -y, 0, 1, book.PlaceholderEvent);
                    x += 30;
                }
                y += 40;          
            }

            x = 50;
            y += 50;
            for (int i = 0; i < 20; i++)
            {
                uI.AddIcon("Blank", x, -y, 3, 9, book.PlaceholderEvent);

                x += 30;

                if (x > 250)
                {
                    x = 50;
                    y += 30;
                }
            }
        }
    }
}
