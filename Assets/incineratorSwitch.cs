using UnityEngine;

public class incineratorSwitch : MonoBehaviour
{
    [SerializeField] private GameObject Doors;
    private Animator doorAnimator;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private bool doorsOpen;
    public Vector3 leftInitialPos;
    public Vector3 rightInitialPos;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator = Doors.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoors()
    {
        if (!doorsOpen)
        {
            doorAnimator.SetBool("IsDoorOpen?", true);
            doorsOpen = true;
        } else if (doorsOpen)
        {
            doorAnimator.SetBool("IsDoorOpen?", false);
            doorsOpen = false;
        }

    }
}
