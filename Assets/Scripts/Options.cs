using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public Button vibrationsButton;
    public TextMeshProUGUI vibrationsButtonText;

    public Button volumeButton;
    public TextMeshProUGUI volumeButtonText;

    public void Start()
    {
        vibrationsButton.onClick.AddListener(setVibrations);
        volumeButton.onClick.AddListener(setVolume);
    }

    public void setVibrations()
    {
        MenuSoundManager.Instance.PlaySwitch();
        if (PlayerPrefs.GetString("vibrations") == "off")
        {
            PlayerPrefs.SetString("vibrations", "on");
            vibrationsButtonText.text = "VIBRATIONS: ON";
        }
        else
        {
            PlayerPrefs.SetString("vibrations", "off");
            vibrationsButtonText.text = "VIBRATIONS: OFF";
        }
    }

    public void setVolume()
    {
        MenuSoundManager.Instance.PlaySwitch();
        if (PlayerPrefs.GetString("volume") == "off")
        {
            PlayerPrefs.SetString("volume", "on");
            volumeButtonText.text = "VOLUME: ON";
            MenuSoundManager.Instance.Unmute();
        }
        else
        {
            PlayerPrefs.SetString("volume", "off");
            volumeButtonText.text = "VOLUME: OFF";
            MenuSoundManager.Instance.Mute();
        }
    }
}
