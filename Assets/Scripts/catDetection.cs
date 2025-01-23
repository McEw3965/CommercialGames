using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class catDetection : MonoBehaviour
{


    public NavMeshAgent catagent;
    private Vector3 centre;
    public float radius = 10f;
    public bool catDetected = false;
    private Vector3 catLocation;
    private GameObject cat;
    public bool catPickedUp = false;
    public bool cathasbeenthrown = false;
    private Vector3 throwForce = new (1f, 0f, 1f);
    private GameObject holeCentre;

    private Animator animator;
    private int ThrowLayerIndex;
    private int CarryLayerIndex;
    public bool inPosition = false;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CD Running");
        holeCentre = GameObject.Find("Hole Marker");
        animator = GetComponent<Animator>();
        ThrowLayerIndex = animator.GetLayerIndex("Throw");
        CarryLayerIndex = animator.GetLayerIndex("Carry");


    }

    // Update is called once per frame
    void Update()
    {

        if (inPosition)
        {
            time += Time.deltaTime;
            animator.SetLayerWeight(CarryLayerIndex, 0f);

            animator.SetLayerWeight(ThrowLayerIndex, 1f);

            animator.SetTrigger("Throw");


            if(time > 2.2f)
            {
                holdCatOverHole();
            }
        }
        if (!catDetected && !catPickedUp)
        {
            centre.x = this.gameObject.transform.position.x;
            centre.y = this.gameObject.transform.position.y;
            centre.z = this.gameObject.transform.position.z;
            detectCat();
        }
        else if (catDetected) {
            pickUpCat();
        }
        
    }

    private void detectCat()
    {
        if(!cathasbeenthrown) { 
           
        Collider[] objectsInRange = Physics.OverlapSphere(centre, radius);
            for (int i = 0; i < objectsInRange.Length; i++)
            {
                if (objectsInRange[i].tag == "Cat")
                {
                    Debug.Log("Cat Detected");
                    catDetected = true;
                    catLocation.x = objectsInRange[i].gameObject.transform.position.x;
                    catLocation.y = objectsInRange[i].gameObject.transform.position.y;
                    catLocation.z = objectsInRange[i].gameObject.transform.position.z;
                    cat = objectsInRange[i].gameObject;
                    break;
                }
                else if (objectsInRange[i].tag != "Cat")
                {
                    catDetected = false;
                }
            }
        }
    }

    public Vector3 passCatPos()
    {
        return catLocation;
    }

    public void pickUpCat()
    {
        animator.SetLayerWeight(CarryLayerIndex, 1f);

        
            cat.transform.position = gameObject.transform.position + new Vector3(0f, 2f, 0.2f); // cat position is the aliens position, but higher
          
            if(cat.gameObject.GetComponent<NavMeshAgent>().enabled)
            {
                catagent.isStopped = true; //this stops the nav mesh agent so the cat does not move
            }
           
            cat.transform.rotation = transform.rotation;

            cat.GetComponent<CatMovement>().enabled = false; //turns off the cat movement
           // cat.GetComponent<Animator>().enabled = false;
            cat.GetComponent<NavMeshAgent>().enabled = false;
            cat.GetComponent<CapsuleCollider>().enabled = false;
            cat.GetComponent<Rigidbody>().useGravity = false;
            cat.GetComponent<Rigidbody>().freezeRotation = true;

        catPickedUp = true;
     
    }

    public void holdCatOverHole()
    {
  

        catPickedUp = false;
        catDetected = false;
        cat.GetComponent<Rigidbody>().isKinematic = true;

        cat.transform.position = holeCentre.gameObject.transform.position + new Vector3(0, 0f, 0);

        // Invoke("throwCat", 30f);

        throwCat();
    }

    public void throwCat()
    {
        Debug.Log("Throw Cat");
        
        cat.GetComponent<CapsuleCollider>().enabled = true;
        cat.GetComponent<Rigidbody>().useGravity = true;
        cat.GetComponent<Rigidbody>().isKinematic = false;
        cathasbeenthrown = true;


        inPosition = false;
    }

}
