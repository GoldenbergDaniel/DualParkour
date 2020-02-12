using UnityEngine;
using System.Collections;

public class Buffs : MonoBehaviour
{
    private Movement mov;
    
    private float jump;
    private float initialJump;

    private void Start()
    {
        jump = GetComponent<Movement>().jumpHeight;

        mov = GetComponent<Movement>();
    }

    public IEnumerator JumpBoost(float multiplier, float duration)
    {
        jump *= multiplier;

        mov.jumpHeight = jump;

        jump /= multiplier;

        yield return new WaitForSeconds(duration);

        mov.jumpHeight = jump;
    }
}
