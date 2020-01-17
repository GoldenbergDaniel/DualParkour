using UnityEngine;
using System.Collections.Generic;
using Colors;

public class Button : MonoBehaviour
{
    public LayerMask playerLayer;

    public List<Transform> platforms = new List<Transform>();
    public List<GameObject> coins = new List<GameObject>();

    private Color32 color;
    private int platformLayer;

    private void Update()
    {
        // determines the platform layer
        if (playerLayer == LayerMask.GetMask("Everything"))
        {
            platformLayer = 8;
        }
        else if (playerLayer == LayerMask.GetMask("BluePlayer"))
        {
            platformLayer = 11;
            color = GameColors.blueColor;
        }
        else if (playerLayer == LayerMask.GetMask("RedPlayer"))
        {
            platformLayer = 12;
            color = GameColors.redColor;
        }
    }

    // when button is steped on
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // changes platform properties
            foreach (Transform platform in platforms)
            {
                for (int x = 0; x < platform.childCount; x++)
                {
                    platform.GetChild(x).GetComponent<Platform>().ChangeProperties(color, playerLayer, platformLayer);
                }
            }

            // unhides coins
            foreach (GameObject coin in coins)
            {
                coin.GetComponent<Coin>().isHidden = false;
            }
        }
    }

    // when button is steped off
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // reset platforms
            foreach (Transform platform in platforms)
            {
                for (int x = 0; x < platform.childCount; x++)
                {
                    platform.GetChild(x).GetComponent<Platform>().ResetProperties();
                }
            }

            // resets coin visibility
            foreach (GameObject coin in coins)
            {
                coin.GetComponent<Coin>().isHidden = true;
            }
        }
    }
}
