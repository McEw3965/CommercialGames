using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Actions;
using UnityEngine;

public class rotateTest : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        Debug.Log(targetDirection);

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }


}
