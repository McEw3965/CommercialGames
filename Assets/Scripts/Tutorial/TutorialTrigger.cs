using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public bool isPlayerInside = false;
    public bool isAlienInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("PlayerTrigger"))
        {
            isPlayerInside = true;
            Debug.Log("Player Inside");
        }
         if (other.gameObject.GetComponent<alienBehaviour>() != null && this.gameObject.CompareTag("AlienTrigger"))
        {
            isAlienInside = true;
        }


       
    }


 
}
