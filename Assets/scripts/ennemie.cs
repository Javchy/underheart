using UnityEngine;

public class ennemie : MonoBehaviour
{
    public Transform player;  
    public float vitesse = 5f;  
    public float delaiCalcul = 0.5f;  // Délai avant de recalculer la direction (en secondes)

    private float timer = 0f; 
    private Vector2 direction;  
    public Transform centreObjet; 
    public float rayonMaximale = 5f;
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


        if (centreObjet != null)
        {
            // Calculer la direction et la distance entre l'ennemi et le centre
            Vector3 direction = transform.position - centreObjet.position;
            float distance = direction.magnitude;

            // Si l'ennemi dépasse le rayon maximal
            if (distance > rayonMaximale)
            {
                // Normaliser la direction pour déplacer l'ennemi jusqu'à la limite du rayon
                Vector3 directionNormalisee = direction.normalized;
                transform.position = centreObjet.position + directionNormalisee * rayonMaximale;
            }
        }
    }

}
