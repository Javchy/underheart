using UnityEngine;
using UnityEngine.Events;

public class pressionplate : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    private UnityEvent _collisionEntered;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("activate")]
    public void activate()
    {
        _animator.SetTrigger("activate");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _collisionEntered?.Invoke();
    }

 
}

