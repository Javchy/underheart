using UnityEngine;
using UnityEngine.Rendering.Universal; // Pour Light2D

public class key_controller : MonoBehaviour
{
    public Light2D targetLight; // 💡 Lumière à allumer quand on ramasse la clé

    private void Start()
    {
        if (targetLight != null)
        {
            targetLight.enabled = false; // On s'assure qu'elle est éteinte au début
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeyCollector collector = collision.gameObject.GetComponent<KeyCollector>();
            if (collector != null)
            {
                collector.CollectKey();
            }

            if (targetLight != null)
            {
                targetLight.enabled = true; // 💡 Allume la lumière !
            }

            Destroy(gameObject); // Supprime la clé ramassée
        }
    }
}

