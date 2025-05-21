using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject mapCanvas; // Assigne le canvas ici
    public playerMovement playerScript; // Référence au script de mouvement

    private bool isMapOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Touche M pressée");
            ToggleMap();
        }
    }

    void ToggleMap()
    {
        isMapOpen = !isMapOpen;
        mapCanvas.SetActive(isMapOpen);

        // Désactiver ou réactiver le mouvement
        if (playerScript != null)
            playerScript.enabled = !isMapOpen;
    }
}
