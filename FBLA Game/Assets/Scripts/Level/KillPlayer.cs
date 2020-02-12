using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject[] purplePlatforms;
    
    private Player bluePlayer;
    private Player redPlayer;

    private void Start()
    {
        bluePlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        redPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        bluePlayer.Die();
        redPlayer.Die();
        
        foreach (GameObject platform in purplePlatforms)
        {
            Platform script = platform.GetComponentInChildren<Platform>();
            
            script.ChangeProperties(0);
            script.changeOnTouch = true;
        }
    }
}
