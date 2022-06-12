using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public Dictionary<int, bool> levels;
    public Sprite unlockedSprite;

    public List<GameObject> levelsButtons;


    void OnEnable()
    {
        levels = new Dictionary<int, bool>();
        levels[1] = true;
        levelsButtons[0].GetComponent<Image>().sprite = unlockedSprite;
        levelsButtons[0].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
        levelsButtons[1].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(2));
        levelsButtons[2].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(3));
        levelsButtons[3].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(4));
        levelsButtons[4].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(5));
        levelsButtons[5].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(6));
        levelsButtons[6].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(7));
        levelsButtons[7].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(8));
        levelsButtons[8].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(9));
        for (int i = 2; i <=9; i++)
        {
            int levelUnlocked = PlayerPrefs.GetInt("level" + i.ToString());
            bool isLevelUnlocked = levelUnlocked == 1;
            levels.Add(i, isLevelUnlocked);

            if (isLevelUnlocked)
            {
                levelsButtons[i - 1].GetComponent<Image>().sprite = unlockedSprite;
            }
            else
            {
                levelsButtons[i-1].GetComponent<Button>().interactable = false;
            }
        }
    }

    void ButtonClicked(int buttonNo)
    {
        PlayerPrefs.SetInt("currentLevel", buttonNo);
        SceneManager.LoadScene("SampleScene");
    }
}
