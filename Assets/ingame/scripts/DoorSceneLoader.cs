using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class DoorSceneLoader : MonoBehaviour
{

    private bool playerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("cave");
        }
    }
}
