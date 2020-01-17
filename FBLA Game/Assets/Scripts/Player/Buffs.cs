using UnityEngine;
using System.Collections;

public class Buffs : MonoBehaviour
{
    private float jump;
    private float initialJump;

    private void Start()
    {
        jump = GetComponent<Movement>().jumpHeight;
    }

    public IEnumerator JumpBoost(float multiplier, float duration)
    {
        jump *= multiplier;

        GetComponent<Movement>().jumpHeight = jump;

        jump /= multiplier;

        yield return new WaitForSeconds(duration);

        GetComponent<Movement>().jumpHeight = jump;
    }
}
