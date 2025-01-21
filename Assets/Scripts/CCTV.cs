using UnityEngine;

public class CCTV : MonoBehaviour
{
    public Material[] cameras;

    int camerasCount = 0;

    public void changeCCTV()
    {

        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (renderer != null && cameras.Length > 0)
        {
            if(camerasCount == 2)
            {
                camerasCount = -1;
            }
            camerasCount++; //go to the next camera
            renderer.material = cameras[camerasCount];  
        }

    }
}
