using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class CaptainMovement : MonoBehaviour
{


    private Vector3 centre;
    public float radius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        centre.x = this.gameObject.transform.position.x;
        centre.y = this.gameObject.transform.position.y;
        centre.z = this.gameObject.transform.position.z;

        Collider[] objectsInRange = Physics.OverlapSphere(centre, radius);
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            if (objectsInRange[i].tag == "Player")
            {
                Debug.Log("Player is near by");
            }
        }
    }
}
