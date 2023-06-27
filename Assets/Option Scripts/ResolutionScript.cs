using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    // The resoultion size list in terms of the widths and the heights
    // The player could choose from and which would be best suited for them
    List<int> widths = new List<int>() { 960, 1280, 1920 };
    List<int> heights = new List<int>() { 540, 800, 1080 };

    private bool fullscreen; // whenever the fullscreen would set to either true or false;

    // In order to get the resoultion to set, both width and height would both need to be set with a value
    private int width;
    private int height;

    public void SetScreenSize(int index)
    {
        // This functions show when a size has been selected
        fullscreen = Screen.fullScreen;
        width = widths[index];
        height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
        
    }

    public void SetFullScreen (bool _fullscreen)
    {
        // The screen will be set into full screen
        Screen.fullScreen = _fullscreen;
    }

}
