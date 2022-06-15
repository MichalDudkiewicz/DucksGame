using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public Dictionary<int, bool> levels;
    public List<Sprite> unlockedSprite;
    public GameObject unlockedStarPrefab;
    public GameObject lockedStarPrefab;

    public List<GameObject> levelsButtons;


    void OnEnable()
    {
        levels = new Dictionary<int, bool>();

        levelsButtons[0].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
        levelsButtons[1].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(2));
        levelsButtons[2].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(3));
        levelsButtons[3].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(4));
        levelsButtons[4].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(5));
        levelsButtons[5].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(6));
        levelsButtons[6].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(7));
        levelsButtons[7].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(8));
        levelsButtons[8].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(9));
        for (int i = 1; i <=9; i++)
        {
            int levelUnlocked = PlayerPrefs.GetInt("level" + i.ToString());
            bool isLevelUnlocked = levelUnlocked == 1 || i == 1;
            levels.Add(i, isLevelUnlocked);

            if (isLevelUnlocked)
            {
                levelsButtons[i - 1].GetComponent<Image>().sprite = unlockedSprite[i - 1];
                string key = i.ToString() + "stars";
                int stars = PlayerPrefs.GetInt(key);

                float width = levelsButtons[i - 1].GetComponent<Button>().targetGraphic.GetComponent<Image>().rectTransform.rect.width * Screen.dpi/640;
                float height = levelsButtons[i - 1].GetComponent<Button>().targetGraphic.GetComponent<Image>().rectTransform.rect.height * Screen.dpi / 640;

                Vector3 first = new Vector3(width/4, 0.4f * height, 0);
                Vector3 firstPosition = levelsButtons[i - 1].transform.position - first;

                Vector3 second = new Vector3(0.0f, 0.35f * height, 0);
                Vector3 secondPosition = levelsButtons[i - 1].transform.position - second;

                Vector3 third = new Vector3(-width/4, 0.4f * height, 0);
                Vector3 thirdPosition = levelsButtons[i - 1].transform.position - third;

                switch (stars)
                {
                    case 1:
                        Instantiate(unlockedStarPrefab, firstPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(lockedStarPrefab, secondPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(lockedStarPrefab, thirdPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        break;
                    case 2:
                        Instantiate(unlockedStarPrefab, firstPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(unlockedStarPrefab, secondPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(lockedStarPrefab, thirdPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        break;
                    case 3:
                        Instantiate(unlockedStarPrefab, firstPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(unlockedStarPrefab, secondPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(unlockedStarPrefab, thirdPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        break;
                    default: // case 0
                        Instantiate(lockedStarPrefab, firstPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(lockedStarPrefab, secondPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        Instantiate(lockedStarPrefab, thirdPosition, Quaternion.identity, levelsButtons[i - 1].transform);
                        break;
                }

            }
            else
            {
                levelsButtons[i-1].GetComponent<Button>().interactable = false;
            }
        }
    }

    void ButtonClicked(int buttonNo)
    {
        MenuSoundManager.Instance.PlayBtn();
        PlayerPrefs.SetInt("currentLevel", buttonNo);
        SceneManager.LoadScene("SampleScene");
    }
}
