using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    public GameObject ennemi;  // L’ennemi à activer

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ennemi.SetActive(true);  // Active l'ennemi
        }
    }
}
