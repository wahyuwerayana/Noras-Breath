using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SetFullscreen(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }
}
