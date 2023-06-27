using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayScript : MonoBehaviour
{
    private static GameplayScript instance = null;
    GameManager gm;

    public TMP_Text countdownTimertxt;

    // P1's Text
    public TMP_Text p1Damagetxt;
    public TMP_Text p1Livestxt;
    public TMP_Text p1MPtxt;


    // P2's Text
    public TMP_Text p2Damagetxt;
    public TMP_Text p2Livestxt;
    public TMP_Text p2MPtxt;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
    }

    public static GameplayScript Instance
    {
        get
        {
            return instance;
        }
    }
}
