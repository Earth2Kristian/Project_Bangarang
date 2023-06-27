using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public void QuitGame()
    {
        // This function will allow the game to be shutdown
        Application.Quit();
        Debug.Log("Quit");
    }
}
