using UnityEngine;

public class ParallaxXY : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector2 parallaxFactor = new Vector2(0.3f, 0.3f);
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Vector3 lastCameraPosition;
    private bool parallaxActive = false;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        if (!parallaxActive) return;

        Vector3 delta = cameraTransform.position - lastCameraPosition;

        float newX = transform.position.x + delta.x * parallaxFactor.x;
        float newY = transform.position.y + delta.y * parallaxFactor.y;

        newX = Mathf.Clamp(newX, minPosition.x, maxPosition.x);
        newY = Mathf.Clamp(newY, minPosition.y, maxPosition.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
        lastCameraPosition = cameraTransform.position;
    }

    public void SetParallaxActive(bool active)
    {
        parallaxActive = active;
        lastCameraPosition = cameraTransform.position; 
    }
}
