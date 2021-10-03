using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public bool isCurrentlyFullscreen;

    public void SetFullscreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;
        isCurrentlyFullscreen = isFullScreen;

    }
 
}
