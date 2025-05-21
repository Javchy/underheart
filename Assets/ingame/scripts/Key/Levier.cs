using UnityEngine;
 // Pour Light2D

public class Levier : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D leverLight;         // Light2D pour URP
    public DoorManager doorManager;     // R�f�rence au gestionnaire de porte

    private bool isActivated = false;
    private bool playerInRange = false;
    audioManagerr audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagerr>();
    }
    void Start()
    {
       
        leverLight = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        if (leverLight != null)
            leverLight.enabled = false;
    }

    void Update()
    {
        if (playerInRange && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLevier();
        }
    }

    void ActivateLevier()
    {
        audioManager.Playsfx(audioManager.lever);
        isActivated = true;

        if (leverLight != null)
            leverLight.enabled = true;

        if (doorManager != null)
            doorManager.RegisterLevier();

        Debug.Log("Levier activ� !");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
