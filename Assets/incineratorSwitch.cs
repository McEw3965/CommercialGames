using UnityEngine;

public class incineratorSwitch : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private bool doorsOpen;
    private Vector3 leftInitialPos;
    private Vector3 rightInitialPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 leftInitialPos = leftDoor.GetComponent<Transform>().localPosition;
        Vector3 rightInitialPos = rightDoor.GetComponent<Transform>().localPosition;
        Debug.Log("left initial Pos" + leftInitialPos);
        Debug.Log("Right Initial Pos" + rightInitialPos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoors()
    {
        Debug.Log("left initial Pos" + leftInitialPos);

        if (!doorsOpen)
        {

            Debug.Log("Doors Open");
            leftDoor.GetComponent<Transform>().localPosition = new Vector3(leftInitialPos.x + 4f, leftInitialPos.y, leftInitialPos.z);
            rightDoor.GetComponent<Transform>().localPosition = new Vector3(rightInitialPos.x - 4f, rightInitialPos.y, rightInitialPos.z);
            doorsOpen = true;

        } else if (doorsOpen)
        {
            Debug.Log("Doors Closed");
            leftDoor.GetComponent<Transform>().localPosition = new Vector3(leftInitialPos.x, leftInitialPos.y, leftInitialPos.z);
            rightDoor.GetComponent<Transform>().localPosition = new Vector3(rightInitialPos.x, rightInitialPos.y, rightInitialPos.z);
            doorsOpen = false;

        }

    }
}
