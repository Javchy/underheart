using UnityEngine;

public class affichageMap : MonoBehaviour
{
    public GameObject canvasToShow; // Le canvas à afficher
    private bool isPlayerInZone = false;
    private bool isCanvasVisible = false;

    void Update()
    {
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            isCanvasVisible = !isCanvasVisible;
            canvasToShow.SetActive(isCanvasVisible);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            isCanvasVisible = false;
            canvasToShow.SetActive(false);
        }
    }
}