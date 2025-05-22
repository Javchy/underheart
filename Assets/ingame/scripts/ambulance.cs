using UnityEngine;

public class ambulance : MonoBehaviour
{
    audioManagerr audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagerr>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            audioManager.Playsfx(audioManager.ambulance);
    }
}
