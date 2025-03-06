using UnityEngine;

public class ennemie : MonoBehaviour
{
    public Transform player;  // Référence au joueur
    public float vitesse = 5f;  // Vitesse de déplacement de l'objet
    public float delaiCalcul = 0.5f;  // Délai avant de recalculer la direction (en secondes)

    private float timer = 0f;  // Timer pour suivre le délai
    private Vector2 direction;  // Direction actuelle vers le joueur

    void Update()
    {
        if (player != null)
        {
            // Incrémenter le timer à chaque frame
            timer += Time.deltaTime;

            // Si le délai est écoulé, recalculer la direction
            if (timer >= delaiCalcul)
            {
                // Calculer la direction vers le joueur
                direction = (player.position - transform.position).normalized;

                // Réinitialiser le timer
                timer = 0f;
            }

            // Déplacer l'objet vers le joueur en suivant la direction calculée
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)player.position, vitesse * Time.deltaTime);
        }
    }

}
