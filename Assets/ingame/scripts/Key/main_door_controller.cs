using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class main_door_controller : MonoBehaviour
{
    public Light2D doorLight;
    public Light2D secondaryLight;
    public string nextSceneName = "statue room"; // à définir dans l'inspecteur

    private bool isUnlocked = false;
    private bool isPlayerNear = false;

    void Update()
    {
        if (isUnlocked && isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Chargement de la scène : " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("🔓 Porte déverrouillée !");

        if (doorLight != null)
            doorLight.enabled = true;

        if (secondaryLight != null)
            secondaryLight.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}