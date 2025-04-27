using UnityEngine;

public class lightOrb : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float range = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = transform.position;
        PickNewTarget();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        Vector2 randomOffset = Random.insideUnitCircle * range;
        targetPos = startPos + new Vector3(randomOffset.x, randomOffset.y, 0);
    }
}
