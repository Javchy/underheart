using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomedOutSize = 8f;
    public float zoomSpeed = 2f;
    public float shiftedY = 2f;

    private float originalSize;
    private Transform player;
    private bool isInZone = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalSize = mainCamera.orthographicSize;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
        }
    }

    void Update()
    {
        if (mainCamera == null || player == null) return;

        float targetSize = isInZone ? zoomedOutSize : originalSize;
        float targetY = isInZone ? shiftedY : player.position.y;

        // Smooth zoom
        mainCamera.orthographicSize = Mathf.Lerp(
            mainCamera.orthographicSize,
            targetSize,
            Time.deltaTime * zoomSpeed
        );

        // Smooth Y movement (X non touché)
        Vector3 pos = mainCamera.transform.position;
        pos.y = Mathf.Lerp(pos.y, targetY, Time.deltaTime * zoomSpeed);
        mainCamera.transform.position = pos;
    }
}
