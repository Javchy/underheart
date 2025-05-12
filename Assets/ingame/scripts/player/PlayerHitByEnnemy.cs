using UnityEngine;

public class PlayerHitByEnemy : MonoBehaviour
{
    private PlayerDeathHandler deathHandler;

    private void Start()
    {
        deathHandler = GetComponent<PlayerDeathHandler>();
        if (deathHandler == null)
        {
            Debug.LogError("PlayerDeathHandler manquant sur ce GameObject !");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Assure-toi que tes ennemis ont bien le tag "Enemy"
        {
            Debug.Log("Touché par un ennemi !");
            deathHandler.Die();
        }
    }
}
