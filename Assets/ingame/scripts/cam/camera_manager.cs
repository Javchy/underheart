using UnityEngine;

public class camera_manager : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    public bool followEnabled = true;

    void Update()
    {
        if (!followEnabled || target == null)
            return;

        Vector3 newPos = new Vector3(target.position.x, target.position.y + 1, yOffset - 10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    public void SetFollowEnabled(bool enabled)
    {
        followEnabled = enabled;
    }
}
