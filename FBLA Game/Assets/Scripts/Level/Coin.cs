using UnityEngine;
using Colors;

public class Coin : MonoBehaviour
{
    public Transform pickUpParticles;

    public float rot = 0;
    public bool isHidden;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // the passive rotation of the coin
        transform.Rotate(0, -rot, 0);

        // whether coin starts hidden
        if (isHidden)
        {
            sr.color = new Color(0, 0, 0, 0);
        }
        else
        {
            sr.color = GameColors.yellow;
        }
    }

    // ability to pickup coins
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHidden)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                PickUp();
            }
        }
    }

    // When coin is picked up
    private void PickUp()
    {
        Statistics.coins += 1;

        Instantiate(pickUpParticles, transform.position, transform.rotation);

        AudioManager.instance.Play("Coin");

        gameObject.SetActive(false);
    }
}
