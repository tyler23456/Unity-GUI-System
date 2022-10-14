using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class Exit
    {
        public void Open(InGame book, UIElements uI)
        {
            book.contents.Open(book, uI);

            uI.AddButton("Quit game", 50, -50, book.PlaceholderEvent);

            uI.AddButton("Quit world", 50, -80, book.PlaceholderEvent);

            uI.AddButton("Logout", 50, -110, book.PlaceholderEvent);
        }
    }
}