using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public bool isPlayerInside = false;
    public bool isAlienInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
         if (other.gameObject.GetComponent<alienBehaviour>())
        {
            isAlienInside = true;
        }


       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
         if (other.gameObject.GetComponent<alienBehaviour>())
        {
            isAlienInside = false;
        }
    }

 
}
