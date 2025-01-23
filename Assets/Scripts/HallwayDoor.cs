using UnityEngine;

public class HallwayDoor : MonoBehaviour
{
    /*
    private Animator animator;
    private bool playerAtDoor;

    private Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        position = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
      //  Collider[] hitColliders = Physics.OverlapSphere(position, 11f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                Debug.Log("Player At Door");
                playerAtDoor = true;
            }
            else
            {
                playerAtDoor = false;
            }
        }

        if (playerAtDoor)
        {
            animator.SetBool("isDoorOpen?", true);
        } else if (!playerAtDoor)
        {
            animator.SetBool("isDoorOpen?", false);
        }
    }

    */


    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cat" || other.tag == "Player" || other.name == "Waving Alien")
        {
            door.GetComponent<Animator>().SetBool("isDoorOpen?", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Cat" || other.tag == "Player" || other.name == "Waving Alien")
        {
            door.GetComponent<Animator>().SetBool("isDoorOpen?", false);

        }
    }
}
