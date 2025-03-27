using UnityEngine;

public class door : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu ("open")]
    public void open()
    {
        _animator.SetTrigger("open");
    }
}
