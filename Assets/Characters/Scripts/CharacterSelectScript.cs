using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    // Player 1
    public GameObject[] charactersList;
    public int selectedCharacter;

    public GameObject kylePic1;
    public GameObject rexPic1;
    public GameObject robinPic1;
    public GameObject lloydPic1;

    // CPU (AI)
    public GameObject[] charactersAIList;
    public int selectedAI;

    public GameObject kylePicAI;
    public GameObject rexPicAI;
    public GameObject robinPicAI;
    public GameObject lloydPicAI;

    public bool inGamePlay = false;

    public GameObject player;


    public bool p1Selected;
    public bool cpuSelected;
    public GameObject startButton;

    public AudioSource callKyle;
    public AudioSource callRex;
    public AudioSource callRobin;
    public AudioSource callLloyd;

    void Start()
    {

        int selectedChar = PlayerPrefs.GetInt("CharaID");
        int selectedAIChar = PlayerPrefs.GetInt("AIID");
        if (inGamePlay == true)
        {
            charactersList[selectedChar].SetActive(true);
            charactersAIList[selectedAIChar].SetActive(true);

        }

        p1Selected = false;
        cpuSelected = false;
    }

    void Update()
    {
        if (p1Selected == true && cpuSelected == true)
        {
            startButton.SetActive(true);
        }
        if (p1Selected == false && cpuSelected == false)
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
    public void KyleSelectedAI()
    {
        selectedAI = 0;
        Debug.Log("Kyle AI");
        kylePicAI.SetActive(true);
        rexPicAI.SetActive(false);
        robinPicAI.SetActive(false);
        lloydPicAI.SetActive(false);
        cpuSelected = true;

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
    public void RexSelectedAI()
    {
        selectedAI = 1;
        Debug.Log("Rex AI");
        kylePicAI.SetActive(false);
        rexPicAI.SetActive(true);
        robinPicAI.SetActive(false);
        lloydPicAI.SetActive(false);
        cpuSelected = true;

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
    public void RobinSelectedAI()
    {
        selectedAI = 2;
        Debug.Log("Robin AI");
        kylePicAI.SetActive(false);
        rexPicAI.SetActive(false);
        robinPicAI.SetActive(true);
        lloydPicAI.SetActive(false);
        cpuSelected = true;

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
    public void LloydSelectedAI()
    {
        selectedAI = 3;
        Debug.Log("Lloyd AI");
        kylePicAI.SetActive(false);
        rexPicAI.SetActive(false);
        robinPicAI.SetActive(false);
        lloydPicAI.SetActive(true);
        cpuSelected = true;

        callLloyd.Play();

    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("CharaID", selectedCharacter);
        PlayerPrefs.SetInt("AIID", selectedAI);
        PlayerPrefs.SetInt("ItemID", ItemManager.Instance.selectedItems);
        SceneManager.LoadScene(7);

        p1Selected = false;
        cpuSelected = false;
    }


}
