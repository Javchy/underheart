using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bottleend : MonoBehaviour
{ void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {


            SceneManager.LoadScene("forest end");


        }
    }
}
