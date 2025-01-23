using UnityEngine;

public class incineratorSwitch : MonoBehaviour
{
    [SerializeField] private GameObject Doors;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator doorAnimator;

    public bool doorsOpen = false;
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
            doorAnimator.SetBool("IsDoorOpen?", true);

            doorsOpen = true;

        } else
        {
            doorAnimator.SetBool("IsDoorOpen?", false);
            doorsOpen = false;

        }

    }
}
