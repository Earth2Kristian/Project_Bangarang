using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void LoadScene()
    {
        // This function will allow the player to go to the menu screen
        SceneManager.LoadScene(1);
        Debug.Log("Play");
    }
    public void GalleryScene()
    {
        SceneManager.LoadScene(2);

    }
}
