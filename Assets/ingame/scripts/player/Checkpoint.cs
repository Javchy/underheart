using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActivated = false;
    private bool playerInRange = false;

    private void Update()
    {
        
        if (playerInRange && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
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
