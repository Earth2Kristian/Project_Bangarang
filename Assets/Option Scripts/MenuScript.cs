using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void VSScene()
    {
        // Solo Match (Single Player Match) will be selected and loaded to the stage select screen
        SceneManager.LoadScene(19);
        Debug.Log("Solo Match! Let's play");
    }
    public void MultiplayerScene()
    {
        // Local Match (Multiplayer Match) will be selected and loaded to the stage select screen
        SceneManager.LoadScene(16);
        Debug.Log("Multiplayer Match! Let's play");
    }
    public void GalleryScene()
    {
        // Gallery Section will be selected and loaded to the scence
        SceneManager.LoadScene(2);
        Debug.Log("Gallery");
    }

    public void OptionsScene()
    {
        // Options Section will be selected and loaded to the sence
        SceneManager.LoadScene(5);
        Debug.Log("Options");
    }
    public void TrainingScene()
    {
        // Training Section will be selected and loaded to the scene
        SceneManager.LoadScene(26);
        Debug.Log("Training Mode");
    }
}
