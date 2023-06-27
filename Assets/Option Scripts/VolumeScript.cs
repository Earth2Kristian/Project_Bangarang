using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            // The volume will be set the value to 1 when the option section opens
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        // This function will allow the volume to be change in terms of the value
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        // The function will allow the volume to be loaded
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        // The function will allow the volume to be saved
        PlayerPrefs.GetFloat("musicVolume", volumeSlider.value);
    }
}
