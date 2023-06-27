using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScriptMutliplayerDungeon : MonoBehaviour
{
    // Player 1
    public GameObject[] charactersList;
    public int selectedCharacter;

    public GameObject kylePic1;
    public GameObject rexPic1;
    public GameObject robinPic1;
    public GameObject lloydPic1;

    // Player 2
    public GameObject[] charactersP2List;
    public int selectedCharacter2;

    public GameObject kylePic2;
    public GameObject rexPic2;
    public GameObject robinPic2;
    public GameObject lloydPic2;

    public bool inGamePlay = false;

    public GameObject player;

    public bool p1Selected;
    public bool p2Selected;
    public GameObject startButton;

    public AudioSource callKyle;
    public AudioSource callRex;
    public AudioSource callRobin;
    public AudioSource callLloyd;
    void Start()
    {


        int selectedChar = PlayerPrefs.GetInt("CharaID");
        int selectedChar2 = PlayerPrefs.GetInt("Chara2ID");
        if (inGamePlay == true)
        {
            charactersList[selectedChar].SetActive(true);
            charactersP2List[selectedChar2].SetActive(true);

        }

        p1Selected = false;
        p2Selected = false;
    }

    void Update()
    {
        if (p1Selected == true && p2Selected == true)
        {
            startButton.SetActive(true);
        }
        if (p1Selected == false && p2Selected == false)
        {
            startButton.SetActive(false);
        }
    }

    public void KyleSelected()
    {
        selectedCharacter = 0;
        Debug.Log("Kyle");
        kylePic1.SetActive(true);
        rexPic1.SetActive(false);
        robinPic1.SetActive(false);
        lloydPic1.SetActive(false);
        p1Selected = true;

        callKyle.Play();

    }
    public void KyleSelectedP2()
    {
        selectedCharacter2 = 0;
        Debug.Log("Kyle 2");
        kylePic2.SetActive(true);
        rexPic2.SetActive(false);
        robinPic2.SetActive(false);
        lloydPic2.SetActive(false);
        p2Selected = true;

        callKyle.Play();
    }
    public void RexSelected()
    {
        selectedCharacter = 1;
        Debug.Log("Rex");
        kylePic1.SetActive(false);
        rexPic1.SetActive(true);
        robinPic1.SetActive(false);
        lloydPic1.SetActive(false);
        p1Selected = true;

        callRex.Play();
    }
    public void RexSelectedP2()
    {
        selectedCharacter2 = 1;
        Debug.Log("Rex 2");
        kylePic2.SetActive(false);
        rexPic2.SetActive(true);
        robinPic2.SetActive(false);
        lloydPic2.SetActive(false);
        p2Selected = true;

        callRex.Play();
    }
    public void RobinSelected()
    {
        selectedCharacter = 2;
        Debug.Log("Robin");
        kylePic1.SetActive(false);
        rexPic1.SetActive(false);
        robinPic1.SetActive(true);
        lloydPic1.SetActive(false);
        p1Selected = true;

        callRobin.Play();
    }
    public void RobinSelectedP2()
    {
        selectedCharacter2 = 2;
        Debug.Log("Robin 2");
        kylePic2.SetActive(false);
        rexPic2.SetActive(false);
        robinPic2.SetActive(true);
        lloydPic2.SetActive(false);
        p2Selected = true;

        callRobin.Play();
    }
    public void LloydSelected()
    {
        selectedCharacter = 3;
        Debug.Log("Lloyd");
        kylePic1.SetActive(false);
        rexPic1.SetActive(false);
        robinPic1.SetActive(false);
        lloydPic1.SetActive(true);
        p1Selected = true;

        callLloyd.Play();
    }
    public void LloydSelectedP2()
    {
        selectedCharacter2 = 3;
        Debug.Log("Lloyd 2");
        kylePic2.SetActive(false);
        rexPic2.SetActive(false);
        robinPic2.SetActive(false);
        lloydPic2.SetActive(true);
        p2Selected = true;

        callLloyd.Play();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("CharaID", selectedCharacter);
        PlayerPrefs.SetInt("Chara2ID", selectedCharacter2);
        PlayerPrefs.SetInt("ItemID", ItemManager.Instance.selectedItems);
        SceneManager.LoadScene(12);
    }
}
