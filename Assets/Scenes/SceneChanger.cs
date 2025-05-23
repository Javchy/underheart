using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // Nom de la scène à charger
    public float delay = 10f; // Délai en secondes avant changement de scène

    void Start()
    {
        Invoke("ChangeScene", delay);
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Le nom de la scène n'est pas défini !");
        }
    }
}
