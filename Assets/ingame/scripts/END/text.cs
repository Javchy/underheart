using System.Collections;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour

{
    public float typingSpeed = 0.05f;
    public string[] lines;
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeAllLines());
    }

    IEnumerator TypeAllLines()
    {
        foreach (string line in lines)
        {
            textComponent.text = ""; // reset
            foreach (char c in line)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
            yield return new WaitForSeconds(3f); // pause entre les lignes
        }
    }
}
