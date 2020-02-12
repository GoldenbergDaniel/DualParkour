using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject controlsScreen;
    
    // starts the game
    public void PlayGame(int level)
    {
        AudioManager.instance.Play("Click");

        LevelManager.instance.LoadScene(level);
    }

    // quits the game 
    public void QuitGame()
    {
        AudioManager.instance.Play("Click");
        
        Application.Quit();
    }

    // displays the control screen
    public void ControlsScreen()
    {
        AudioManager.instance.Play("Click");
        
        titleScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    // go back to title screen from control screen
    public void Back()
    {
        AudioManager.instance.Play("Click");
        
        controlsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}
