using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitleScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Back");
    }
}
