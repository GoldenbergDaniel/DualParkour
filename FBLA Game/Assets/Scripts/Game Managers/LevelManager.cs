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
    public TextMeshProUGUI infoText;

    private int maxCoins = 13;

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
        if (SceneManager.GetActiveScene().buildIndex == 8)
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

    // Assigns the award to the player
    private void OnGameComplete()
    {
        int coins = Statistics.coins;
        int deaths = Statistics.deaths;

        // writes number of coins and deaths on screen
        coinText.text = "Coins: " + coins + "/" + maxCoins;
        deathText.text = "Deaths: " + deaths;

        // Player gets an award based on deaths and coins
        if (coins >= maxCoins && deaths == 0)
        {
            award = "America";
            awardText.color = Color.red;
            infoText.text = "You demonstrated outstanding skills in agility and teamwork, mastering the art of parkour. " +
                            "Thus, you are granted the highest award possible, the America award ";
            infoText.color = Color.red;
        }
        else if (coins >= 10 && deaths <= 7)
        {
            award = "Leader";
            awardText.color = Color.blue;
            infoText.text = "You demonstrated great teamwork and agility skills, which grants you the second highest award, " +
                            "the Leader award.";
            infoText.color = Color.blue;
        }
        else if (coins >= 7 && deaths <= 13)
        {
            award = "Business";
            awardText.color = Color.green;
            infoText.text = "You demonstrated alright skills in teamwork and agility, thus granting you the Business award. " +
                            "Maybe you should practice some more!";
            infoText.color = Color.green;
        }
        else if (coins >= 4 && deaths <= 20)
        {
            award = "Future";
            awardText.color = Color.yellow;
            infoText.text = "You got the Future award, which is alright, but could have been better. Try working better as a team.";
            infoText.color = Color.yellow;
        }
        else 
        {
            award = "None";
            infoText.text = "You did not get any award and should probably try again. Make sure to keep teamwork in mind!";
        }

        // Displays the award on the screen
        awardText.text = "Award: " + award;
    }
}
