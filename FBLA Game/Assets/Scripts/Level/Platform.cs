using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    private Color32 initialColor;
    private LayerMask initialPlatformLayer;
    private LayerMask initialPlayerLayer;

    public bool alternatingPlatform;

    public float initialDelay;
    public float delay;

    private void Start()
    {
        // sets starting colors
        initialColor = GetComponent<SpriteRenderer>().color;
        initialPlatformLayer = gameObject.layer;
        initialPlayerLayer = GetComponent<PlatformEffector2D>().colliderMask;

        if (alternatingPlatform)
        {
            StartCoroutine(Alternate());
        }
    }

    // changes properties of the platform
    public void ChangeProperties(Color32 color, LayerMask playerLayer, int platformLayer)
    {
        GetComponent<SpriteRenderer>().color = color;

        GetComponent<PlatformEffector2D>().colliderMask = playerLayer;

        gameObject.layer = platformLayer;
    }

    // resets properties back to original
    public void ResetProperties()
    {
        GetComponent<SpriteRenderer>().color = initialColor;

        GetComponent<PlatformEffector2D>().colliderMask = initialPlayerLayer;

        gameObject.layer = initialPlatformLayer;
    }

    // whetrher the platform alternates
    public IEnumerator Alternate()
    {
        yield return new WaitForSeconds(initialDelay);

        // loops for the rest of the level
        // the platform visibility and colllider is toggled 
        while (true)
        {
            yield return new WaitForSeconds(delay);

            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlatformEffector2D>().enabled = false;
            
            gameObject.layer = LayerMask.NameToLayer("Default");

            yield return new WaitForSeconds(delay);

            GetComponent<SpriteRenderer>().color = initialColor;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<PlatformEffector2D>().enabled = true;

            gameObject.layer = initialPlatformLayer;
        }
    }
}
