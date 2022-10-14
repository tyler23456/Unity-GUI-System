using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class Contents
    {
        public void Open(InGame book, UserUIElements.UIElements uI)
        {
            uI.Clear();

            uI.AddButton("Main", 50, 10, () => { book.main.Open(book, uI); });            
            uI.AddButton("Options", 170, 10, () => { book.options.Open(book, uI); });
            uI.AddButton("Controls", 290, 10, () => { book.controls.Open(book, uI); });
            uI.AddButton("Exit", 410, 10, () => { book.exit.Open(book, uI); });
        }
    }
}