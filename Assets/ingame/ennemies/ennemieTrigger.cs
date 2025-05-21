using UnityEngine;

public class ennemieTrigger : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public Sprite portraitSprite;

    [TextArea(3, 5)]
    public string[] dialogueLines;

    private bool playerInRange;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.StartDialogue(dialogueLines, portraitSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}


