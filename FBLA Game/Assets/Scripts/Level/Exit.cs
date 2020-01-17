using UnityEngine;

public class Exit : MonoBehaviour
{
    public string layer;

    private void OnTriggerStay2D(Collider2D other)
    {
        // sets level complete to true
        if (other.gameObject.layer == LayerMask.NameToLayer(layer))
        {
            if (layer == "BluePlayer")
            {
                LevelManager.instance.blueIsFinished = true;
            }
            else if (layer == "RedPlayer")
            {
                LevelManager.instance.redIsFinished = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // sets level complete to false
        if (other.gameObject.layer == LayerMask.NameToLayer(layer))
        {
            if (layer == "BluePlayer")
            {
                LevelManager.instance.blueIsFinished = false;
            }
            else if (layer == "RedPlayer")
            {
                LevelManager.instance.redIsFinished = false;
            }
        }
    }
}
