using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Won : MonoBehaviour
{
    public Text level;
    public Text score;
    public Sprite unlockedStar;

    public List<GameObject> stars;

    public void ShowStars()
    {
        int points = GameManager.Instance.points;
        string key = GameManager.Instance.currentLevel.ToString() + "stars";
        stars[0].GetComponent<Image>().sprite = unlockedStar;
        if (GameManager.Instance.ducks.Count > 1)
        {
            if (points > 250)
            {
                if (points > 500)
                {
                    stars[2].GetComponent<Image>().sprite = unlockedStar;
                }
                stars[1].GetComponent<Image>().sprite = unlockedStar;
            }
        }

        int n = 1;
        if (GameManager.Instance.ducks.Count > 1)
        {
            if (points > 250)
            {
                if (points > 500)
                {
                    n = 3;
                }
                else
                {
                    n = 2;
                }
            }
        }
        PlayerPrefs.SetInt(key, n);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("currentLevel", GameManager.Instance.currentLevel + 1);
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("Main Menu");
        MenuSoundManager.Instance.MenuMusic();

        Time.timeScale = 1f;
    }

    public void TryAgain()
    {
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
