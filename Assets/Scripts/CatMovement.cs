using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatMovement : MonoBehaviour
{
    public NavMeshAgent cat;
    public Transform player;
    void Update()
    {
        cat.SetDestination(player.position);
    }
}
