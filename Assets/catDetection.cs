using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class catDetection : MonoBehaviour
{
    private Vector3 centre;
    public float radius = 10f;
    public bool catDetected = false;
    private Vector3 catLocation;
    private GameObject cat;
    public bool catPickedUp = false;
    private Vector3 throwForce = new (1f, 0f, 1f);
    private GameObject holeCentre;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CD Running");
        holeCentre = GameObject.Find("Hole Marker");

    }

    // Update is called once per frame
    void Update()
    {
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
            } else if (objectsInRange[i].tag != "Cat")
            {
                catDetected = false;
            }
        }
    }

    public Vector3 passCatPos()
    {
        return catLocation;
    }

    public void pickUpCat()
    {
        cat.transform.position = this.gameObject.transform.position + new Vector3 (0, 3f, 0);
        cat.GetComponent<Animator>().
        cat.GetComponent<CatMovement>().enabled = false;
        cat.GetComponent<NavMeshAgent>().enabled = false;
        cat.GetComponent<Collider>().enabled = false;
        cat.GetComponent<Rigidbody>().useGravity = false;
        cat.transform.rotation = this.transform.rotation;
        cat.GetComponent<Rigidbody>().freezeRotation = true;
        catPickedUp = true;
        
    }

    public void holdCatOverHole()
    {
        catPickedUp = false;
        catDetected = false;
        cat.GetComponent<Rigidbody>().useGravity = false;
        cat.GetComponent<Rigidbody>().isKinematic = true;

        cat.transform.position = holeCentre.gameObject.transform.position + new Vector3(0, 0f, 0);
        Invoke("throwCat", 30f);
    }

    public void throwCat()
    {
        Debug.Log("Throw Cat");
        cat.GetComponent<Collider>().enabled = true;
        cat.GetComponent<Rigidbody>().useGravity = true;
        cat.GetComponent<Rigidbody>().isKinematic = false;

        //cat.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

    }

}
