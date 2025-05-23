using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Transform player;
    public float vitesse = 3f;
    public float delaiCalcul = 0.5f;

    private float timer = 0f;
    private Vector2 direction;
    public Transform centreObjet;
    public float rayonMaximale = 5f;

    // Position de départ
    private Vector3 pointApparition;

    // Paramètres de bruit organique
    public float perlinAmplitude = 0.5f;
    public float perlinFrequence = 1f;
    private Vector2 perlinOffset;

    void Start()
    {
        pointApparition = transform.position; // Enregistre la position initiale

        perlinOffset = new Vector2(Random.Range(0f, 100f), Random.Range(0f, 100f));
    }

    void Update()
    {
        if (player != null)
        {
            timer += Time.deltaTime;

            if (timer >= delaiCalcul)
            {
                Vector2 targetDir = ((Vector2)player.position - (Vector2)transform.position).normalized;
                direction = Vector2.Lerp(direction, targetDir, 0.1f);

                timer = 0f;
            }

            float noiseX = Mathf.PerlinNoise(Time.time * perlinFrequence + perlinOffset.x, 0f) - 0.5f;
            float noiseY = Mathf.PerlinNoise(0f, Time.time * perlinFrequence + perlinOffset.y) - 0.5f;
            Vector2 noise = new Vector2(noiseX, noiseY) * perlinAmplitude;

            Vector2 finalDirection = direction + noise;
            Vector2 newPos = (Vector2)transform.position + finalDirection * vitesse * Time.deltaTime;
            transform.position = newPos;
        }

        if (centreObjet != null)
        {
            Vector3 versCentre = transform.position - centreObjet.position;
            float distance = versCentre.magnitude;

            if (distance > rayonMaximale)
            {
                Vector3 directionNormalisee = versCentre.normalized;
                transform.position = centreObjet.position + directionNormalisee * rayonMaximale;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = pointApparition;
        }
    }
}
