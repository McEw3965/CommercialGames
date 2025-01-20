using UnityEngine;

public class HallwayDoor : MonoBehaviour
{
    
    private Animator animator;
    private bool playerAtDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.GetComponent<Transform>().position, 5f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                Debug.Log("Player At Door");
                playerAtDoor = true;
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


}
