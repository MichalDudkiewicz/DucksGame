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
        SceneManager.LoadScene("Select Level");
    }
}
