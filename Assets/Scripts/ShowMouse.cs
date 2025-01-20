using UnityEngine;

public class ShowMouse : MonoBehaviour
{

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
