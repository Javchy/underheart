using UnityEngine;

public class ShowCanvasAfterDelay : MonoBehaviour
{
    public GameObject canvasToShow;
    public float delay = 15f;

    void Start()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false); // Assure-toi qu�il est masqu� au d�part
            Invoke(nameof(ShowCanvas), delay);
        }
        else
        {
            Debug.LogWarning("Aucun Canvas assign� !");
        }
    }

    void ShowCanvas()
    {
        canvasToShow.SetActive(true);
    }
}
