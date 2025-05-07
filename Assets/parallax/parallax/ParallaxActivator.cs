using UnityEngine;

public class ParallaxActivator : MonoBehaviour
{
    public ParallaxXY parallaxScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parallaxScript.SetParallaxActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parallaxScript.SetParallaxActive(false);
        }
    }
}
