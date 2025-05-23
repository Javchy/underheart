using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public Image portraitImage;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.04f;

    private string[] lines;
    private int currentLine;
    private bool isTyping;
    private bool isDialogueOpen;

   


    void Start()
    {
        dialogueBox.SetActive(false);
        isDialogueOpen = false;
        dialogueText.text = "";
        portraitImage.sprite = null;
    }

    public void StartDialogue(string[] dialogueLines, Sprite portrait)
    {

       
        // Toggle OFF si déjà ouvert
        if (isDialogueOpen)
        {
            EndDialogue();
            return;
        }

        // Sécurité si vide
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogWarning("Dialogue lines array is empty!");
            return;
        }

        lines = dialogueLines;
        currentLine = 0;
        portraitImage.sprite = portrait;

        dialogueBox.SetActive(true);
        isDialogueOpen = true;

        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (!isDialogueOpen) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;

                if (currentLine < lines.Length)
                {
                    StartCoroutine(TypeLine());
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in lines[currentLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

   public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        isDialogueOpen = false;
        dialogueText.text = "";
        portraitImage.sprite = null;
    }
}
