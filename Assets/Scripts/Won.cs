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
        if (points > 0)
        {
            if (points > 1000)
            {
                if (points > 10000)
                {
                    stars[2].GetComponent<Image>().sprite = unlockedStar;
                }
                stars[1].GetComponent<Image>().sprite = unlockedStar;
            }
            stars[0].GetComponent<Image>().sprite = unlockedStar;
        }

        int n = 0;
        if (points > 0)
        {
            if (points > 1000)
            {
                if (points > 10000)
                {
                    n = 3;
                }
                else
                {
                    n = 2;
                }
            }
            else
            {
                n = 1;
            }
        }
        PlayerPrefs.SetInt(key, n);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("currentLevel", GameManager.Instance.currentLevel + 1);
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void TryAgain()
    {
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
