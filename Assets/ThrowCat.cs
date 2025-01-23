using UnityEngine;

public class ThrowCat : MonoBehaviour
{
    [SerializeField] private catDetection CD;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Waving Alien" && CD.catDetected)
        {
            CD.holdCatOverHole();
        }
    }
}
