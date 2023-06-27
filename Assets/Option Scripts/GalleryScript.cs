using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryScript : MonoBehaviour
{

    // These functions will help to access the gallery for each character show casing thier back story.
    public void KyleScene()
    {
        // Access Kyle's Gallery Scene
        SceneManager.LoadScene(3);
        Debug.Log("Kyle");
    }
    public void RexScene()
    {
        // Access Rex's Gallery Scene
        SceneManager.LoadScene(4);
        Debug.Log("Rex");
    }
    public void RobinScene()
    {
        // Access Robin's Gallery Scene
        SceneManager.LoadScene(10);
        Debug.Log("Robin");
    }
    public void LloydScene()
    {
        // Access Lloyd's Gallery Scene
        SceneManager.LoadScene(11);
        Debug.Log("Lloyd");
    }    
}
