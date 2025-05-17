using UnityEngine;



public class KeyCollector : MonoBehaviour
{
    public int keyCount = 0;
    public int keysNeeded = 5;
    public main_door_controller door;
    public KeyUiController keyUI; 
    public void CollectKey()
    {
        keyCount++;
        Debug.Log("Clé récupérée ! Total : " + keyCount);

        if (keyUI != null)
            keyUI.UpdateKeyUI(keyCount);

        if (keyCount >= keysNeeded)
        {
            Debug.Log("cool");
            door.UnlockDoor();
        }

    }
}
