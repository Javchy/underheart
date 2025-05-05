using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public int keyCount = 0;
    public int keysNeeded = 5;
    public DoorController door;
    public GameObject Key;

    public KeyUiController keyUI;
    public void CollectKey()
    {
        keyCount++;

        if (keyUI != null)
        {
            keyUI.UpdateKeyUI(keyCount);
        }

        if (keyCount >= keysNeeded)
        {
            door.OpenDoor();

        }
    }
}
