using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class main_door_controller : MonoBehaviour
{
    public Light2D doorLight;
    public Light2D secondaryLight;
    public string nextSceneName = "statue room"; 

    private bool isUnlocked = false;
    private bool isPlayerNear = false;
    public GameObject txtlock;
    public GameObject txtunlock;

    private void Start()
    {
        if (doorLight != null)
        {
            doorLight.enabled = false; // On s'assure qu'elle est éteinte au début
        }

        if (secondaryLight != null)
        {
            secondaryLight.enabled = false;
        }
    }
    void Update()
    {
        if (isUnlocked && isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
           
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
      

        if (doorLight != null)
            doorLight.enabled = true;

        if (secondaryLight != null)
            secondaryLight.enabled = true;

      txtlock.SetActive(false);
      txtunlock.SetActive(true);
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