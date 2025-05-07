using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InteractionWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public Image backgroundImage; // Ou SpriteRenderer si tu utilises un sprite
    public float fadeSpeed = 2f;

    private bool isInRange = false;

    void Start()
    {
        SetAlpha(0f); // Tout invisible au début
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void Update()
    {
        float targetAlpha = isInRange ? 1f : 0f;
        FadeTo(targetAlpha);
    }

    void FadeTo(float targetAlpha)
    {
        if (warningText != null)
        {
            Color color = warningText.color;
            color.a = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            warningText.color = color;
        }

        if (backgroundImage != null)
        {
            Color color = backgroundImage.color;
            color.a = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            backgroundImage.color = color;
        }
    }

    void SetAlpha(float alpha)
    {
        if (warningText != null)
        {
            Color color = warningText.color;
            color.a = alpha;
            warningText.color = color;
        }

        if (backgroundImage != null)
        {
            Color color = backgroundImage.color;
            color.a = alpha;
            backgroundImage.color = color;
        }
    }
}
