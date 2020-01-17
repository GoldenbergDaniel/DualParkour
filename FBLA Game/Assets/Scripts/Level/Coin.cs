using UnityEngine;
using Colors;

public class Coin : MonoBehaviour
{
    public Transform pickUpParticles;

    public float yRot = 0;
    public bool isHidden;

    private void Update()
    {
        // the passive rotation of the coin
        transform.Rotate(0, -yRot, 0);

        // whether coin starts hidden
        if (isHidden)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GameColors.yellowColor;
        }
    }

    // ability to pickup coins
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check visibility
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
