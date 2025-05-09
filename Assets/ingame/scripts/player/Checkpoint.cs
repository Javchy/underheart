using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private bool isActivated = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsActive", false);  // Assurez-vous que IsActive est false d�s le d�but
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint touch� !");
            isActivated = true;

            // Lance l'animation d'activation
            animator.SetTrigger("Activate");
            animator.SetBool("IsActive", true);  // Active le feu allum�

            RespawnManager.instance.SetCheckpoint(transform.position);
        }
    }

    // Cette m�thode est appel�e � la fin de l'animation "Activate"
    public void DeactivateActiveState()
    {
        animator.SetBool("IsActive", false);  // R�initialise le Bool � false pour arr�ter la boucle
    }
}