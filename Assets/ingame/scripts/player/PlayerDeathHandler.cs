using UnityEngine;
using System.Collections;

public class PlayerDeathHandler : MonoBehaviour
{
    public float respawnDelay = 1.5f;
    private audioManagerr audioManager;

    public deathfader deathFader;
    public camera_manager camManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagerr>();
    }

    public void Die()
    {
        StartCoroutine(DieRoutine());
    }

    private IEnumerator DieRoutine()
    {
        Debug.Log("Début de DieRoutine");

        // 1. Stop caméra
        if (camManager != null)
            camManager.SetFollowEnabled(false);

        // 2. Son
        audioManager.Playsfx(audioManager.death);

        // 3. Visuel joueur OFF
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // 4. Fade out
        if (deathFader != null)
            yield return deathFader.FadeOut();

        // 5. Respawn
        RespawnManager.instance.Respawn(gameObject);

        // 6. Visuel joueur ON
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        // 7. Fade in
        if (deathFader != null)
            yield return deathFader.FadeIn();

        // 8. Reactiver caméra
        if (camManager != null)
            camManager.SetFollowEnabled(true);
    }
}
