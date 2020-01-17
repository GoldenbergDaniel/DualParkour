using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public bool blueIsFinished;
    [HideInInspector] public bool redIsFinished;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI awardText;

    private int maxCoins = 12;

    private Animator animator;
    private int levelToLoad;

    private string award;

    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Checks if both players have finished the level
        if (blueIsFinished && redIsFinished)
        {
            LoadNextScene();
        }

        // When the game is complete, run the game complete function
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            OnGameComplete();
        }

        // exits the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // loads the next level
    private void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // loads a specific level
    public void LoadScene(int levelIndex)
    {
        levelToLoad = levelIndex;

        animator.SetTrigger("FadeOut");
    }

    // fade animation
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Asssigns the award to the player
    private void OnGameComplete()
    {
        int coins = Statistics.coins;
        int deaths = Statistics.deaths;

        // writes number of coins and deaths on screen
        coinText.text = "Coins: " + coins + "/" + maxCoins;
        deathText.text = "Deaths: " + deaths;

        // Player gets an award based on deaths and coins
        if (coins >= 12 && deaths == 0)
        {
            award = "America";
            awardText.color = Color.red;
        }
        else if (coins >= 10 && deaths <= 5)
        {
            award = "Leader";
            awardText.color = Color.blue;
        }
        else if (coins >= 7 && deaths <= 10)
        {
            award = "Business";
            awardText.color = Color.green;
        }
        else if (coins >= 3 || deaths >= 15)
        {
            award = "Future";
            awardText.color = Color.yellow;
        }
        else 
        {
            award = "None";
        }

        // Writes the award on the screen
        awardText.text = "Award: " + award;
    }
}
