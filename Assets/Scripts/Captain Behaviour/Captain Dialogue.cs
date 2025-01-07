using UnityEngine;

public class CaptainDialogue : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void Update()
    {
        if(timer.timeleft == 15f)
        {
            Debug.Log("ITS BEEN 15 SECONDS");
            gameObject.SetActive(true);
            gameObject.GetComponent<StartDialogue>().StartDialogues();
        }
    }

}
