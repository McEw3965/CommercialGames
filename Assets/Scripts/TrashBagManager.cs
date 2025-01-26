using UnityEngine;
using UnityEngine.Rendering;

public class TrashBagManager : MonoBehaviour
{
    PickUpItem pickup; //reference to the pickup script

    [Header("Debugging Brush Position:")]
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private GameObject initialPos;
    [SerializeField] private GameObject[] spawnPoints;

    public bool doonce = false;

    private Vector3 binBagPosition;
    private int chosenSpawn;

    public taskTerminal TT;
    public MainUIManager UIManager;
    public Timer timer;


    private void Start()
    {
        pickup = GameObject.FindWithTag("Player").GetComponent<PickUpItem>();
     //   initialPos = GameObject.Find("Trash Initial Position");
     //   binBagPosition = gameObject.GetComponent<Transform>().localPosition;

    }
    // Update is called once per frame
    void Update()
    {

        if (TT.trashTaskActive) { //if this task is active

            if (!doonce)
            {
                spawnTrash();
                doonce = true;
            }
          }


        if (pickup.itemInHand && pickup.currentItem.name == "Trash_Bag" || pickup.currentItem.name == "Trash_Bag 2" && pickup.itemInHand)
        {

            position = new Vector3(0, -1f, 3f);
            rotation = new Vector3(52, -180, -4.1f);

            pickup.SetPosition(position);
            pickup.SetRotaion(rotation);
        }

    }

    public void spawnTrash()
    {
        chosenSpawn = Random.Range(0, spawnPoints.Length);
        //gameObject.transform.localPosition = spawnPoints[chosenSpawn].GetComponent<Transform>().position;
        gameObject.transform.position = spawnPoints[0].GetComponent<Transform>().position;
        Debug.Log("Spawn trash");
    }


    public void resetPositon()
    {
        Debug.Log("Reset trash");
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        deactivateTask();
        doonce = false;
    }


    public void deactivateTask()
    {
       
        TT.trashTaskActive = false;
        UIManager.AdjustScore(25);
        TT.removeFromList("TaskTrash");
        timer.timeleft += 7;
    }
}
