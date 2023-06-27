using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePickedAIScript : MonoBehaviour
{
    public void ForsetScene()
    {
        // Load the Character Select Screen with a Forest Background
        SceneManager.LoadScene(6);
    }
    public void DungeonScene()
    {
        // Load the Character Select Screen with a Dungeon Background
        SceneManager.LoadScene(22);
    }
    public void DesertScene()
    {
        // Load the Character Select Screen with a Desert Background
        SceneManager.LoadScene(24);
    }
    public void CityScene()
    {
        // Load the Character Select Screen with a Building Background
        SceneManager.LoadScene(20);
    }
}
