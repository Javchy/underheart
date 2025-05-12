using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int totalLeviers = 3;
    private int activatedLeviers = 0;

    public GameObject door; // L�objet porte � d�sactiver ou animer

    public void RegisterLevier()
    {
        activatedLeviers++;
        Debug.Log($"Leviers activ�s : {activatedLeviers}/{totalLeviers}");

        if (activatedLeviers >= totalLeviers)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        Debug.Log("Porte ouverte !");
        if (door != null)
            door.SetActive(false); // ou joue une animation, selon ton syst�me
    }
}
