using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    Player bluePlayer;
    Player redPlayer;

    void Start()
    {
        bluePlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        redPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            bluePlayer.Die();
            redPlayer.Die();
        }
    }
}
