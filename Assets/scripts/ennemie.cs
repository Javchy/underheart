using UnityEngine;

public class ennemie : MonoBehaviour
{
    public Transform player;  // R�f�rence au joueur
    public float vitesse = 5f;  // Vitesse de d�placement de l'objet
    public float delaiCalcul = 0.5f;  // D�lai avant de recalculer la direction (en secondes)

    private float timer = 0f;  // Timer pour suivre le d�lai
    private Vector2 direction;  // Direction actuelle vers le joueur

    void Update()
    {
        if (player != null)
        {
            // Incr�menter le timer � chaque frame
            timer += Time.deltaTime;

            // Si le d�lai est �coul�, recalculer la direction
            if (timer >= delaiCalcul)
            {
                // Calculer la direction vers le joueur
                direction = (player.position - transform.position).normalized;

                // R�initialiser le timer
                timer = 0f;
            }

            // D�placer l'objet vers le joueur en suivant la direction calcul�e
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)player.position, vitesse * Time.deltaTime);
        }
    }

}
