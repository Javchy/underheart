using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject mapCanvas; // Assigne le canvas ici
    public playerMovement playerScript; // R�f�rence au script de mouvement

    private bool isMapOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Touche M press�e");
            ToggleMap();
        }
    }

    void ToggleMap()
    {
        isMapOpen = !isMapOpen;
        mapCanvas.SetActive(isMapOpen);

        // D�sactiver ou r�activer le mouvement
        if (playerScript != null)
            playerScript.enabled = !isMapOpen;
    }
}
