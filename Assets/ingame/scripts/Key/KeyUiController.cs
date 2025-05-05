using UnityEngine;
using UnityEngine.UI;

public class KeyUiController : MonoBehaviour
{
    public Image[] keySlots;
    public Sprite fullKeySprite; 

    public void UpdateKeyUI(int currentKeyCount)
    {
        for (int i = 0; i < keySlots.Length; i++)
        {
            if (i < currentKeyCount)
            {
                keySlots[i].sprite = fullKeySprite;
            }
        }
    }

}
