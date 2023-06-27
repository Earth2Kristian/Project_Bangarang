using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePickedMultiplayerScript : MonoBehaviour
{
    public void ForsetScene()
    {
        // Load the Character Select Screen with a Forest Background
        SceneManager.LoadScene(8);
    }
    public void DungeonScene()
    {
        // Load the Character Select Screen with a Dungeon Background
        SceneManager.LoadScene(15);
    }   
    public void DesertScene()
    {
        // Load the Character Select Screen with a Desert Background
        SceneManager.LoadScene(17);
    }   
    public void CityScene()
    {
        // Load the Character Select Screen with a Building Background
        SceneManager.LoadScene(18);
    }
}
