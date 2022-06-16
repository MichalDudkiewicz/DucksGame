using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Sprite> unlockedSprite;

    public GameObject ui;
    public GameObject breadPrefab;
    public GameObject grainPrefab;
    public GameObject maleDuckPrefab;
    public GameObject femaleDuckPrefab;
    private List<float> possiblePositions = new List<float> { -1.5f, 0, 1.5f };
    public float breadSpawnDelay = 5f;
    private float spawnDeltaTime = 1f;

    private List<DuckBehaviour> ducks;
    private GameObject maleDuck;
    private GameObject femaleDuck;

    public int points = 0;
    public Text pointsText;
    public Text levelText;
    public GameObject levelImage;

    public GameObject wonUI;
    public GameObject lostUI;

    public int currentLevel=1;

    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance is null)
                Debug.Log("Game Manager is null");

            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MenuSoundManager.Instance.GameMusic();
        ShowUI();
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        levelText.text = currentLevel.ToString();
        levelImage.GetComponent<Image>().sprite = unlockedSprite[currentLevel - 1];
        GameEvents.current.onDuckDeath += handleDuckDeath;

        var random = new System.Random();
        int index = random.Next(possiblePositions.Count);
        Vector3 startDuckPosition1 = new Vector3(possiblePositions[index], -4.2f, 0);
        maleDuck = Instantiate(maleDuckPrefab, startDuckPosition1, Quaternion.identity);
        Vector3 startDuckPosition2 = new Vector3(possiblePositions[index], -2.8f, 0);
        femaleDuck = Instantiate(femaleDuckPrefab, startDuckPosition2, Quaternion.identity);
        ducks = new List<DuckBehaviour>();
        ducks.Add(maleDuck.GetComponent<DuckBehaviour>());
        ducks.Add(femaleDuck.GetComponent<DuckBehaviour>());

        wonUI.SetActive(false);
        lostUI.SetActive(false);
    }

    private void handleDuckDeath(DuckBehaviour duck)
    {
        MenuSoundManager.Instance.PlayDeath();
        ducks.Remove(duck);
        for (int i = 0; i < ducks.Count; i ++)
        {
            ref Vector2 origin = ref ducks[i].GetComponent<DuckBehaviour>().originPosition;
            origin = new Vector2(origin.x, -4.2f + i * 1.4f);
        }

        points -= 10000;
    }

    private void FixedUpdate()
    {
        spawnDeltaTime -= Time.deltaTime;
        if (spawnDeltaTime <= 0)
        {
            var random = new System.Random();
            int rInt = random.Next(0, 2);
            int index = random.Next(possiblePositions.Count);
            Vector3 startBreadPosition = new Vector3(possiblePositions[index], 5f, 0);
            
            if (rInt > 0)
            {
                BreadBehaviour bread = Instantiate(breadPrefab, startBreadPosition, Quaternion.identity).GetComponent<BreadBehaviour>();
                bread.breadSpeed *= currentLevel;
            }
            else
            {
                GrainBehaviour grain = Instantiate(grainPrefab, startBreadPosition, Quaternion.identity).GetComponent<GrainBehaviour>();
                grain.grainSpeed *= currentLevel;
            }

            spawnDeltaTime = breadSpawnDelay;
        }

 
        pointsText.text = points.ToString();

        if (ducks.Count == 0)
        {
            Lost();
        }

        if (maleDuck.GetComponent<DuckBehaviour>().hunger > 90 && femaleDuck.GetComponent<DuckBehaviour>().hunger > 90)
        {
            Won();
        }
    }

    private void Lost()
    {
        HideUI();
        Time.timeScale = 0f;
        Debug.Log(currentLevel);
        lostUI.GetComponent<Lost>().level.text = "Lvl. " + currentLevel.ToString();
        lostUI.GetComponent<Lost>().score.text = points.ToString();
        lostUI.SetActive(true);

        MenuSoundManager.Instance.LostSound();
    }

    private void Won()
    {
        HideUI();
        Time.timeScale = 0f;
        wonUI.GetComponent<Won>().level.text = "Lvl. " + currentLevel.ToString();
        wonUI.GetComponent<Won>().score.text = points.ToString();
        wonUI.GetComponent<Won>().ShowStars();
        wonUI.SetActive(true);

        MenuSoundManager.Instance.WonSound();
        PlayerPrefs.SetInt("level" + (GameManager.Instance.currentLevel + 1).ToString(), 1);
    }

    private void HideUI()
    {
        ui.SetActive(false);
    }

    public void ShowUI()
    {
        ui.SetActive(true);
    }
}
