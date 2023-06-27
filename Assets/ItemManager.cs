using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;

    public GameObject[] items;
    public int selectedItems;

    public bool inGamePlay = false;

    public AudioSource itemsOn;
    public AudioSource itemsOff;

    void Start()
    {
        int selectedItems = PlayerPrefs.GetInt("ItemID");

        if (inGamePlay == true && selectedItems == 1)
       {
            items[selectedItems].SetActive(true);
       }
        if (inGamePlay == true && selectedItems == 0)
        {
            items[selectedItems].SetActive(false);
        }
    }

    void Awake()
    {
        instance = this;
    }

    public static ItemManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void ItemsOn()
    {
        selectedItems = 1;
        itemsOn.Play();
    }

    public void ItemsOff()
    {
        selectedItems = 0;
        itemsOff.Play();
    }
}
