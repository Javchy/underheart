using UnityEngine;

public class ennemie : MonoBehaviour
{
    public Transform player;  
    public float vitesse = 5f;  
    public float delaiCalcul = 0.5f;  // D�lai avant de recalculer la direction (en secondes)

    private float timer = 0f; 
    private Vector2 direction;  
    public Transform centreObjet; 
    public float rayonMaximale = 5f;
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


        if (centreObjet != null)
        {
            // Calculer la direction et la distance entre l'ennemi et le centre
            Vector3 direction = transform.position - centreObjet.position;
            float distance = direction.magnitude;

            // Si l'ennemi d�passe le rayon maximal
            if (distance > rayonMaximale)
            {
                // Normaliser la direction pour d�placer l'ennemi jusqu'� la limite du rayon
                Vector3 directionNormalisee = direction.normalized;
                transform.position = centreObjet.position + directionNormalisee * rayonMaximale;
            }
        }
    }

}
