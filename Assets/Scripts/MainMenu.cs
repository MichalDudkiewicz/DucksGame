using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject options;
    private GameObject level;
    private void Start()
    {
        options = GameObject.Find("Options");
        options.SetActive(false);

        level = GameObject.Find("Select Level");
        level.SetActive(false);
    }
}
