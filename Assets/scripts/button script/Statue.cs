using UnityEngine;

public class Statue : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("play")]
    public void play()
    {
        _animator.SetTrigger("play");
    }
}
