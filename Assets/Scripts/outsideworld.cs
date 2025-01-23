using UnityEngine;

public class outsideworld : MonoBehaviour
{
    public Timer timer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            timer.timeleft = 0;
        }
    }
 
    
}
