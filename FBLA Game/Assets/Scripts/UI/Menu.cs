using UnityEngine;

public class Menu : MonoBehaviour
{
    // starts the game
    public void PlayGame()
    {
        AudioManager.instance.Play("Click");

        LevelManager.instance.LoadScene(1);
    }

    // quits the gamne 
    public void QuitGame()
    {
        AudioManager.instance.Play("Click");
        
        Application.Quit();
    }
}
  