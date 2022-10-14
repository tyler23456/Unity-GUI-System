using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GDA.Menu.UserUIElements;

namespace GDA.Menu.UserInGame
{
    class Options
    {
        public void Open(InGame inGame, UserUIElements.UIElements uI)
        {
            inGame.contents.Open(inGame, uI);

            //get camera from here.

            //music volume
            uI.AddSliderOption("Music Volume", 0, 100, 50, -50, 1, inGame.PlaceholderEvent);

            //ambience volume
            uI.AddSliderOption("Atmosphere Volume", 0, 100, 50, -80, 1, inGame.PlaceholderEvent);

            //sfx volume
            uI.AddSliderOption("SoundFX Volume", 0, 100, 50, -110, 1, inGame.PlaceholderEvent);

            //fov
            uI.AddSliderOption("FOV", 60, 100, 50, -140, 1, inGame.PlaceholderEvent);
        }
    }
}