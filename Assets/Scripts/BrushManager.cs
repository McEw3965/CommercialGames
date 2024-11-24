using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrushManager : MonoBehaviour
{

    PickUpItem pickup;

    [Header("Debugging Brush Position:")]
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;


    private void Start()
    {
        pickup = GameObject.FindWithTag("Player").GetComponent<PickUpItem>();

        position = new Vector3(0, -1.38f, 2.15f);
        rotation = new Vector3(52, -180, -4.1f);

    }
    // Update is called once per frame
    void Update()
    {
        if (pickup.itemInHand)
        {
            pickup.SetPosition(position);
            pickup.SetRotaion(rotation);
        }
    }
}
