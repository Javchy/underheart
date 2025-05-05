using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Porte ouverte !");
       
        gameObject.SetActive(false); 
    }
}
