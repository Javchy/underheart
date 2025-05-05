using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class statue : MonoBehaviour
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
