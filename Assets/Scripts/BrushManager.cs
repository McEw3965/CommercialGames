using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrushManager : MonoBehaviour
{

    PickUpItem pickup; //reference to the pickup script

    [Header("Debugging Brush Position:")]
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;


    private void Start()
    {
        pickup = GameObject.FindWithTag("Player").GetComponent<PickUpItem>();

       

    }
    // Update is called once per frame
    void Update()
    {
        if (pickup.itemInHand && pickup.currentItem.name == "brush")
        {

            position = new Vector3(0, -3, 1f);
            rotation = new Vector3(52, -180, -4.1f);

            pickup.SetPosition(position);
            pickup.SetRotaion(rotation);
        }
    }
}
