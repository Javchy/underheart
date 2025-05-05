using UnityEngine;

public class key_controller : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            

            KeyCollector collector = collision.gameObject.GetComponent<KeyCollector>();
            if (collector != null)
            {
                collector.CollectKey();
            }
           

            Destroy(gameObject); 
        }
    }
}

