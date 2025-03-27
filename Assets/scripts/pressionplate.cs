using UnityEngine;
using UnityEngine.Events;

public class pressionplate : MonoBehaviour
{

   

    [SerializeField]
    private UnityEvent _collisionEntered;
  

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        
            _collisionEntered? .Invoke();
        
    }
}
