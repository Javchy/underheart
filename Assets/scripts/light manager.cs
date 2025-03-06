using UnityEngine;

public class lightmanager : MonoBehaviour
{
    private Vector3 MousePos;
    public Camera MainCam;

    void Update()
    {
        // Rotate cannon towards the mouse position
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = MousePos - transform.position;
        float RotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, RotZ);
    }
}
