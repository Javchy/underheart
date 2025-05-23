using UnityEngine;

public class ennemieTrigger : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public Sprite portraitSprite;

    [TextArea(3, 5)]
    public string[] dialogueLines;

    private bool playerInRange;
    private audioManagerr audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagerr>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.Playsfx(audioManager.interaction);
            dialogueUI.StartDialogue(dialogueLines, portraitSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.EndDialogue(); // 👈 ferme le dialogue à la sortie
        }
    }
}
