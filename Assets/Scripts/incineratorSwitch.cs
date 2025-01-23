using UnityEngine;

public class incineratorSwitch : MonoBehaviour
{
    [SerializeField] private GameObject Doors;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator doorAnimator;

    private bool doorsOpen;
    public Vector3 leftInitialPos;
    public Vector3 rightInitialPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator = Doors.GetComponent<Animator>();

    }

    public void openDoors()
    {
        if (!doorsOpen)
        {
            doorsOpen = true;

            doorAnimator.SetBool("IsDoorOpen?", doorsOpen);
        } else if (doorsOpen)
        {
            doorsOpen = false;
            doorAnimator.SetBool("IsDoorOpen?", doorsOpen);
         
        }

    }
}
