using UnityEngine;

public class BuffTile : MonoBehaviour
{
    public enum BuffType {jumpBuff}
    public BuffType type;

    public float multiplier;
    public float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            switch (type)
            {
                case BuffType.jumpBuff:
                    StartCoroutine(other.GetComponent<Buffs>().JumpBoost(multiplier, duration));
                    other.GetComponent<Movement>().Jump();
                    break;
            }
        }
    }
}
