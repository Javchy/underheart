using UnityEngine;

public class ParallaxEnY : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactorY = 0.5f; // 0 = fixe, 1 = suit la caméra
    public float minY = -10f;
    public float maxY = 10f;

    private Vector3 startPosition;
    private float lastCameraY;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        startPosition = transform.position;
        lastCameraY = cameraTransform.position.y;
    }

    void LateUpdate()
    {
        float deltaY = cameraTransform.position.y - lastCameraY;

        float newY = transform.position.y + deltaY * parallaxFactorY;
        newY = Mathf.Clamp(newY, minY, maxY);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        lastCameraY = cameraTransform.position.y;
    }
}
