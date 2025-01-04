using UnityEngine;

public class WallTrigger : MonoBehaviour
{

    public bool isTriggered;

    private void Start()
    {
        isTriggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
       

    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
}
