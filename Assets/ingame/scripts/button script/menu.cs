using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Animator spriteAnimator;
    public float time = 5f;
    public void PlayGame()
    {
        if (spriteAnimator != null)
        {
            spriteAnimator.SetTrigger("PlayAnim");
        }

        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("startscene");
    }
}
