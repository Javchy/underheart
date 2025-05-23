using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // Nom de la sc�ne � charger
    public float delay = 10f; // D�lai en secondes avant changement de sc�ne

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
            Debug.LogWarning("Le nom de la sc�ne n'est pas d�fini !");
        }
    }
}
