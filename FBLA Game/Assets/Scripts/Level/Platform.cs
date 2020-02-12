using UnityEngine;
using System.Collections;
using Colors;

public class Platform : MonoBehaviour
{
    public LayerMask blue;
    public LayerMask red;
    public LayerMask purple;
    
    private Color32 initialColor;
    private LayerMask initialPlatformLayer;
    private LayerMask initialPlayerLayer;

    public bool alternatingPlatform;
    public bool changeOnTouch;

    public float initialDelay;
    public float onDelay;
    public float offDelay;

    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private PlatformEffector2D pe;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        pe = GetComponent<PlatformEffector2D>();
        
        initialColor = sr.color;
        initialPlatformLayer = gameObject.layer;
        initialPlayerLayer = pe.colliderMask;
        
        if (alternatingPlatform)
        {
            StartCoroutine(Alternate());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (changeOnTouch)
        {
            if (other.gameObject.CompareTag("Player1"))
            {
                ChangeProperties(11);
                
                changeOnTouch = false;
            }
            else if (other.gameObject.CompareTag("Player2"))
            {
                ChangeProperties(12);

                changeOnTouch = false;
            }
        }
    }

    // changes properties of the platform
    public void ChangeProperties(int layer)
    {
        switch (layer)
        {
            case 11:
                sr.color = GameColors.blue;
                pe.colliderMask = blue;
                gameObject.layer = 11;
                break;
            case 12:
                sr.color = GameColors.red;
                pe.colliderMask = red;
                gameObject.layer = 12;
                break;
            case 0:
                sr.color = GameColors.purple;
                pe.colliderMask = purple;
                gameObject.layer = 0;
                break;
        }
    }

    // resets properties back to original
    public void ResetProperties()
    {
        sr.color = initialColor;
        pe.colliderMask = initialPlayerLayer;
        gameObject.layer = initialPlatformLayer;
    }

    // whether the platform alternates
    private IEnumerator Alternate()
    {
        yield return new WaitForSeconds(initialDelay);
        
        while (true)
        {
            yield return new WaitForSeconds(onDelay);

            sr.color = new Color(0, 0, 0, 0);
            bc.enabled = false;
            pe.enabled = false;
            
            gameObject.layer = LayerMask.NameToLayer("Default");

            yield return new WaitForSeconds(offDelay);

            sr.color = initialColor;
            bc.enabled = true;
            pe.enabled = true;

            gameObject.layer = initialPlatformLayer;
        }
    }
}
