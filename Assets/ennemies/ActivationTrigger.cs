using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    public GameObject ennemi;  // L�ennemi � activer/d�sactiver

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ennemi.SetActive(true);  // Active l'ennemi
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ennemi.SetActive(false);  // D�sactive l'ennemi quand le joueur sort
        }
    }
}
