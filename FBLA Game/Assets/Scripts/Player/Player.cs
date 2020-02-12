using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform spawnPoint;

    public void Die()
    {
        Statistics.deaths += 1;
        AudioManager.instance.Play("Death");

        transform.position = spawnPoint.position;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }
}
