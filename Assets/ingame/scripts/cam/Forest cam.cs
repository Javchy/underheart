using UnityEngine;

public class Forestcam : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    void Update()
    {
        // On garde Y et Z de la caméra actuelle
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
    }
}
