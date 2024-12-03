using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class catDetection : MonoBehaviour
{
    private Vector3 centre;
    public float radius = 5;
    public bool catDetected = false;
    private Vector3 catLocation;
    private GameObject cat;
    public bool catPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CD Running");
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
        Debug.Log("DetectCat Running");
        
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
        cat.GetComponent<CatMovement>().enabled = false;
        cat.GetComponent<NavMeshAgent>().enabled = false;
        cat.GetComponent<Collider>().enabled = false;
        
    }
}
