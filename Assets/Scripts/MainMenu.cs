using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject options;

    private void Start()
    {
        options = GameObject.Find("Options");
        options.SetActive(false);
    }

    public void Play()
    {
        MenuSoundManager.Instance.PlayBtn();
        SceneManager.LoadScene("Select Level");
    }

    public void Options()
    {
        MenuSoundManager.Instance.PlayBtn();
        options.SetActive(true);
    }

    public void ButtonSound()
    {
        MenuSoundManager.Instance.PlayBtn();
    }
}
