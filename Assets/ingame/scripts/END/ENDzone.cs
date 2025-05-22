using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDzone : MonoBehaviour
{
    public SceneFader sceneFader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneFader.FadeToScene("end");
        }
    }


}
