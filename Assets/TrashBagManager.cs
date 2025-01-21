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
    public MeshRenderer[] children;

    public taskTerminal TT;
    public MainUIManager UIManager;
    public Timer timer;


    private void Start()
    {
        pickup = GameObject.FindWithTag("Player").GetComponent<PickUpItem>();
        initialPos = GameObject.Find("Trash Initial Position");
        

    }
    // Update is called once per frame
    void Update()
    {
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
        int chosenSpawn = Random.Range(0, spawnPoints.Length);
        this.gameObject.GetComponent<Transform>().localPosition = spawnPoints[chosenSpawn].GetComponent<Transform>().position;
        enableMesh();
    }
    public void resetPositon()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Transform>().localPosition = initialPos.GetComponent<Transform>().position;
        deactivateTask();
        disableMesh();
    }

    public void enableMesh()
    {
        for (int i = 0; i < children.Length; i ++)
        {
            children[i].enabled = true;
        }
    }

    public void disableMesh()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].enabled = false;
        }
    }

    public void deactivateTask()
    {
        TT.trashTaskActive = false;
        UIManager.AdjustScore(25);
        timer.timeleft += 7;
    }
}
