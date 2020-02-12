using UnityEngine;
using System.Collections.Generic;

public class Button : MonoBehaviour
{
    public int layer;
    
    public List<Transform> platforms = new List<Transform>();
    public List<GameObject> coins = new List<GameObject>();

    // when button is stepped on
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // changes platform properties
            foreach (Transform platform in platforms)
            {
                for (int x = 0; x < platform.childCount; x++)
                {
                    platform.GetChild(x).GetComponent<Platform>().ChangeProperties(layer);
                }
            }

            // reveals coins
            foreach (GameObject coin in coins)
            {
                coin.GetComponent<Coin>().isHidden = false;
            }
        }
    }

    // when button is stepped off
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
