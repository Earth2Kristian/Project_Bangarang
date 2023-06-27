using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Countdown Timer
    public float countdownTimer = 150;
    public GameObject suddenDeath;

    // P1's Stats
    public float p1Damage = 0;
    public float p1Lives = 3;
    public float p1MP = 100;

    // P2's Stats
    public float p2Damage = 0;
    public float p2Lives = 3;
    public float p2MP = 100;

    public bool game_over = false;

    public GameObject p1WinUI = null;
    public GameObject p2WinUI = null;
    public GameObject menuButton = null;


    void Start()
    {
        // All texts will be updated from the start function
        GameplayScript.Instance.p1Damagetxt.text = Mathf.Round(p1Damage) + "%";
        GameplayScript.Instance.p2Damagetxt.text = Mathf.Round(p2Damage) + "%";

        GameplayScript.Instance.p1Livestxt.text = "x " + Mathf.Round(p1Lives);
        GameplayScript.Instance.p2Livestxt.text = "x " + Mathf.Round(p2Lives);

        GameplayScript.Instance.p1MPtxt.text = "MP: " + Mathf.Round(p1MP);
        GameplayScript.Instance.p2MPtxt.text = "MP: " + Mathf.Round(p2MP);

        GameplayScript.Instance.countdownTimertxt.text = "TIME: " + Mathf.Round(countdownTimer);

        // The gameplay will play once the match has started
        game_over = false;
        Time.timeScale = 1f;


        p1WinUI.SetActive(false);
        p2WinUI.SetActive(false);
        menuButton.SetActive(false);
    }

    
    void Update()
    {
        // Currently Counting Down
        countdownTimer -= Time.deltaTime;
        GameplayScript.Instance.countdownTimertxt.text = "TIME: " + Mathf.Round(countdownTimer);

        if (countdownTimer > 0)
        {
            suddenDeath.SetActive(false);
        }
        
        // If time counts down to 0 and Player 1's lives is the same amount as Player 2's lives
        if (countdownTimer <= 0)
        {
            countdownTimer = 0;
            if (p1Lives == p2Lives)
            {
                suddenDeath.SetActive(true);
            }
        }
        
        // Each MP Level has the ability to recharge if the level is below 100
        // P1's MP Level 
        if (p1MP >= 100)
        {
            p1MP = 100;
            GameplayScript.Instance.p1MPtxt.text = "MP: " + Mathf.Round(p1MP);
        }
        if (p1MP < 100)
        {
            p1MP += Time.deltaTime;
            GameplayScript.Instance.p1MPtxt.text = "MP: " + Mathf.Round(p1MP);
        }

        // P2's MP Level
        if (p2MP >= 100)
        {
            p2MP = 100;
            GameplayScript.Instance.p2MPtxt.text = "MP: " + Mathf.Round(p2MP);
        }
        if (p2MP < 100)
        {
            p2MP += Time.deltaTime;
            GameplayScript.Instance.p2MPtxt.text = "MP: " + Mathf.Round(p2MP);
        }

        if (p1Damage <= 0)
        {
            p1Damage = 0;
            GameplayScript.Instance.p1Damagetxt.text = Mathf.Round(p1Damage) + "%";
        }
        if (p2Damage <= 0)
        {
            p2Damage = 0;
            GameplayScript.Instance.p2Damagetxt.text = Mathf.Round(p2Damage) + "%";
        }


        P1Wins();
        P2Wins();

    }

    void Awake()
    {
        instance = this;   
    }

    public void HitP1(int amount)
    {
        // When Player 1 gets hit, this function allow the  the percentage damage will increase by a certain amount for player 1
        p1Damage += amount;
        GameplayScript.Instance.p1Damagetxt.text = Mathf.Round(p1Damage) + "%";

    }

    public void HitP2(int amount)
    {
        // When Player 2 (or AI) gets hit, this function allow the percentage damage will increase by a certain amount for player 2
        p2Damage += amount;
        GameplayScript.Instance.p2Damagetxt.text = Mathf.Round(p2Damage) + "%";
    }


    public void LoseLivesP1(int amount)
    {
        // This function will allow player to lose a live
        p1Lives -= amount;
        GameplayScript.Instance.p1Livestxt.text = "x " + Mathf.Round(p1Lives);
    }

    public void LoseLivesP2(int amount)
    {
        // This function will allow player 2 to lose a live
        p2Lives -= amount;
        GameplayScript.Instance.p2Livestxt.text = "x " + Mathf.Round(p2Lives);
    }

    public void MPP1Adjustment(int amount)
    {
        // This function will allow playe1 1 to decrease MP level when MP is being used by player 1
        p1MP -= amount;
        GameplayScript.Instance.p1MPtxt.text = "MP: " + Mathf.Round(p1MP);
    }

    public void MPP2Adjustment(int amount)
    {
        // This function will allow playe1 2 to decrease MP level when MP is being used by player 2
        p2MP -= amount;
        GameplayScript.Instance.p2MPtxt.text = "MP: " + Mathf.Round(p2MP);
    }

    // For Items Purposes only
    public void HealP1(int amount)
    {
        p1Damage -= amount;
        GameplayScript.Instance.p1Damagetxt.text = Mathf.Round(p1Damage) + "%";
    }
    public void HealP2(int amount)
    {
        p2Damage -= amount;
        GameplayScript.Instance.p2Damagetxt.text = Mathf.Round(p2Damage) + "%";
    }

    public void MPPlusP1(int amount)
    {
        p1MP += amount;
        GameplayScript.Instance.p1MPtxt.text = "MP: " + Mathf.Round(p1MP);
    }
    public void MPPlusP2(int amount)
    {
        p2MP += amount;
        GameplayScript.Instance.p2MPtxt.text = "MP: " + Mathf.Round(p2MP);
    }


    public void P1Wins()
    {
        // This function will play if these game Over conditions happens if player 1 wins:
        // Condition #1 - Player 2 lose all of its lives whilist Player 1 still has remaining lives.
        // Condition #2 -  Player 2 has less lives than player 1 once the countdown time has reaches to 0.
        if (p2Lives <= 0)
        {
            Time.timeScale = 0f;
            game_over = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            p1WinUI.SetActive(true);
            menuButton.SetActive(true);    
        }
        if (countdownTimer <= 0)
        {
            if (p1Lives > p2Lives)
            {
                Time.timeScale = 0f;
                game_over = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                p1WinUI.SetActive(true);
                menuButton.SetActive(true);
            }
        }
    }

    public void P2Wins()
    {
        // This function will play if these game Over conditions happens if player 2 wins:
        // Condition #1 - Player 1 lose all of its lives whilist Player 2 still has remaining lives.
        // Condition #2 -  Player 1 has less lives than player 2 once the countdown time has reaches to 0
        if (p1Lives <= 0)
        {
            Time.timeScale = 0f;
            game_over = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            p2WinUI.SetActive(true);
            menuButton.SetActive(true);
            
        }
        if (countdownTimer <= 0)
        {
            if (p2Lives > p1Lives)
            {
                Time.timeScale = 0f;
                game_over = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                p2WinUI.SetActive(true);
                menuButton.SetActive(true);
            }
        }
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

}
