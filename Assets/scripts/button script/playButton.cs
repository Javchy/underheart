using UnityEngine;
using UnityEngine.SceneManagement;




public class playButton : MonoBehaviour
{
    void Start()
    {
        // Appelle la méthode StartSceneManagement après 5 secondes
        Invoke("PlayGame", 5f);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
