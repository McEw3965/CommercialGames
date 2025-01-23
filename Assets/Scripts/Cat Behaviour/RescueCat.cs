using UnityEngine;
using UnityEngine.AI;

public class RescueCat : MonoBehaviour
{
    public catDetection CD;
    public taskTerminal TT;
    [SerializeField] private Timer timer;
    public MainUIManager UIManager;
    public Animator alienanimator;
    private float time = 0;
    
    private void Start()
    {
        gameObject.GetComponent<Interactable>().enabled = false;
        gameObject.GetComponent<Outline>().enabled = false;

    }
    public void saveTheCat()
    {

        alienanimator.SetLayerWeight(CD.CarryLayerIndex, 0f);

        CD.catPickedUp = false;
        CD.catDetected = false;
        CD.catCoolDown = true;

        gameObject.GetComponent<CatMovement>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().freezeRotation = false;


        gameObject.GetComponent<Interactable>().enabled = false;
        gameObject.GetComponent<Outline>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;


        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.7f, gameObject.transform.position.z);




        TT.removeFromList("TaskCat");
        timer.timeleft += 20;
        UIManager.AdjustScore(100);
        CD.catTaskActive = false;
    }


    private void Update()
    {

      

        if(CD.catCoolDown)
        {
            time += Time.deltaTime;
            if (time > 10)
            {
                time = 0;
                CD.catCoolDown = false;
                
            }
        }
       
    }


}
