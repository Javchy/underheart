using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActivated = false;
    private bool playerInRange = false;
    audioManagerr audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagerr>();
    }
    private void Update()
    {
        
        if (playerInRange && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        audioManager.Playsfx(audioManager.checkpoint);
        Debug.Log("Checkpoint activé !");
        isActivated = true;
        RespawnManager.instance.SetCheckpoint(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
