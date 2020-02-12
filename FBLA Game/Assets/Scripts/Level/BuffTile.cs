using UnityEngine;

public class BuffTile : MonoBehaviour
{
    public enum BuffType {JumpBuff}
    public BuffType type;

    public float multiplier;
    public float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (type == BuffType.JumpBuff)
            {
                StartCoroutine(other.GetComponent<Buffs>().JumpBoost(multiplier, duration));
                other.GetComponent<Movement>().Jump();
            }
        }
    }
}
